using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Laporan
{
   public partial class LaporanLabaRugiView : Form, ILaporanLabaRugiView
   {
      public event EventHandler OnButtonCetakClick;
      public event EventHandler OnComboBoxBulanSelectedIndexChanged;

      public Label LabelPenjualan
      {
         get { return labelPenjualan; }
      }

      public Label LabelHpp
      {
         get { return labelHpp; }
      }

      public Label LabelPengeluaran
      {
         get { return labelPengeluaran; }
      }

      public Label LabelDiskonPenjualan
      {
         get { return labelDiskonPenjualan; }
      }

      public Label LabelTotalPemasukan
      {
         get { return labelTotalPemasukan; }
      }

      public Label LabelTotalPengeluaran
      {
         get { return labelTotalPengeluaran; }
      }

      public Label LabelTotalSelisih
      {
         get { return labelTotalSelisih; }
      }

      public LaporanLabaRugiView()
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();
      }

      private void LaporanLabaRugiView_Load(object sender, EventArgs e)
      {
         textBoxTahun.Text = DateTime.Now.Year.ToString();
         ActiveControl = buttonTutup;
      }

      public void ShowView()
      {
         ShowDialog();
      }

      private void comboBoxBulan_SelectedIndexChanged(object sender, EventArgs e)
      {
         OnComboBoxBulanSelectedIndexChanged?.Invoke(sender, e);
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnButtonCetakClick?.Invoke(sender, e);
      }
   }
}
