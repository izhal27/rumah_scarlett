﻿using Equin.ApplicationFramework;
using Microsoft.Reporting.WinForms;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.HutangOperasional;
using RumahScarlett.Infrastructure.DataAccess.Repositories.HutangOperasional;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.HutangOperasional;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.HutangOperasional;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.HutangOperasional
{
   public class HutangOperasionalPresenter : IHutangOperasionalPresenter
   {
      private IHutangOperasionalView _view;
      private IHutangOperasionalServices _services;
      private List<IHutangOperasionalModel> _listObjs;
      private BindingListView<HutangOperasionalModel> _bindingView;
      private static string _typeName = "Hutang Operasional";
      private TampilkanStatus _tampilkanStatus;
      private DateTime _tanggal;
      private DateTime _tanggal_awal;
      private DateTime _tanggal_akhir;

      public IHutangOperasionalView GetView
      {
         get { return _view; }
      }

      public HutangOperasionalPresenter()
      {
         _view = new HutangOperasionalView();
         _services = new HutangOperasionalServices(new HutangOperasionalRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_LoadData;
         _view.OnButtonTambahClick += _view_OnCreateData;
         _view.OnButtonUbahClick += _view_OnUpdateData;
         _view.OnButtonHapusClick += _view_OnDeleteData;
         _view.OnButtonRefreshClick += _view_OnRefreshData;
         _view.OnButtonCetakClick += _view_OnButtonCetakClick;

         _view.OnDataGridCellDoubleClick += OnDataGrid_CellDoubleClick;
         _view.OnTampilkanClick += _view_OnTampilkanClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null)
            {
               _listObjs = _services.GetAll().ToList();
               _bindingView = new BindingListView<HutangOperasionalModel>(_listObjs);
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
         var total = _bindingView.Cast<IHutangOperasionalModel>().Sum(h => h.jumlah);
         var totalLunas = _bindingView.Cast<IHutangOperasionalModel>().Where(h => h.status_hutang == true).Sum(h => h.jumlah);
         var totalSelisih = total - totalLunas;

         _view.LabelTotal.Text = total.ToString("N0");
         _view.LabelLunas.Text = totalLunas.ToString("N0");
         _view.LabelBelumLunas.Text = totalSelisih >= 0 ? totalSelisih.ToString("N0") : "0";
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new HutangOperasionalEntryView();
         view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
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
               var model = _services.GetById(((HutangOperasionalModel)listDataGrid.SelectedItem).id);

               if (model != null)
               {
                  var view = new HutangOperasionalEntryView(false, model);
                  view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
                  view.ShowDialog();
               }
            }
         }
      }

      private void HutangOperasionalEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var listDataGrid = _view.ListDataGrid;
               var newModel = ((ModelEventArgs<HutangOperasionalModel>)e).Value;
               var view = ((HutangOperasionalEntryView)sender);

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
                     model.tanggal = newModel.tanggal;
                     model.jumlah = newModel.jumlah;
                     model.keterangan = newModel.keterangan;
                     model.status_hutang = newModel.status_hutang;

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
                  var model = _services.GetById(((HutangOperasionalModel)_view.ListDataGrid.SelectedItem).id);

                  _services.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listObjs.Remove((HutangOperasionalModel)_view.ListDataGrid.SelectedItem))
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

               var reportDataSources = new List<ReportDataSource>()
               {
                  new ReportDataSource {
                     Name = "DataSetHutangOperasional",
                     Value = _bindingView.DataSource
                  }
               };
               
               new ReportView("Report Hutang Operasional", "ReportViewerHutangOperasional",
                              reportDataSources, parameters).ShowDialog();
            }
         }
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

               _bindingView.DataSource = _listObjs.Where(ps => ps.tanggal == e.Tanggal.Date).ToList();
               _tampilkanStatus = TampilkanStatus.Tanggal;
               _tanggal = e.Tanggal;

               break;
            case TampilkanStatus.Periode:

               _bindingView.DataSource = _listObjs.Where(ps => ps.tanggal >= e.TanggalAwal.Date &&
                                                         ps.tanggal <= e.TanggalAkhir.Date).ToList();
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

   }
}
