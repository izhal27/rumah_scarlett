using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RumahScarlett.Presentation.Views.Grafik
{
   public partial class GrafikBarangTerjualView : BaseDataView, IGrafikBarangTerjualView
   {
      public event EventHandler OnLoadView;
      public event EventHandler OnButtonTampilkanClick;

      public Chart ChartPenjualan
      {
         get { return chartPenjualan; }
      }

      public RadioButton RadioButtonBulan
      {
         get { return radioButtonBulan; }
      }

      public ComboBoxBulan ComboBoxBulan
      {
         get { return comboBoxBulan; }
      }

      public NumericUpDown NumericUpDownTahun
      {
         get { return numericUpDownTahun; }
      }

      public ComboBoxBulan ComboBoxBulanAwal
      {
         get { return comboBoxBulanAwal; }
      }

      public NumericUpDown NumericUpDownTahunAwal
      {
         get { return numericUpDownTahunAwal; }
      }

      public ComboBoxBulan ComboBoxBulanAkhir
      {
         get { return comboBoxBulanAkhir; }
      }

      public NumericUpDown NumericUpDownTahunAkhir
      {
         get { return numericUpDownTahunAkhir; }
      }

      public GrafikBarangTerjualView()
      {
         InitializeComponent();

         panelUp.LabelInfo = $"{Text.ToUpper()}";
      }

      private void GrafikPenjualanView_Load(object sender, EventArgs e)
      {
         var bulanSekarang = CultureInfo.CurrentCulture.DateTimeFormat
                             .MonthNames[DateTime.Now.AddMonths(-1).Month];

         comboBoxBulan.SelectedItem = bulanSekarang;
         comboBoxBulanAkhir.SelectedItem = bulanSekarang;

         OnLoadView?.Invoke(sender, e);
         ActiveControl = buttonTutup;
      }

      private void buttonTampilkan_Click(object sender, EventArgs e)
      {
         OnButtonTampilkanClick?.Invoke(sender, e);
      }

      private void buttonTutup_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
