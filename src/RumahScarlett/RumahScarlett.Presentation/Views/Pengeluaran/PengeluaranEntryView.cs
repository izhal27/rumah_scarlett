﻿using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pengeluaran;
using RumahScarlett.Presentation.Helper;
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

namespace RumahScarlett.Presentation.Views.Pengeluaran
{
   public partial class PengeluaranEntryView : BaseEntryView, IPengeluaranEntryView
   {
      private bool _isNewData;
      private IPengeluaranModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Pengeluaran";


      public PengeluaranEntryView(bool isNewData = true, IPengeluaranModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? $"TAMBAH {_typeName.ToUpper()}" : $"UBAH {_typeName.ToUpper()}";

         if (!_isNewData)
         {
            _model = model;
            textBoxNama.Text = model.nama;
            textBoxJumlah.Text = model.jumlah.ToString("N0");
            textBoxKeterangan.Text = model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new PengeluaranModel
         {
            nama = textBoxNama.Text,
            jumlah = uint.Parse(textBoxJumlah.Text, NumberStyles.Number),
            keterangan = textBoxKeterangan.Text
         };

         var modelArgs = new ModelEventArgs<PengeluaranModel>(model);

         if (_isNewData)
         {
            if (Messages.ConfirmSave(_typeName))
            {
               OnSaveData?.Invoke(this, modelArgs);
            }
         }
         else if (Messages.ConfirmUpdate(_typeName))
         {
            model.id = _model.id;
            model.tanggal = _model.tanggal;
            OnSaveData?.Invoke(this, modelArgs);
         }
      }
   }
}
