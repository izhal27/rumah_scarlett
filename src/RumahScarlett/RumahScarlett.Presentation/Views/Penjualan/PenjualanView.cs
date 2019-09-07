﻿using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RumahScarlett.Presentation.Views.ModelControls;

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public partial class PenjualanView : BaseDataView, IPenjualanView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnCariData;
      public event EventHandler OnHapusData;
      public event EventHandler OnBayarPenjualan;
      public event EventHandler OnBersihkanData;
      public event EventHandler<CurrentCellKeyEventArgs> OnListDataGridCurrentCellKeyDown;
      public event EventHandler<CurrentCellActivatedEventArgs> OnListDataGridCurrentCellActivated;
      public event EventHandler<CurrentCellEndEditEventArgs> OnListDataGridCurrentCellEndEdit;
      public event EventHandler<PreviewKeyDownEventArgs> OnListDataGridPreviewKeyDown;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }
      
      public TextBox TextBoxNoNota
      {
         get { return textBoxNoNota; }
      }

      public PenjualanView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "TRANSAKSI PENJUALAN BARANG";

         listDataGrid.EditMode = EditMode.SingleClick;
         listDataGrid.AllowEditing = true;
         listDataGrid.AllowSorting = false;

         listDataGrid.CurrentCellActivated += ListDataGrid_CurrentCellActivated;
         listDataGrid.CurrentCellEndEdit += ListDataGrid_CurrentCellEndEdit;
         listDataGrid.PreviewKeyDown += ListDataGrid_PreviewKeyDown;
         listDataGrid.CurrentCellKeyDown += ListDataGrid_CurrentCellKeyDown;
      }

      private void PenjualanView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void PenjualanView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2: // Cari

               OnCariData?.Invoke(sender, e);

               break;
            case Keys.F3: // Hapus

               OnHapusData?.Invoke(sender, e);

               break;
            case Keys.F4: // Bayar

               OnBayarPenjualan?.Invoke(sender, e);

               break;
            case Keys.F5: // Bersihkan

               OnBersihkanData?.Invoke(sender, e);

               break;
            case Keys.F12: // Tutup

               Close();

               break;
         }
      }

      private void ListDataGrid_CurrentCellKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         OnListDataGridCurrentCellKeyDown?.Invoke(sender, e);
      }

      private void ListDataGrid_CurrentCellActivated(object sender, CurrentCellActivatedEventArgs e)
      {
         OnListDataGridCurrentCellActivated?.Invoke(sender, e);
      }

      private void ListDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
      {
         OnListDataGridCurrentCellEndEdit?.Invoke(sender, e);
      }

      private void ListDataGrid_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         OnListDataGridPreviewKeyDown?.Invoke(sender, e);
      }
   }
}
