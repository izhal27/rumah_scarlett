using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public class ListDataGrid : SfDataGrid
   {
      public ListDataGrid()
      {
         AllowEditing = false;
         AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
         Anchor = AnchorStyles.Top | AnchorStyles.Right |
                  AnchorStyles.Bottom | AnchorStyles.Left;

         QueryRowStyle += ListDataGrid_QueryRowStyle;
      }

      private void ListDataGrid_QueryRowStyle(object sender, QueryRowStyleEventArgs e)
      {
         if (e.RowType == RowType.DefaultRow && e.RowIndex % 2 == 0)
            e.Style.BackColor = Color.FromArgb(240, 248, 255);
         else
            e.Style.BackColor = Color.FromArgb(255, 255, 255);
      }
   }
}
