using Microsoft.Reporting.WinForms;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
using RumahScarlett.Presentation.Helper;
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
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Presentation.Views.CommonControls;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanLabaRugiPresenter : ILaporanLabaRugiPresenter
   {
      private ILaporanLabaRugiView _view;
      private ILabaRugiServices _services;
      private ILabaRugiModel _model;

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
         _model = _services.GetByMonthYear(bulan, tahun);

         var totalPenjualan = 0M;
         var totalHpp = 0M;
         var totalPengeluaranOperasional = 0M;
         var totalDiskonPenjualan = 0M;
         var totalPemasukan = 0M;
         var totalPengeluaran = 0M;
         var totalSelisih = 0M;

         if (_model != null)
         {
            totalPenjualan = _model.total_penjualan;
            totalHpp = _model.total_hpp;
            totalPengeluaranOperasional = _model.total_pengeluaran;
            totalDiskonPenjualan = _model.total_diskon_penjualan;

            totalPemasukan = totalPenjualan;
            totalPengeluaran = (totalHpp + totalPengeluaranOperasional + totalDiskonPenjualan);
            totalSelisih = (totalPemasukan - totalPengeluaran);
         }

         _view.LabelPenjualan.Text = totalPenjualan.ToString("C");
         _view.LabelHpp.Text = totalHpp.ToString("C");
         _view.LabelPengeluaran.Text = totalPengeluaranOperasional.ToString("C");
         _view.LabelDiskonPenjualan.Text = totalDiskonPenjualan.ToString("C");
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
         using (new WaitCursorHandler())
         {
            var reportDataSources = new List<ReportDataSource>()
            {
               new ReportDataSource {
                  Name = "DataSetLabaRugi",
                  Value = new BindingSource(_model, null)
               }
            };

            var parameters = new List<ReportParameter>()
            {
               new ReportParameter("Bulan", _view.ComboBoxBulan.ComboBox.Text),
               new ReportParameter("Tahun", _view.NumericUpDownTahun.Value.ToString())
            };

            new ReportView("Report Laba Rugi", "ReportViewerLaporanLabaRugi",
                           reportDataSources, parameters).ShowDialog();
         }
      }
   }
}
