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
using System.Windows.Forms.VisualStyles;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public class ListDataGrid : SfDataGrid
   {
      public ListDataGrid()
      {
         ShowRowHeader = true;
         AllowEditing = false;
         AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
         Anchor = AnchorStyles.Top | AnchorStyles.Right |
                  AnchorStyles.Bottom | AnchorStyles.Left;

         DrawCell += ListDataGrid_DrawCell;
         QueryRowStyle += ListDataGrid_QueryRowStyle;
      }

      private void ListDataGrid_DrawCell(object sender, DrawCellEventArgs e)
      {
         if (ShowRowHeader && e != null && e.RowIndex != 0)
         {
            if (e.ColumnIndex == 0)
            {
               e.DisplayText = e.RowIndex.ToString();
               e.Style.TextColor = Color.Black;
               e.Style.VerticalAlignment = VerticalAlignment.Center;
               e.Style.HorizontalAlignment = HorizontalAlignment.Center;
            }
         }
      }

      private void ListDataGrid_QueryRowStyle(object sender, QueryRowStyleEventArgs e)
      {
         if (e.RowType == RowType.DefaultRow && e.RowIndex % 2 == 0)
            e.Style.BackColor = MainProgram.Pengaturan.warna_baris_genap;
         else
            e.Style.BackColor = MainProgram.Pengaturan.warna_baris_ganjil;
      }
   }
}
