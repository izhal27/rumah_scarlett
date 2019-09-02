using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.HutangOperasional
{
   public interface IHutangOperasionalView : IDataView
   {
      Label LabelTotal { get; }
      Label LabelLunas { get; }
      Label LabelBelumLunas { get; }
   }
}
