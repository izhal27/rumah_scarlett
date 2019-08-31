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
      event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;
      event EventHandler<EventArgs<Dictionary<string, ComboBox>>> OnButtonTampilkanClick;
      event EventHandler<EventArgs<Dictionary<string, ComboBox>>> OnRadioButtonTipeChecked;
      event EventHandler<EventArgs<ComboBox>> OnComboBoxTipeSelectedIndexChanged;
      event EventHandler<EventArgs<ComboBox>> OnRadioButtonSupplierChecked;      
   }
}
