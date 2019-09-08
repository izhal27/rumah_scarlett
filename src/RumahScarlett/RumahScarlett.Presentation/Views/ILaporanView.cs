using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface ILaporanView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnDeleteData;
      event EventHandler OnPrintData;
      event EventHandler OnDetailClick;
      event EventHandler OnTampilkanClick;

      DateTimePickerFilterTransaksi DateTimePickerFilterTransaksi { get; }
      ListDataGrid ListDataGrid { get; }
   }
}
