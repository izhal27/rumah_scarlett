using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RumahScarlett.CommonComponents;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class NavigationEntryButtons : UserControl
   {
      public event EventHandler OnFirstClick;
      public event EventHandler OnReverseClick;
      public event EventHandler OnNextClick;
      public event EventHandler OnLastClick;

      public NavigationEntryButtons()
      {
         InitializeComponent();
      }

      private void btnFirst_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnFirstClick, e);
      }

      private void btnReverse_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnReverseClick, e);
      }

      private void btnNext_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnNextClick, e);
      }

      private void btnLast_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnLastClick, e);
      }
   }
}
