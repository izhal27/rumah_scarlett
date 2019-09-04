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
      protected event EventHandler OnEnterKeyDown;

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

               listDataGrid.ClearSelection();
               textBoxPencarian.SelectAll();
               textBoxPencarian.Focus();

               break;
            case Keys.Up:
            case Keys.Down:

               if (textBoxPencarian.Focused)
               {
                  listDataGrid.SelectedIndex = 0;
               }

               break;
            case Keys.Enter:

               OnEnterKeyDown?.Invoke(sender, e);

               break;
            case Keys.Escape:

               Close();

               break;
         }
      }
   }
}
