using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
using RumahScarlett.Presentation.Views.Laporan;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanStatusBarangPresenter : ILaporanStatusBarangPresenter
   {
      private ILaporanStatusBarangView _view;
      private IStatusBarangServices _services;
      private IStatusBarangModel _model;

      public ILaporanStatusBarangView GetView
      {
         get { return _view; }
      }

      public LaporanStatusBarangPresenter()
      {
         _view = new LaporanStatusBarangView();
         _services = new StatusBarangServices(new StatusBarangRepository());

         _view.OnLoadData += _view_OnLoadData;
         _view.OnButtonCetakClick += _view_OnButtonCetakClick;
         _view.OnDateTimePickerTanggalValueChanged += _view_OnDateTimePickerTanggalValueChanged;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         SetLabelValues();
      }

      private void _view_OnButtonCetakClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnDateTimePickerTanggalValueChanged(object sender, EventArgs e)
      {
         SetLabelValues();
      }

      private void SetLabelValues()
      {
         _model = _services.GetByDate(_view.DateTimePickerTanggal.Value.Date);

         var stokAwal = 0;
         var stokMasuk = 0;
         var stokKeluar = 0;
         var stokAkhir = 0;

         if (_model != null)
         {
            stokAwal = _model.stok_awal;
            stokMasuk = _model.stok_masuk;
            stokKeluar = _model.stok_keluar;
            stokAkhir = _model.stok_akhir;
         }

         _view.LabelStokAwal.Text = stokAwal.ToString("N0");
         _view.LabelStokMasuk.Text = stokMasuk.ToString("N0");
         _view.LabelStokKeluar.Text = stokKeluar.ToString("N0");
         _view.LabelStokAkhir.Text = stokAkhir.ToString("N0");
      }
   }
}
