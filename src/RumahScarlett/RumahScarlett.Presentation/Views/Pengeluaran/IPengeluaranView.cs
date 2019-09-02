using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Pengeluaran
{
   public interface IPengeluaranView : IDataView
   {
      DateTimePicker DateTimePickerTanggal { get; }
      Label LabelTotal { get; }
   }
}
