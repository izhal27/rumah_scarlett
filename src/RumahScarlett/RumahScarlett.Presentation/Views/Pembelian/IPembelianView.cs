using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Pembelian
{
   public interface IPembelianView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnCariData;
      event EventHandler<CurrentCellKeyEventArgs> OnCellKodeKeyDown;
      event EventHandler<CurrentCellKeyEventArgs> OnCellNamaKeyDown;
      event EventHandler<CurrentCellKeyEventArgs> OnCellQtyKeyDown;
      event EventHandler<CurrentCellKeyEventArgs> OnCellHppKeyDown;
      event EventHandler OnHapusData;
      event EventHandler OnSimpanData;
      event EventHandler OnBersihkanData;

      ListDataGrid ListDataGrid { get; }
      ComboBox ComboBoxSupplier { get; }
      Label LabelTotalQty { get; }
      Label LabelTotalPembelian { get; }
   }
}
