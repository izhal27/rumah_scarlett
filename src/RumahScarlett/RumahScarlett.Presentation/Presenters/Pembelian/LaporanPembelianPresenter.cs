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
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Pembelian
{
   public class LaporanPembelianPresenter : ILaporanPembelianPresenter
   {
      private ILaporanPembelianView _view;
      private IPembelianServices _services;
      private List<IPembelianModel> _listPembelians;
      private BindingListView<PembelianModel> _bindingView;
      private string _typeName = "Pembelian";

      public ILaporanPembelianView GetView
      {
         get { return _view; }
      }

      public LaporanPembelianPresenter()
      {
         _view = new LaporanPembelianView();
         _services = new PembelianServices(new PembelianRepository(), new ModelDataAnnotationCheck());

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
            _listPembelians = _services.GetByDate(DateTime.Now.Date).ToList();
            _bindingView = new BindingListView<PembelianModel>(_listPembelians);
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

                  if (_listPembelians.Remove((PembelianModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listPembelians;
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
            var _pembelianModel = (PembelianModel)_view.ListDataGrid.SelectedItem;

            if (_pembelianModel != null)
            {
               var parameters = new List<ReportParameter>();

               var reportDataSources = new List<ReportDataSource>()
               {
                  new ReportDataSource {
                     Name = "DataSetPembelian",
                     Value = new BindingSource(_pembelianModel, null)
                  },
                  new ReportDataSource {
                     Name = "DataSetPembelianDetail",
                     Value = _pembelianModel.PembelianDetails
                  }
               };

               new ReportView("Nota Pembelian", "ReportViewerPembelian",
                              reportDataSources, parameters).ShowDialog();
            }
         }
      }

      private void _view_OnDetailClick(object sender, EventArgs e)
      {
         var model = (PembelianModel)_view.ListDataGrid.SelectedItem;

         if (model != null)
         {
            var detailView = new BaseDetailView("Detail Pembelian");
            detailView.OnLoadView += DetailView_OnLoadView;
            detailView.ShowDialog();
         }
      }

      private void DetailView_OnLoadView(object sender, EventArgs e)
      {
         var modelDetails = ((PembelianModel)_view.ListDataGrid.SelectedItem).PembelianDetails.ToList();
         var detailView = (BaseDetailView)sender;

         if (modelDetails != null && modelDetails.Count > 0)
         {
            var bindingDetialView = new BindingListView<PembelianDetailModel>(modelDetails);
            detailView.ListDataGrid.DataSource = bindingDetialView;
         }
      }

      private void _view_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         using (new WaitCursorHandler())
         {
            switch (e.TampilkanStatus)
            {
               case TampilkanStatus.Tanggal:

                  _listPembelians = _services.GetByDate(e.Tanggal.Date).ToList();
                  _bindingView.DataSource = _listPembelians;

                  break;
               case TampilkanStatus.Periode:

                  _listPembelians = _services.GetByDate(e.TanggalAwal.Date, e.TanggalAkhir.Date).ToList();
                  _bindingView.DataSource = _listPembelians;

                  break;
            }
         }
      }

      private void _view_OnDataGridCellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnDetailClick(null, null);
      }
   }
}
