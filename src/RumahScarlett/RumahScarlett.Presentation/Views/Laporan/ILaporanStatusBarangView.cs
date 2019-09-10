using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views.Laporan
{
   public interface ILaporanStatusBarangView : IView
   {
      event EventHandler OnFormLoad;
      event EventHandler OnButtonCetakClick;
      event EventHandler<FilterDateEventArgs> OnButtonTampilkanClick;

      DateTimePickerFilterTransaksi DateTimePickerFilterTransaksi { get; }
      ListDataGrid ListDataGrid { get; }
   }
}
