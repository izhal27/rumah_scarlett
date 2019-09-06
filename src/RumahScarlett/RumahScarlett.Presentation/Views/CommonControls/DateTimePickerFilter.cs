﻿using RumahScarlett.CommonComponents;
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
      }

      private void radioButtonTanggal_CheckedChanged(object sender, EventArgs e)
      {
         dateTimePickerPeriodeAkhir.Enabled = ((RadioButton)sender).Checked;
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
            OnTampilkanClick?.Invoke(sender, e);
         }
         else if (radioButtonTanggal.Checked)
         {
            TampilkanStatus = TampilkanStatus.Tanggal;
            var dicTanggal = new Dictionary<string, DateTime>();
            dicTanggal.Add("tanggal", dateTimePickerTanggal.Value);

            OnTampilkanClick?.Invoke(sender, new EventArgs<Dictionary<string, DateTime>>(dicTanggal));
         }
         else if (radioButtonPeriode.Checked)
         {
            TampilkanStatus = TampilkanStatus.Tanggal;
            var dicTanggal = new Dictionary<string, DateTime>();
            dicTanggal.Add("tanggalAwal", dateTimePickerPeriodeAwal.Value);
            dicTanggal.Add("tanggalAkhir", dateTimePickerPeriodeAkhir.Value);

            OnTampilkanClick?.Invoke(sender, new EventArgs<Dictionary<string, DateTime>>(dicTanggal));
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
