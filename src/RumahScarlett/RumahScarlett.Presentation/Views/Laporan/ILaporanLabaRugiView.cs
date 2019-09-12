using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Laporan
{
   public interface ILaporanLabaRugiView : IView
   {
      event EventHandler OnComboBoxBulanSelectedIndexChanged;
      event EventHandler OnButtonCetakClick;

      Label LabelPenjualan { get; }
      Label LabelHpp { get; }
      Label LabelPengeluaran { get; }
      Label LabelDiskonPenjualan { get; }
      Label LabelTotalPemasukan { get; }
      Label LabelTotalPengeluaran { get; }
      Label LabelTotalSelisih { get; }

      void ShowView();
   }
}
