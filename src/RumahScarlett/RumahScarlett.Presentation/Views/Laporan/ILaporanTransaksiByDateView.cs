using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Laporan
{
   public interface ILaporanTransaksiByDateView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnButtonCetakClick;
      event EventHandler OnLabelSelisihTextChanged;
      event EventHandler OnDateTimePickerTanggalValueChanged;

      DateTimePicker DateTimePickerTanggal { get; }
      Label LabelKasAwal { get; }
      Label LabelTotalPenjualan { get; }
      Label LabelTotalDiskon { get; }
      Label LabelTotalPengeluaran { get; }
      Label LabelSelisih { get; }
   }
}
