using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Views.ModelControls;
using Syncfusion.WinForms.DataGrid.Events;
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
      event EventHandler OnButtonTampilkanClick;
      event EventHandler OnRadioButtonTipeChecked;
      event EventHandler OnComboBoxTipeSelectedIndexChanged;
      event EventHandler OnRadioButtonSupplierChecked;      
   }
}
