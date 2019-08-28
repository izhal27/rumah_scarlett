using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views.Tipe
{
   public interface ISubTipeView : IView
   {
      ListDataGrid ListDataGrid { get; }
   }
}
