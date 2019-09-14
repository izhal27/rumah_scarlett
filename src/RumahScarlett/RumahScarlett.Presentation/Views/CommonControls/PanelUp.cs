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
         get { return labelInfo.Text; }
         set { labelInfo.Text = value.Trim(); }
      }

      public PanelUp()
      {
         InitializeComponent();
         TabStop = false;
      }

      protected override void OnCreateControl()
      {
         base.OnCreateControl();
         //panelInfo.BackColor = MainProgram.Pengaturan.warna_backgroud_strip;
         //labelInfo.ForeColor = MainProgram.Pengaturan.warna_teks_strip;
      }
   }
}
