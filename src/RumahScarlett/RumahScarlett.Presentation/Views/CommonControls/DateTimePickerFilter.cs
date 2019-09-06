using RumahScarlett.CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class DateTimePickerFilter : UserControl
   {
      public TampilkanStatus TampilkanStatus { get; private set; }
      public event EventHandler<FilterEventArgs> OnTampilkanClick;

      public DateTimePickerFilter()
      {
         InitializeComponent();

         dateTimePickerTanggal.Enabled = false;
         dateTimePickerPeriodeAwal.Enabled = false;
         dateTimePickerPeriodeAkhir.Enabled = false;
      }

      private void radioButtonTanggal_CheckedChanged(object sender, EventArgs e)
      {
         dateTimePickerTanggal.Enabled = ((RadioButton)sender).Checked;
      }

      private void radioButtonPeriode_CheckedChanged(object sender, EventArgs e)
      {
         var status = ((RadioButton)sender).Checked;

         dateTimePickerPeriodeAwal.Enabled = status;
         dateTimePickerPeriodeAkhir.Enabled = status;
      }

      private void buttonTampilkan_Click(object sender, EventArgs e)
      {
         var filterEventArgs = new FilterEventArgs();

         if (radioButtonSemua.Checked)
         {
            filterEventArgs.TampilkanStatus = TampilkanStatus.Semua;

            OnTampilkanClick?.Invoke(this, filterEventArgs);
         }
         else if (radioButtonTanggal.Checked)
         {
            filterEventArgs.TampilkanStatus = TampilkanStatus.Tanggal;
            filterEventArgs.Tanggal = dateTimePickerTanggal.Value;
            
            OnTampilkanClick?.Invoke(this, filterEventArgs);
         }
         else if (radioButtonPeriode.Checked)
         {
            filterEventArgs.TampilkanStatus = TampilkanStatus.Periode;
            filterEventArgs.TanggalAwal = dateTimePickerPeriodeAwal.Value;
            filterEventArgs.TanggalAkhir = dateTimePickerPeriodeAkhir.Value;

            OnTampilkanClick?.Invoke(this, filterEventArgs);
         }
      }

      public void RefreshFilter()
      {
         radioButtonSemua.Checked = true;
         buttonTampilkan_Click(this, null);
      }
   }

   public enum TampilkanStatus
   {
      Semua,
      Tanggal,
      Periode,
   }

   public class FilterEventArgs : EventArgs
   {
      public TampilkanStatus TampilkanStatus { get; set; }
      public DateTime Tanggal { get; set; }
      public DateTime TanggalAwal { get; set; }
      public DateTime TanggalAkhir { get; set; }
   }
}
