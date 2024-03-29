﻿using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
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

         listDataGrid.CurrentCellKeyDown += ListDataGrid_CurrentCellKeyDown;
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

      private void ListDataGrid_CurrentCellKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         if (e.KeyEventArgs.KeyCode == Keys.Enter)
         {
            e.KeyEventArgs.Handled = true;
         }
      }

      private void listDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         OnEnterKeyDown?.Invoke(sender, e);
      }

      protected virtual void textBoxPencarian_TextChanged(object sender, EventArgs e)
      {

      }

      protected virtual void ShowView()
      {
         ShowDialog();
      }
   }
}
