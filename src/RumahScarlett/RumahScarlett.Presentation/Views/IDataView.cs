using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IDataView : IView
   {
      event EventHandler OnLoadDataEvent;
      event EventHandler OnCreateDataEvent;
      event EventHandler OnUpdateDataEvent;
      event EventHandler OnDeleteDataEvent;
      event EventHandler OnRefreshDataEvent;
      event EventHandler OnPrintDataEvent;
      ListDataGrid ListDataGrid { get; }
   }
}
