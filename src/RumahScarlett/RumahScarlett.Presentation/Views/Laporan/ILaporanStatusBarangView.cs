﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Laporan
{
   public interface ILaporanStatusBarangView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnButtonCetakClick;
      event EventHandler OnDateTimePickerTanggalValueChanged;

      DateTimePicker DateTimePickerTanggal { get; }
      Label LabelStokAwal { get; }
      Label LabelStokMasuk { get; }
      Label LabelStokTerjual { get; }
      Label LabelPenyesuaianStok { get; }
      Label LabelReturnPenjualan { get; }
      Label LabelReturnPembelian { get; }
      Label LabelStokAkhir { get; }

      void ShowView();
   }
}
