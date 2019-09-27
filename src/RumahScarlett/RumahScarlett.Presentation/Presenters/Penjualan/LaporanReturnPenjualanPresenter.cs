using Equin.ApplicationFramework;
using Microsoft.Reporting.WinForms;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Penjualan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Penjualan
{
   public class LaporanReturnPenjualanPresenter : ILaporanReturnPenjualanPresenter
   {
      private ILaporanReturnPenjualanView _view;
      private IPenjualanReturnServices _services;
      private List<IPenjualanReturnModel> _listReturnPenjualans;
      private BindingListView<PenjualanReturnModel> _bindingView;
      private string _typeName = "Return Penjualan";
      private DateTime _tanggal = DateTime.Now.Date;
      private TampilkanStatus _tampilkanStatus = TampilkanStatus.Tanggal;
      private DateTime _tanggalAwal;
      private DateTime _tanggalAkhir;

      public ILaporanReturnPenjualanView GetView
      {
         get { return _view; }
      }

      public LaporanReturnPenjualanPresenter()
      {
         _view = new LaporanReturnPenjualanView();
         _services = new PenjualanReturnServices(new PenjualanReturnRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_OnLoadData;
         _view.OnTampilkanClick += _view_OnTampilkanClick;
         _view.OnDeleteClick += _view_OnDeleteClick;
         _view.OnPrintClick += _view_OnPrintData;
         _view.OnDetailClick += _view_OnDetailClick;
         _view.OnDataGridCellDoubleClick += _view_OnDataGridCellDoubleClick;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _listReturnPenjualans = _services.GetByDate(DateTime.Now.Date).ToList();
            _bindingView = new BindingListView<PenjualanReturnModel>(_listReturnPenjualans);
            _view.ListDataGrid.DataSource = _bindingView;
         }
      }

      private void _view_OnDeleteClick(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null && _view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
            {
               try
               {
                  var model = _services.GetById(((PenjualanModel)_view.ListDataGrid.SelectedItem).id);

                  _services.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listReturnPenjualans.Remove((PenjualanReturnModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listReturnPenjualans;
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

      private void _view_OnPrintData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_bindingView.DataSource.Count > 0)
            {
               var parameters = new List<ReportParameter>();

               var listObjs = new List<IPenjualanReturnReportModel>();

               if (_tampilkanStatus == TampilkanStatus.Tanggal)
               {
                  listObjs = _services.GetReportByDate(_tanggal).ToList();

                  parameters.Add(new ReportParameter("Tanggal", _tanggal.ToShortDateString()));
               }
               else if (_tampilkanStatus == TampilkanStatus.Periode)
               {
                  listObjs = _services.GetReportByDate(_tanggalAwal, _tanggalAkhir).ToList();

                  parameters.Add(new ReportParameter("Tanggal", _tanggalAwal.ToShortDateString()));
                  parameters.Add(new ReportParameter("TanggalAkhir", _tanggalAkhir.ToShortDateString()));
               }

               var reportDataSources = new List<ReportDataSource>()
               {
                  new ReportDataSource {
                     Name = "DataSetReturnPenjualan",
                     Value = listObjs
                  }
               };

               new ReportView("Laporan Return Penjualan", "ReportViewerLaporanReturnPenjualan",
                              reportDataSources, parameters).ShowDialog();
            }
         }
      }

      private void _view_OnDetailClick(object sender, EventArgs e)
      {
         var model = (PenjualanReturnModel)_view.ListDataGrid.SelectedItem;

         if (model != null)
         {
            var detailView = new DetailView("Detail Return Penjualan");
            detailView.OnLoadView += DetailView_OnLoadView;
            detailView.OnButtonCetakClick += DetailView_OnButtonCetakClick;
            detailView.ShowDialog();
         }
      }

      private void DetailView_OnLoadView(object sender, EventArgs e)
      {
         var modelDetails = ((PenjualanReturnModel)_view.ListDataGrid.SelectedItem).PenjualanReturnDetails.ToList();
         var detailView = (DetailView)sender;

         if (modelDetails != null && modelDetails.Count > 0)
         {
            var bindingDetialView = new BindingListView<PenjualanReturnDetailModel>(modelDetails);
            detailView.ListDataGrid.DataSource = bindingDetialView;
         }
      }

      private void DetailView_OnButtonCetakClick(object sender, EventArgs e)
      {
         var penjualaReturnnModel = (PenjualanReturnModel)_view.ListDataGrid.SelectedItem;

         ReportHelper.ShowNotaReturnPenjualan(penjualaReturnnModel);

         ((Form)sender).Close();
      }

      private void _view_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _tampilkanStatus = e.TampilkanStatus;

            switch (e.TampilkanStatus)
            {
               case TampilkanStatus.Tanggal:

                  _listReturnPenjualans = _services.GetByDate(e.Tanggal.Date).ToList();
                  _bindingView.DataSource = _listReturnPenjualans;
                  _tanggal = e.Tanggal.Date;

                  break;
               case TampilkanStatus.Periode:

                  _listReturnPenjualans = _services.GetByDate(e.TanggalAwal.Date, e.TanggalAkhir.Date).ToList();
                  _bindingView.DataSource = _listReturnPenjualans;
                  _tanggalAwal = e.TanggalAwal.Date;
                  _tanggalAkhir = e.TanggalAkhir.Date;

                  break;
            }

            if (_view.ListDataGrid.SelectedItem != null)
            {
               _view.ListDataGrid.SelectedItem = null;
            }
         }
      }

      private void _view_OnDataGridCellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
      {
         _view_OnDetailClick(null, null);
      }
   }
}
