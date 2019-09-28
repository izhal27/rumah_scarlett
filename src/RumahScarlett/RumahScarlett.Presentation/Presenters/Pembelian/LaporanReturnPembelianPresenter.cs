using Equin.ApplicationFramework;
using Microsoft.Reporting.WinForms;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Pembelian;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Pembelian
{
   public class LaporanReturnPembelianPresenter : ILaporanReturnPembelianPresenter
   {
      private ILaporanReturnPembelianView _view;
      private IPembelianReturnServices _services;
      private List<IPembelianReturnModel> _listReturnPembelians;
      private BindingListView<PembelianReturnModel> _bindingView;
      private string _typeName = "Return Pembelian";
      private DateTime _tanggal = DateTime.Now.Date;
      private TampilkanStatus _tampilkanStatus = TampilkanStatus.Tanggal;
      private DateTime _tanggalAwal;
      private DateTime _tanggalAkhir;

      public ILaporanReturnPembelianView GetView
      {
         get { return _view; }
      }

      public LaporanReturnPembelianPresenter()
      {
         _view = new LaporanReturnPembelianView();
         _services = new PembelianReturnServices(new PembelianReturnRepository(), new ModelDataAnnotationCheck());

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
            _listReturnPembelians = _services.GetByDate(DateTime.Now.Date).ToList();
            _bindingView = new BindingListView<PembelianReturnModel>(_listReturnPembelians);
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
                  var model = _services.GetById(((PembelianModel)_view.ListDataGrid.SelectedItem).id);

                  _services.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listReturnPembelians.Remove((PembelianReturnModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listReturnPembelians;
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

               var listObjs = new List<IPembelianReturnReportModel>();

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
                     Name = "DataSetReturnPembelian",
                     Value = listObjs
                  }
               };

               new ReportView("Laporan Return Pembelian", "ReportViewerLaporanReturnPembelian",
                              reportDataSources, parameters).ShowDialog();
            }
         }
      }

      private void _view_OnDetailClick(object sender, EventArgs e)
      {
         var model = (PembelianReturnModel)_view.ListDataGrid.SelectedItem;

         if (model != null)
         {
            var detailView = new DetailView("Detail Return Pembelian");
            detailView.OnLoadView += DetailView_OnLoadView;
            detailView.OnButtonCetakClick += DetailView_OnButtonCetakClick;
            detailView.ShowDialog();
         }
      }

      private void DetailView_OnLoadView(object sender, EventArgs e)
      {
         var modelDetails = ((PembelianReturnModel)_view.ListDataGrid.SelectedItem).PembelianReturnDetails.ToList();
         var detailView = (DetailView)sender;

         if (modelDetails != null && modelDetails.Count > 0)
         {
            var bindingDetialView = new BindingListView<PembelianReturnDetailModel>(modelDetails);
            detailView.ListDataGrid.DataSource = bindingDetialView;
         }
      }

      private void DetailView_OnButtonCetakClick(object sender, EventArgs e)
      {
         var pembelianReturnnModel = (PembelianReturnModel)_view.ListDataGrid.SelectedItem;

         ReportHelper.ShowNotaReturnPembelian(pembelianReturnnModel);

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

                  _listReturnPembelians = _services.GetByDate(e.Tanggal.Date).ToList();
                  _bindingView.DataSource = _listReturnPembelians;
                  _tanggal = e.Tanggal.Date;

                  break;
               case TampilkanStatus.Periode:

                  _listReturnPembelians = _services.GetByDate(e.TanggalAwal.Date, e.TanggalAkhir.Date).ToList();
                  _bindingView.DataSource = _listReturnPembelians;
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
