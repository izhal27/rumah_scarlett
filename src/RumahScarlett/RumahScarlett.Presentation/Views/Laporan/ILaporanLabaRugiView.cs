using RumahScarlett.Presentation.Views.CommonControls;
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
      event EventHandler OnLoadData;
      event EventHandler OnComboBoxBulanSelectedIndexChanged;
      event EventHandler OnNumericUpDownTahunValueChanged;
      event EventHandler OnLabelSelisihTextChanged;
      event EventHandler OnButtonCetakClick;

      ComboBoxBulan ComboBoxBulan { get; }
      NumericUpDown NumericUpDownTahun { get; }
      Label LabelPenjualan { get; }
      Label LabelHpp { get; }
      Label LabelPengeluaran { get; }
      Label LabelDiskonPenjualan { get; }
      Label LabelTotalSelisih { get; }

      void ShowView();
   }
}
