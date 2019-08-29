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
   public partial class OperationButtons : UserControl
   {
      public event EventHandler OnSaveButtonClick;

      public OperationButtons()
      {
         InitializeComponent();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnSaveButtonClick, e);
      }
   }
}
