using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class PanelInfoDigital : UserControl
   {
      public Label LabelInfo
      {
         get { return labelInfo; }
      }

      public PanelInfoDigital()
      {
         InitializeComponent();
      }
   }
}
