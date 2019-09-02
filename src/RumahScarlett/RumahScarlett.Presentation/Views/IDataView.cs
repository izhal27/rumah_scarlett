using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IDataView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnCreateData;
      event EventHandler OnUpdateData;
      event EventHandler OnDeleteData;
      event EventHandler OnRefreshData;
      event EventHandler OnPrintData;
      event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;

      ListDataGrid ListDataGrid { get; }
   }
}
