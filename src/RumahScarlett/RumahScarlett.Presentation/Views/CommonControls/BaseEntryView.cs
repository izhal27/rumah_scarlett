using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class BaseEntryView : Form
   {
      public BaseEntryView()
      {
         InitializeComponent();
         ActiveControl = operationButtons.ButtonCancel;
      }

      protected virtual void BaseEntryView_Load(object sender, EventArgs e)
      {

      }
   }
}
