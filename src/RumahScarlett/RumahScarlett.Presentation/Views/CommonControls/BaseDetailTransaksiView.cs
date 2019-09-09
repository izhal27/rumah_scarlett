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
   public partial class BaseDetailTransaksiView : BaseDataView
   {
      public event EventHandler OnCetakClick;
      public event EventHandler OnLoadView;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public BaseDetailTransaksiView(string textTitle, bool buttonCetakVisible = true)
      {
         InitializeComponent();

         Text = textTitle;
         panelUp.LabelInfo = $"{Text.ToUpper()}";
         buttonCetak.Visible = buttonCetakVisible;
      }

      private void BaseDetailTransaksiView_Load(object sender, EventArgs e)
      {
         OnLoadView?.Invoke(sender, e);
      }
      
      private void BaseDetailTransaksiView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.Escape:

               Close();

               break;
         }
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnCetakClick?.Invoke(sender, e);
      }

      private void buttonTutup_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
