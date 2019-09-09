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
   public partial class ButtonsDeletePrintDetail : UserControl
   {
      public event EventHandler OnHapusClick;
      public event EventHandler OnCetakClick;
      public event EventHandler OnDetailClick;
      public event EventHandler OnTutupClick;

      public bool ButtonHapusVisible
      {
         set { buttonHapus.Visible = value; }
      }

      public bool ButtonCetakVisible
      {
         set { buttonCetak.Visible = value; }
      }

      public bool ButtonDetailVisible
      {
         set { buttonDetail.Visible = value; }
      }

      public ButtonsDeletePrintDetail()
      {
         InitializeComponent();
      }

      private void buttonHapus_Click(object sender, EventArgs e)
      {
         OnHapusClick?.Invoke(sender, e);
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnCetakClick?.Invoke(sender, e);
      }

      private void buttonDetail_Click(object sender, EventArgs e)
      {
         OnDetailClick?.Invoke(sender, e);
      }

      private void buttonTutup_Click(object sender, EventArgs e)
      {
         OnTutupClick?.Invoke(sender, e);
      }
   }
}
