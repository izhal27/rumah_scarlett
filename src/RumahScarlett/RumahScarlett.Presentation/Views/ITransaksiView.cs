using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views
{
   public interface ITransaksiView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnCariData;
      event EventHandler OnHapusData;
      event EventHandler OnSimpanData;
      event EventHandler OnBersihkanData;
      event EventHandler OnCetakNota;
      event EventHandler<CurrentCellKeyEventArgs> OnListDataGridCurrentCellKeyDown;
      event EventHandler<CurrentCellActivatedEventArgs> OnListDataGridCurrentCellActivated;
      event EventHandler<CurrentCellEndEditEventArgs> OnListDataGridCurrentCellEndEdit;
      event EventHandler<PreviewKeyDownEventArgs> OnListDataGridPreviewKeyDown;

      ListDataGrid ListDataGrid { get; }
   }
}
