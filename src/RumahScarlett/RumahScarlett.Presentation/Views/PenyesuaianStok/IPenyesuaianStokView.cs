using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.PenyesuaianStok
{
   public interface IPenyesuaianStokView : IDataView
   {
      Label LabelTotalQty { get; }
      Label LabelTotalHpp { get; }
      event EventHandler OnTampilkanClick;
   }
}
