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
         using (new WaitCursorHandler())
         {
            _listObjs = _barangServices.GetAll().ToList();

            if (_view.ListDataGrid != null && _view.ComboBoxTipe != null &&
                _view.ComboBoxSubTipe != null && _view.ComboBoxSupplier != null)
            {
               _bindingView = new BindingListView<BarangModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;

               _view.ComboBoxTipe.Enabled = false;
               _view.ComboBoxSubTipe.Enabled = false;
               _view.ComboBoxSupplier.Enabled = false;
               ((Form)_view).ActiveControl = _view.ButtonTampilkan;
            }
         }
      }

      private void _view_RadioButtonTipe_CheckedChanged(object sender, EventArgs e)
      {
         var status = _view.RadioButtonTipe.Checked;

         _view.ComboBoxTipe.Enabled = status;
         _view.ComboBoxSubTipe.Enabled = status;
      }

      private void _view_RadioButtonSupplier_CheckedChanged(object sender, EventArgs e)
      {
         _view.ComboBoxSupplier.Enabled = _view.RadioButtonSupplier.Checked;
      }

      private void _view_ButtonTampilkan_Click(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.RadioButtonSemua.Checked) // Filter by semua barang
            {
               _bindingView.DataSource = _listObjs;
            }
            else if (_view.RadioButtonTipe.Checked) // Filter by tipe
            {
               var tipeId = _view.ComboBoxTipe.CombBox.SelectedValue != null ?
                           (uint)_view.ComboBoxTipe.CombBox.SelectedValue : default(uint);
               var subTipeId = _view.ComboBoxSubTipe.ComboBox.SelectedValue != null ?
                              (uint)_view.ComboBoxSubTipe.ComboBox.SelectedValue : default(uint);

               var filterBarang = _listObjs.Where(b => b.tipe_id == tipeId && b.sub_tipe_id == subTipeId).ToList();
               _bindingView.DataSource = filterBarang;
            }
            else // Filter by supplier
            {
               var supplierId = _view.ComboBoxSupplier.ComboBox.SelectedValue != null ?
                                (uint)_view.ComboBoxSupplier.ComboBox.SelectedValue : default(uint);

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
         using (new WaitCursorHandler())
         {
            ListDataGrid listDataGrid = null;

            if (sender is ListDataGrid)
            {
               listDataGrid = (ListDataGrid)sender;
            }
            else
            {
               listDataGrid = _view.ListDataGrid;
            }

            if (listDataGrid != null && listDataGrid.SelectedItem != null)
            {
               var model = _barangServices.GetById(((BarangModel)listDataGrid.SelectedItem).id);

               if (model != null)
               {
                  var view = new BarangEntryView(false, model);
                  view.OnSaveData += BarangEntryView_OnSaveData;
                  view.ShowDialog();
               }
            }
         }
      }

      private void BarangEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var newModel = ((ModelEventArgs<BarangModel>)e).Value;
               var barangEntryView = ((BarangEntryView)sender);

               if (newModel.id == default(uint))
               {
                  _barangServices.Insert(newModel);
                  barangEntryView.Controls.ClearControls();
                  Messages.InfoSave(_typeName);

                  _listObjs.Add(newModel);
                  _bindingView.DataSource = _listObjs;
               }
               else
               {
                  _barangServices.Update(newModel);
                  Messages.InfoUpdate(_typeName);
                  barangEntryView.Close();

                  var model = _bindingView.Where(b => b.id == newModel.id).FirstOrDefault();

                  if (model != null)
                  {
                     model.tipe_id = newModel.tipe_id;
                     model.sub_tipe_id = newModel.sub_tipe_id;
                     model.supplier_id = newModel.supplier_id;
                     model.kode = newModel.kode;
                     model.nama = newModel.nama;
                     model.hpp = newModel.hpp;
                     model.harga_jual = newModel.harga_jual;
                     model.harga_lama = newModel.harga_lama;
                     model.stok = newModel.stok;
                     model.minimal_stok = newModel.minimal_stok;
                     model.satuan_id = newModel.satuan_id;
                     model.satuan_nama = newModel.satuan_nama;

                     _bindingView.Refresh();
                  }
               }
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
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null && _view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
            {
               try
               {
                  var model = _barangServices.GetById(((BarangModel)_view.ListDataGrid.SelectedItem).id);

                  _barangServices.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listObjs.Remove((BarangModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listObjs;
                  }
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
