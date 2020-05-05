using RumahScarlett.Presentation.Views.CommonControls;
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
   public interface ILaporanStatusPerBarangView : IView
   {
      event EventHandler OnLoadView;
      event EventHandler OnButtonTampilkanClick;
      event EventHandler OnButtonCetakClick;

      ListDataGrid ListDataGrid { get; }
      RadioButton RadioButtonBulan { get; }
      ComboBoxBulan ComboBoxBulan { get; }
      NumericUpDown NumericUpDownTahun { get; }
      ComboBoxBulan ComboBoxBulanAwal { get; }
      NumericUpDown NumericUpDownTahunAwal { get; }
      ComboBoxBulan ComboBoxBulanAkhir { get; }
      NumericUpDown NumericUpDownTahunAkhir { get; }
      Label LabelTotalMasuk { get; }
      Label LabelTotalKeluar { get; }
  }
}