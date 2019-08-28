using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Tipe
{
   public partial class SubTipeView : BaseDataView, ISubTipeView
   {
      public ListDataGrid ListDataGrid
      {
         get
         {
            return listDataGrid;
         }
      }

      public SubTipeView()
      {
         InitializeComponent();
         panelUp.LabelInfo = "SUB TIPE";
      }
   }
}
