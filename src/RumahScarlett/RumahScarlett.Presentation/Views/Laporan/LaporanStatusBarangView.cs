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
   public partial class LaporanStatusBarangView : Form, ILaporanStatusBarangView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnButtonCetakClick;
      public event EventHandler OnDateTimePickerTanggalValueChanged;

      public DateTimePicker DateTimePickerTanggal
      {
         get { return dateTimePickerTanggal; }
      }

      public Label LabelStokAwal
      {
         get { return labelStokAwal; }
      }

      public Label LabelStokMasuk
      {
         get { return labelStokMasuk; }
      }

      public Label LabelStokKeluar
      {
         get { return labelStokKeluar; }
      }
      
      public Label LabelStokAkhir
      {
         get { return labelStokAkhir; }
      }
      
      public LaporanStatusBarangView()
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();
      }

      private void LaporanStatusBarangView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnButtonCetakClick?.Invoke(sender, e);
      }

      private void dateTimePickerTanggal_ValueChanged(object sender, EventArgs e)
      {
         OnDateTimePickerTanggalValueChanged?.Invoke(sender, e);
      }

      public void ShowView()
      {
         ShowDialog();
      }
   }
}
