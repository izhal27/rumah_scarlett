using Equin.ApplicationFramework;
using Microsoft.Reporting.WinForms;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.PenyesuaianStok;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.PenyesuaianStok;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.PenyesuaianStok
{
   public class PenyesuaianStokPresenter : IPenyesuaianStokPresenter
   {
      private IPenyesuaianStokView _view;
      private IPenyesuaianStokServices _services;
      private List<IPenyesuaianStokModel> _listObjs;
      private BindingListView<PenyesuaianStokModel> _bindingView;
      private static string _typeName = "Penyesuaian Stok";
      private TampilkanStatus _tampilkanStatus;
      private DateTime _tanggal;
      private DateTime _tanggal_awal;
      private DateTime _tanggal_akhir;

      public IPenyesuaianStokView GetView
      {
         get { return _view; }
      }

      public PenyesuaianStokPresenter()
      {
         _view = new PenyesuaianStokView();
         _services = new PenyesuaianStokServices(new PenyesuaianStokRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_LoadData;
         _view.OnButtonTambahClick += _view_OnCreateData;
         _view.OnButtonUbahClick += _view_OnUpdateData;
         _view.OnButtonHapusClick += _view_OnDeleteData;
         _view.OnButtonRefreshClick += _view_OnRefreshData;

         _view.OnDataGridCellDoubleClick += OnDataGrid_CellDoubleClick;
         _view.OnTampilkanClick += _view_OnTampilkanClick;
         _view.OnButtonCetakClick += _view_OnButtonCetakClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null)
            {
               _listObjs = _services.GetAll().ToList();
               _bindingView = new BindingListView<PenyesuaianStokModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;
               _bindingView.ListChanged += _bindingView_ListChanged;
               HitungTotal();
            }
         }
      }

      private void _bindingView_ListChanged(object sender, ListChangedEventArgs e)
      {
         HitungTotal();
      }

      private void HitungTotal()
      {
         var totalQty = _bindingView.Sum(h => h.qty);
         var totalHpp = _bindingView.Sum(h => h.hpp);

         _view.LabelTotalQty.Text = totalQty.ToString("N0");
         _view.LabelTotalHpp.Text = totalHpp.ToString("N0");
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new PenyesuaianStokEntryView();
         view.OnSaveData += PenyesuaianStokEntryView_OnSaveData;
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
               var model = _services.GetById(((PenyesuaianStokModel)listDataGrid.SelectedItem).id);

               if (model != null)
               {
                  var view = new PenyesuaianStokEntryView(false, model);
                  view.OnSaveData += PenyesuaianStokEntryView_OnSaveData;
                  view.ShowDialog();
               }
            }
         }
      }

      private void PenyesuaianStokEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var listDataGrid = _view.ListDataGrid;
               var newModel = ((ModelEventArgs<PenyesuaianStokModel>)e).Value;
               var view = ((PenyesuaianStokEntryView)sender);

               if (newModel.id == default(uint))
               {
                  _services.Insert(newModel);
                  view.Controls.ClearControls();
                  Messages.InfoSave(_typeName);

                  _listObjs.Add(newModel);
                  _bindingView.DataSource = _listObjs;

                  if (listDataGrid.SelectedItem != null)
                  {
                     listDataGrid.SelectedItem = null;
                  }

                  listDataGrid.SelectedItem = newModel;
               }
               else
               {
                  _services.Update(newModel);
                  Messages.InfoUpdate(_typeName);
                  view.Close();

                  var model = _bindingView.Where(b => b.id == newModel.id).FirstOrDefault();

                  if (model != null)
                  {
                     //model.tanggal = newModel.tanggal;
                     //model.Barang = newModel.Barang;
                     //model.hpp = newModel.hpp;
                     //model.qty = newModel.qty;
                     //model.satuan_id = newModel.satuan_id;
                     model.keterangan = newModel.keterangan;

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
                  var model = _services.GetById(((PenyesuaianStokModel)_view.ListDataGrid.SelectedItem).id);

                  _services.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listObjs.Remove((PenyesuaianStokModel)_view.ListDataGrid.SelectedItem))
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
         _listObjs = _services.GetAll().ToList();
         _bindingView.DataSource = _listObjs;
      }

      private void OnDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }

      private void _view_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         switch (e.TampilkanStatus)
         {
            case TampilkanStatus.Tanggal:

               _bindingView.DataSource = _listObjs.Where(ps => ps.tanggal.Date == e.Tanggal.Date).ToList();
               _tampilkanStatus = TampilkanStatus.Tanggal;
               _tanggal = e.Tanggal;

               break;
            case TampilkanStatus.Periode:

               _bindingView.DataSource = _listObjs.Where(ps => ps.tanggal.Date >= e.TanggalAwal.Date &&
                                                         ps.tanggal.Date <= e.TanggalAkhir.Date).ToList();
               _tampilkanStatus = TampilkanStatus.Periode;
               _tanggal_awal = e.TanggalAwal;
               _tanggal_akhir = e.TanggalAkhir;

               break;
            default:

               _bindingView.DataSource = _listObjs;
               _tampilkanStatus = TampilkanStatus.Semua;

               break;
         }
      }
      
      private void _view_OnButtonCetakClick(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_bindingView.DataSource != null && _bindingView.DataSource.Count > 0)
            {
               var parameters = new List<ReportParameter>();

               if (_tampilkanStatus == TampilkanStatus.Tanggal)
               {
                  parameters.Add(new ReportParameter("Tanggal", _tanggal.ToShortDateString()));
               }
               else if (_tampilkanStatus == TampilkanStatus.Periode)
               {
                  parameters.Add(new ReportParameter("Tanggal", _tanggal_awal.ToShortDateString()));
                  parameters.Add(new ReportParameter("TanggalAkhir", _tanggal_akhir.ToShortDateString()));
               }

               var reportDataSource = new ReportDataSource()
               {
                  Name = "DataSetPenyesuaianStok",
                  Value = _bindingView.DataSource
               };
               
               new ReportView("Report Penyesuaian Stok Barang", "ReportViewerPenyesuaianStok",
                              reportDataSource, parameters).ShowDialog();
            }
         }
      }
   }
}
