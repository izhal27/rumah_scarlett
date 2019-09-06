using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.ModelControls;
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
      event EventHandler OnHapusData;
      event EventHandler OnSimpanData;
      event EventHandler OnBersihkanData;
      event EventHandler<CurrentCellKeyEventArgs> OnListDataGridCurrentCellKeyDown;
      event EventHandler<CurrentCellActivatedEventArgs> OnListDataGridCurrentCellActivated;
      event EventHandler<CurrentCellEndEditEventArgs> OnListDataGridCurrentCellEndEdit;
      event EventHandler<PreviewKeyDownEventArgs> OnListDataGridPreviewKeyDown;

      ListDataGrid ListDataGrid { get; }
      ComboBoxSupplier ComboBoxSupplier { get; }
      Label LabelTotalQty { get; }
      Label LabelTotalPembelian { get; }
   }
}
