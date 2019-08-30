using RumahScarlett.Presentation.Views.ModelControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Barang
{
   public interface IBarangView : IDataView
   {
      RadioButton RadioButtonSemua { get; }
      RadioButton RadioButtonTipe { get; }
      RadioButton RadioButtonSupplier { get; }
      ComboBox ComboBoxTipe { get; }
      ComboBox ComboBoxSubTipe { get; }
      ComboBox ComboBoxSupplier { get; }
      Button ButtonTampilkan { get; }
   }
}
