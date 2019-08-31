using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Barang;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.ModelControls;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.Tipe;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Barang
{
   class BarangPresenter : IBarangPresenter
   {
      private IBarangView _view;
      private IBarangServices _barangServices;
      private ITipeServices _tipeServices;
      private List<IBarangModel> _listBarangs;
      private List<ITipeModel> _listTipes;
      private BindingListView<BarangModel> _bindingView;
      private static string _typeName = "Barang";
      private bool _radioButtonSemuaChecked = true;
      private bool _radioButtonTipeChecked;

      public IBarangView GetView
      {
         get { return _view; }
      }

      public BarangPresenter()
      {
         _view = new BarangView();
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());
         _tipeServices = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_LoadData;
         _view.OnCreateData += _view_OnCreateData;
         _view.OnUpdateData += _view_OnUpdateData;
         _view.OnDeleteData += _view_OnDeleteData;
         _view.OnRefreshData += _view_OnRefreshData;

         _view.OnDataGridCellDoubleClick += _view_DataGrid_CellDoubleClick;
         _view.OnRadioButtonTipeChecked += _view_RadioButtonTipe_CheckedChanged;
         _view.OnRadioButtonSupplierChecked += _view_RadioButtonSupplier_CheckedChanged;
         _view.OnButtonTampilkanClick += _view_ButtonTampilkan_Click;
      }

      private void _view_RadioButtonTipe_CheckedChanged(object sender, EventArgs e)
      {
         var radioButtonTipe = ((RadioButton)sender);
         var status = radioButtonTipe.Checked;

         ((EventArgs<Dictionary<string, ComboBox>>)e).Value["comboBoxTipe"].Enabled = status;
         ((EventArgs<Dictionary<string, ComboBox>>)e).Value["comboBoxSubTipe"].Enabled = status;

         _radioButtonTipeChecked = status;
         _radioButtonSemuaChecked = !status;
      }
      
      private void _view_RadioButtonSupplier_CheckedChanged(object sender, EventArgs e)
      {
         var status = ((RadioButton)sender).Checked;
         ((EventArgs<ComboBox>)e).Value.Enabled = status;

         _radioButtonSemuaChecked = !status;
      }

      private void _view_ButtonTampilkan_Click(object sender, EventArgs e)
      {
         if (_radioButtonSemuaChecked) // Filter by semua barang
         {
            _bindingView.DataSource = _listBarangs;
         }
         else if (_radioButtonTipeChecked) // Filter by tipe
         {
            var comboBoxTipe = ((EventArgs<Dictionary<string, ComboBox>>)e).Value["comboBoxTipe"];
            var comboBoxSubTipe = ((EventArgs<Dictionary<string, ComboBox>>)e).Value["comboBoxSubTipe"];

            var tipeId = comboBoxTipe.SelectedValue != null ?
                        (uint)comboBoxTipe.SelectedValue : default(uint);
            var subTipeId = comboBoxSubTipe.SelectedValue != null ?
                           (uint)comboBoxSubTipe.SelectedValue : default(uint);

            var filterBarang = _listBarangs.Where(b => b.tipe_id == tipeId && b.sub_tipe_id == subTipeId).ToList();
            _bindingView.DataSource = filterBarang;
         }
         else // Filter by supplier
         {
            var comboBoxSupplier = ((EventArgs<Dictionary<string, ComboBox>>)e).Value["comboBoxSupplier"];

            var supplierId = comboBoxSupplier.SelectedValue != null ?
                             (uint)comboBoxSupplier.SelectedValue : default(uint);

            var filterBarang = _listBarangs.Where(b => b.supplier_id == supplierId).ToList();
            _bindingView.DataSource = filterBarang;
         }
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         _listBarangs = _barangServices.GetAll().ToList();
         _listTipes = _tipeServices.GetAll().ToList();

         _bindingView = new BindingListView<BarangModel>(_listBarangs);
         ((EventArgs<ListDataGrid>)e).Value.DataSource = _bindingView;
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new BarangEntryView(_tipeServices);
         view.OnSaveData += BarangEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         ListDataGrid listDataGrid = null;

         if (sender is ListDataGrid)
         {
            listDataGrid = (ListDataGrid)sender;
         }
         else
         {
            listDataGrid = ((EventArgs<ListDataGrid>)e).Value;
         }

         if (listDataGrid != null && listDataGrid.SelectedItem != null)
         {
            var model = _barangServices.GetById(((BarangModel)listDataGrid.SelectedItem).id);

            var view = new BarangEntryView(_tipeServices, false, model);
            view.OnSaveData += BarangEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void BarangEntryView_OnSaveData(object sender, EventArgs e)
      {
         try
         {
            var model = (BarangModel)((EventArgs<IBarangModel>)e).Value;
            var view = ((BarangEntryView)sender);

            if (model.id == default(uint))
            {
               _barangServices.Insert(model);
               view.Controls.ClearControls();
               Messages.InfoSave(_typeName);
            }
            else
            {
               _barangServices.Update(model);
               Messages.InfoUpdate(_typeName);
               view.Close();
            }

            _view_OnRefreshData(null, null);
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
      }

      private void _view_OnDeleteData(object sender, EventArgs e)
      {
         var listDataGrid = ((EventArgs<ListDataGrid>)e).Value;

         if (listDataGrid != null && listDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            try
            {
               var model = _barangServices.GetById(((BarangModel)listDataGrid.SelectedItem).id);

               _barangServices.Delete(model);
               Messages.InfoDelete(_typeName);
               _view_OnRefreshData(null, null);
            }
            catch (DataAccessException ex)
            {
               Messages.Error(ex);
            }
            finally
            {
               if (listDataGrid.SelectedItem != null)
               {
                  listDataGrid.SelectedItem = null;
               }
            }
         }
      }

      private void _view_OnRefreshData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _listTipes = _tipeServices.GetAll().ToList();

            _listBarangs = _barangServices.GetAll().ToList();
            _bindingView.DataSource = _listBarangs;
         }
      }

      private void _view_DataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }
   }
}
