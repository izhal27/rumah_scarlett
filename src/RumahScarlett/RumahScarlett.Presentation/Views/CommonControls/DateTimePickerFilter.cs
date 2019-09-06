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
      public event EventHandler OnTampilkanClick;

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
         if (radioButtonSemua.Checked)
         {
            TampilkanStatus = TampilkanStatus.Semua;

            OnTampilkanClick?.Invoke(this, e);
         }
         else if (radioButtonTanggal.Checked)
         {
            TampilkanStatus = TampilkanStatus.Tanggal;

            var dictTanggal = new Dictionary<string, DateTime>();
            dictTanggal.Add("tanggal", dateTimePickerTanggal.Value);

            OnTampilkanClick?.Invoke(this, new EventArgs<Dictionary<string, DateTime>>(dictTanggal));
         }
         else if (radioButtonPeriode.Checked)
         {
            TampilkanStatus = TampilkanStatus.Periode;

            var dictTanggal = new Dictionary<string, DateTime>();
            dictTanggal.Add("tanggalAwal", dateTimePickerPeriodeAwal.Value);
            dictTanggal.Add("tanggalAkhir", dateTimePickerPeriodeAkhir.Value);

            OnTampilkanClick?.Invoke(this, new EventArgs<Dictionary<string, DateTime>>(dictTanggal));
         }
      }
   }

   public enum TampilkanStatus
   {
      Semua,
      Tanggal,
      Periode,
   }
}
