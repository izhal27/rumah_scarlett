using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Barang;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
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
      private List<IBarangModel> _listObjs;
      private BindingListView<BarangModel> _bindingView;
      private static string _typeName = "Barang";

      private ListDataGrid _view_listDataGrid;
      private RadioButton _view_radioButtonSemua;
      private RadioButton _view_radioButtonTipe;
      private RadioButton _view_radioButtonSupplier;
      private ComboBox _view_comboBoxTipe;
      private ComboBox _view_comboBoxSubTipe;
      private ComboBox _view_comboBoxSupplier;
      private Button _view_buttonTampilkan;

      public IBarangView GetView
      {
         get { return _view; }
      }

      public BarangPresenter()
      {
         _view = new BarangView();
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());

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

      private void _view_LoadData(object sender, EventArgs e)
      {
         _view_listDataGrid = (ListDataGrid)((EventArgs<Dictionary<string, Control>>)e).Value["listDataGrid"];
         _view_radioButtonSemua = (RadioButton)((EventArgs<Dictionary<string, Control>>)e).Value["radioButtonSemua"];
         _view_radioButtonTipe = (RadioButton)((EventArgs<Dictionary<string, Control>>)e).Value["radioButtonTipe"];
         _view_radioButtonSupplier = (RadioButton)((EventArgs<Dictionary<string, Control>>)e).Value["radioButtonSupplier"];
         _view_comboBoxTipe = (ComboBox)((EventArgs<Dictionary<string, Control>>)e).Value["comboBoxTipe"];
         _view_comboBoxSubTipe = (ComboBox)((EventArgs<Dictionary<string, Control>>)e).Value["comboBoxSubTipe"];
         _view_comboBoxSupplier = (ComboBox)((EventArgs<Dictionary<string, Control>>)e).Value["comboBoxSupplier"];
         _view_buttonTampilkan = (Button)((EventArgs<Dictionary<string, Control>>)e).Value["buttonTampilkan"];

         _listObjs = _barangServices.GetAll().ToList();

         if (_view_listDataGrid != null && _view_comboBoxTipe != null &&
             _view_comboBoxSubTipe != null && _view_comboBoxSupplier != null)
         {
            _bindingView = new BindingListView<BarangModel>(_listObjs);
            _view_listDataGrid.DataSource = _bindingView;

            _view_comboBoxTipe.Enabled = false;
            _view_comboBoxSubTipe.Enabled = false;
            _view_comboBoxSupplier.Enabled = false;
            ((Form)_view).ActiveControl = _view_buttonTampilkan;
         }
      }

      private void _view_RadioButtonTipe_CheckedChanged(object sender, EventArgs e)
      {
         var status = _view_radioButtonTipe.Checked;

         _view_comboBoxTipe.Enabled = status;
         _view_comboBoxSubTipe.Enabled = status;
      }

      private void _view_RadioButtonSupplier_CheckedChanged(object sender, EventArgs e)
      {
         _view_comboBoxSupplier.Enabled = _view_radioButtonSupplier.Checked;
      }

      private void _view_ButtonTampilkan_Click(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view_radioButtonSemua.Checked) // Filter by semua barang
            {
               _bindingView.DataSource = _listObjs;
            }
            else if (_view_radioButtonTipe.Checked) // Filter by tipe
            {
               var tipeId = _view_comboBoxTipe.SelectedValue != null ?
                           (uint)_view_comboBoxTipe.SelectedValue : default(uint);
               var subTipeId = _view_comboBoxSubTipe.SelectedValue != null ?
                              (uint)_view_comboBoxSubTipe.SelectedValue : default(uint);

               var filterBarang = _listObjs.Where(b => b.tipe_id == tipeId && b.sub_tipe_id == subTipeId).ToList();
               _bindingView.DataSource = filterBarang;
            }
            else // Filter by supplier
            {
               var supplierId = _view_comboBoxSupplier.SelectedValue != null ?
                                (uint)_view_comboBoxSupplier.SelectedValue : default(uint);

               var filterBarang = _listObjs.Where(b => b.supplier_id == supplierId).ToList();
               _bindingView.DataSource = filterBarang;
            }
         }
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new BarangEntryView();
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
            listDataGrid = _view_listDataGrid;
         }

         if (listDataGrid != null && listDataGrid.SelectedItem != null)
         {
            var model = _barangServices.GetById(((BarangModel)listDataGrid.SelectedItem).id);

            var view = new BarangEntryView(false, model);
            view.OnSaveData += BarangEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void BarangEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
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
      }

      private void _view_OnDeleteData(object sender, EventArgs e)
      {
         if (_view_listDataGrid != null && _view_listDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            try
            {
               var model = _barangServices.GetById(((BarangModel)_view_listDataGrid.SelectedItem).id);

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
               if (_view_listDataGrid.SelectedItem != null)
               {
                  _view_listDataGrid.SelectedItem = null;
               }
            }
         }
      }

      private void _view_OnRefreshData(object sender, EventArgs e)
      {
         _listObjs = _barangServices.GetAll().ToList();
         _bindingView.DataSource = _listObjs;

         _view_ButtonTampilkan_Click(null, null);
      }

      private void _view_DataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }
   }
}
