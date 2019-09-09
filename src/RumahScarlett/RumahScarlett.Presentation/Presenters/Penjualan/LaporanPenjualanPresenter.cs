using Equin.ApplicationFramework;
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

namespace RumahScarlett.Presentation.Presenters.Penjualan
{
   public class LaporanPenjualanPresenter : ILaporanPenjualanPresenter
   {
      private ILaporanPenjualanView _view;
      private IPenjualanServices _services;
      private List<IPenjualanModel> _listPenjualans;
      private BindingListView<PenjualanModel> _bindingView;
      private string _typeName = "Penjualan";

      public ILaporanPenjualanView GetView
      {
         get { return _view; }
      }

      public LaporanPenjualanPresenter()
      {
         _view = new LaporanPenjualanView();
         _services = new PenjualanServices(new PenjualanRepository(), new ModelDataAnnotationCheck());

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
            _listPenjualans = _services.GetByDate(DateTime.Now.Date).ToList();
            _bindingView = new BindingListView<PenjualanModel>(_listPenjualans);
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

                  if (_listPenjualans.Remove((PenjualanModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listPenjualans;
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
         throw new NotImplementedException();
      }

      private void _view_OnDetailClick(object sender, EventArgs e)
      {
         var model = (PenjualanModel)_view.ListDataGrid.SelectedItem;

         if (model != null)
         {
            var detailView = new BaseDetailTransaksiView("Detail Penjualan");
            detailView.OnLoadView += DetailView_OnLoadView;
            detailView.OnCetakClick += DetailView_OnCetakClick;
            detailView.ShowDialog();
         }
      }

      private void DetailView_OnLoadView(object sender, EventArgs e)
      {
         var modelDetails = ((PenjualanModel)_view.ListDataGrid.SelectedItem).PenjualanDetails.ToList();
         var detailView = (BaseDetailTransaksiView)sender;

         if (modelDetails != null && modelDetails.Count > 0)
         {
            var bindingDetialView = new BindingListView<PenjualanDetailModel>(modelDetails);
            detailView.ListDataGrid.DataSource = bindingDetialView;
         }
      }

      private void DetailView_OnCetakClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         using (new WaitCursorHandler())
         {
            switch (e.TampilkanStatus)
            {
               case TampilkanStatus.Tanggal:

                  _listPenjualans = _services.GetByDate(e.Tanggal.Date).ToList();
                  _bindingView.DataSource = _listPenjualans;

                  break;
               case TampilkanStatus.Periode:

                  _listPenjualans = _services.GetByDate(e.TanggalAwal.Date, e.TanggalAkhir.Date).ToList();
                  _bindingView.DataSource = _listPenjualans;

                  break;
            }
         }
      }

      private void _view_OnDataGridCellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
      {
         _view_OnDetailClick(null, null);
      }

   }
}
