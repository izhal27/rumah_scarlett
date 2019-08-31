using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Barang;
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

         _view.ListDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
         _view.OnButtonTampilkanClick += _view_ButtonTampilkan_Click;
         _view.OnRadioButtonTipeChecked += _view_RadioButtonTipe_CheckedChanged;
         _view.OnComboBoxTipeSelectedIndexChanged += ComboBoxTipe_SelectedIndexChanged;
         _view.OnRadioButtonSupplierChecked += _view_RadioButtonSupplier_CheckedChanged;
      }

      private void ComboBoxTipe_SelectedIndexChanged(object sender, EventArgs<ComboBox> e)
      {
         var comboBoxTipe = (ComboBoxTipe)sender;
         var comboBoxSubTipe =  (ComboBoxSubTipe)e.Value;
         var subTipes = comboBoxTipe.SubTipes;

         if (subTipes != null)
         {
            var subTipeKVP = subTipes.Select(sub => new KeyValuePair<object, string>(sub.id, sub.nama)).ToList();
            comboBoxSubTipe.SetDataSource(subTipeKVP, false);
         }
      }

      private void _view_RadioButtonTipe_CheckedChanged(object sender, EventArgs<Dictionary<string, ComboBox>> e)
      {
         var radioButtonTipe = ((RadioButton)sender);
         var status = radioButtonTipe.Checked;

         e.Value["comboBoxTipe"].Enabled = status;
         e.Value["comboBoxSubTipe"].Enabled = status;

         _radioButtonTipeChecked = status;
         _radioButtonSemuaChecked = !status;
      }

      private void _view_RadioButtonSupplier_CheckedChanged(object sender, EventArgs<ComboBox> e)
      {
         var status = ((RadioButton)sender).Checked;
         e.Value.Enabled = status;

         _radioButtonSemuaChecked = !status;
      }

      private void _view_ButtonTampilkan_Click(object sender, EventArgs<Dictionary<string, ComboBox>> e)
      {
         if (_radioButtonSemuaChecked) // Filter by semua barang
         {
            _bindingView.DataSource = _listBarangs;
         }
         else if (_radioButtonTipeChecked) // Filter by tipe
         {
            var comboBoxTipe = e.Value["comboBoxTipe"];
            var comboBoxSubTipe = e.Value["comboBoxSubTipe"];

            var tipeId = comboBoxTipe.SelectedValue != null ?
                        (uint)comboBoxTipe.SelectedValue : default(uint);
            var subTipeId = comboBoxSubTipe.SelectedValue != null ?
                           (uint)comboBoxSubTipe.SelectedValue : default(uint);

            var filterBarang = _listBarangs.Where(b => b.tipe_id == tipeId && b.sub_tipe_id == subTipeId).ToList();
            _bindingView.DataSource = filterBarang;
         }
         else // Filter by supplier
         {
            var comboBoxSupplier = e.Value["comboBoxSupplier"];

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
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new BarangEntryView(_tipeServices);
         view.OnSaveData += BarangEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null)
         {
            var model = _barangServices.GetById(((BarangModel)_view.ListDataGrid.SelectedItem).id);

            var view = new BarangEntryView(_tipeServices, false, model);
            view.OnSaveData += BarangEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void BarangEntryView_OnSaveData(object sender, EventArgs<IBarangModel> e)
      {
         try
         {
            var model = (BarangModel)e.Value;
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
         if (_view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            try
            {
               var model = _barangServices.GetById(((BarangModel)_view.ListDataGrid.SelectedItem).id);

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
               if (_view.ListDataGrid.SelectedItem != null)
               {
                  _view.ListDataGrid.SelectedItem = null;
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
      
      private void ListDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(null, null);
      }
   }
}
