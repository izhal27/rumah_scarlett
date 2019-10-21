using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RumahScarlett.Presentation.Views.CommonControls;

namespace RumahScarlett.Presentation.Views.Grafik
{
   public interface IGrafikBarangTerjualView : IView
   {
      event EventHandler OnLoadView;
      event EventHandler OnButtonTampilkanClick;

      Chart ChartPenjualan { get; }
      RadioButton RadioButtonBulan { get; }
      ComboBoxBulan ComboBoxBulan { get; }
      NumericUpDown NumericUpDownTahun { get; }
      ComboBoxBulan ComboBoxBulanAwal { get; }
      NumericUpDown NumericUpDownTahunAwal { get; }
      ComboBoxBulan ComboBoxBulanAkhir { get; }
      NumericUpDown NumericUpDownTahunAkhir { get; }
   }
}