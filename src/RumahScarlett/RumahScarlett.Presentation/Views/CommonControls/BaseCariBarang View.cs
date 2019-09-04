using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
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
   public partial class BaseCariBarangView : Form
   {
      public BaseCariBarangView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "CARI BARANG";
      }

      protected virtual void ShowView()
      {
         ShowDialog();
      }

      protected virtual void textBoxPencarian_TextChanged(object sender, EventArgs e)
      {

      }

      private void BaseCariBarangView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2:

               if (!textBoxPencarian.Focused)
               {
                  textBoxPencarian.Focus();
               }

               break;
            case Keys.Down:

               if (listDataGrid.RowCount > 0 && listDataGrid.SelectedIndex == -1)
               {
                  listDataGrid.SelectedIndex = 0;
               }
               else
               {
                  if (listDataGrid.SelectedIndex > 0)
                  {
                     listDataGrid.SelectedIndex = -1;
                  }
               }

               break;
            case Keys.Escape:

               Close();

               break;
         }
      }
   }
}
