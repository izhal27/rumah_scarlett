using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Laporan;
using RumahScarlett.Services.Services.Laporan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
using RumahScarlett.Domain.Models.Laporan;
using Equin.ApplicationFramework;
using RumahScarlett.Presentation.Views.CommonControls;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanStatusBarangPresenter : ILaporanStatusBarangPresenter
   {
      private ILaporanStatusBarangView _view;
      private ILaporanStatusBarangServices _services;
      private BindingListView<LaporanStatusBarangModel> _bindingView;
      private List<ILaporanStatusBarangModel> _listObjs;

      public ILaporanStatusBarangView GetView
      {
         get { return _view; }
      }

      public LaporanStatusBarangPresenter()
      {
         _view = new LaporanStatusBarangView();
         _services = new LaporanStatusBarangServices(new LaporanStatusBarangRepository());

         _view.OnFormLoad += _view_OnFormLoad;
         _view.OnButtonTampilkanClick += _view_OnButtonTampilkanClick;
      }

      private void _view_OnFormLoad(object sender, EventArgs e)
      {
         _listObjs = _services.GetByDate(DateTime.Now.Date).ToList();
         _bindingView = new BindingListView<LaporanStatusBarangModel>(_listObjs);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnButtonTampilkanClick(object sender, FilterDateEventArgs e)
      {
         switch (e.TampilkanStatus)
         {
            case TampilkanStatus.Tanggal:

               _listObjs = _services.GetByDate(e.Tanggal.Date).ToList();
               _bindingView.DataSource = _listObjs;

               break;
            case TampilkanStatus.Periode:

               _listObjs = _services.GetByDate(e.TanggalAwal.Date, e.TanggalAkhir.Date).ToList();
               _bindingView.DataSource = _listObjs;

               break;
         }
      }
   }
}
