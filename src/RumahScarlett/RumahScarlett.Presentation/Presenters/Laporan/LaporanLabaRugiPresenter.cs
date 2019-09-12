using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
using RumahScarlett.Presentation.Views.Laporan;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanLabaRugiPresenter : ILaporanLabaRugiPresenter
   {
      private ILaporanLabaRugiView _view;
      private ILabaRugiServices _services;

      public ILaporanLabaRugiView GetView
      {
         get { return _view; }
      }

      public LaporanLabaRugiPresenter()
      {
         _view = new LaporanLabaRugiView();
         _services = new LabaRugiServices(new LabaRugiRepository());

         _view.OnLoadData += _view_OnLoadData;
         _view.OnComboBoxBulanSelectedIndexChanged += _view_OnComboBoxBulanSelectedIndexChanged;
         _view.OnNumericUpDownTahunValueChanged += _view_OnNumericUpDownTahunValueChanged;
         _view.OnLabelSelisihTextChanged += _view_OnLabelSelisihTextChanged;
         _view.OnButtonCetakClick += _view_OnButtonCetakClick;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         _view.NumericUpDownTahun.Maximum = DateTime.Now.Year;
         SetLabelValues();
      }

      private void _view_OnComboBoxBulanSelectedIndexChanged(object sender, EventArgs e)
      {
         SetLabelValues();
      }

      private void _view_OnNumericUpDownTahunValueChanged(object sender, EventArgs e)
      {
         SetLabelValues();
      }

      private void SetLabelValues()
      {
         var bulan = (_view.ComboBoxBulan.ComboBox.SelectedIndex + 1);
         var tahun = _view.NumericUpDownTahun.Value;
         var model = _services.GetByMonthYear(bulan, tahun);

         var totalPenjualan = 0M;
         var totalHpp = 0M;
         var totalPengeluaranOperasional = 0M;
         var totalDiskonPenjualan = 0M;
         var totalPemasukan = 0M;
         var totalPengeluaran = 0M;
         var totalSelisih = 0M;

         if (model != null)
         {
            totalPenjualan = model.total_penjualan;
            totalHpp = model.total_hpp;
            totalPengeluaranOperasional = model.total_pengeluaran;
            totalDiskonPenjualan = model.total_diskon_penjualan;

            totalPemasukan = totalPenjualan;
            totalPengeluaran = (totalHpp + totalPengeluaranOperasional + totalDiskonPenjualan);
            totalSelisih = (totalPemasukan - totalPengeluaran);
         }

         _view.LabelPenjualan.Text = totalPenjualan.ToString("C");
         _view.LabelHpp.Text = totalHpp.ToString("C");
         _view.LabelPengeluaran.Text = totalPengeluaranOperasional.ToString("C");
         _view.LabelDiskonPenjualan.Text = totalDiskonPenjualan.ToString("C");
         _view.LabelTotalPemasukan.Text = totalPemasukan.ToString("C");
         _view.LabelTotalPengeluaran.Text = totalPengeluaran.ToString("C");
         _view.LabelTotalSelisih.Text = totalSelisih.ToString("C");
      }

      private void _view_OnLabelSelisihTextChanged(object sender, EventArgs e)
      {
         var labelSelisih = (Label)sender;
         var selisih = decimal.Parse(labelSelisih.Text, NumberStyles.Currency);

         labelSelisih.ForeColor = selisih >= 0 ? SystemColors.ControlText : Color.Red;
      }

      private void _view_OnButtonCetakClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }
   }
}
