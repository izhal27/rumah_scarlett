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
   public partial class PanelUp : UserControl
   {
      public string LabelInfo
      {
         get { return lblInfo.Text; }
         set { lblInfo.Text = value.Trim(); }
      }

      public PanelUp()
      {
         InitializeComponent();
         TabStop = false;
      }
   }
}
