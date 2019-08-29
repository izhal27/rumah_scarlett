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
using RumahScarlett.Presentation.Views.Tipe;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class OperationButtons : UserControl
   {
      public event EventHandler OnSaveButtonClick;
      public event EventHandler OnCloseButtonClick;

      public OperationButtons()
      {
         InitializeComponent();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnSaveButtonClick, e);
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCloseButtonClick, e);
      }
   }
}
