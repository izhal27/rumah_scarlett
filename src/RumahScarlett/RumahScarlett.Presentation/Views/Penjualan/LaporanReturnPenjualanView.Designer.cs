﻿namespace RumahScarlett.Presentation.Views.Penjualan
{
   partial class LaporanReturnPenjualanView
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.listDataGrid = new RumahScarlett.Presentation.Views.CommonControls.ListDataGrid();
         this.buttonsDeletePrintDetail = new RumahScarlett.Presentation.Views.CommonControls.ButtonsDeletePrintDetail();
         this.dateTimePickerFilterTransaksi = new RumahScarlett.Presentation.Views.CommonControls.DateTimePickerFilterTransaksi();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.AllowEditing = false;
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 179);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.ShowRowHeader = true;
         this.listDataGrid.Size = new System.Drawing.Size(760, 230);
         this.listDataGrid.TabIndex = 1;
         this.listDataGrid.Text = "listDataGrid1";
         this.listDataGrid.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.listDataGrid_CellDoubleClick);
         // 
         // buttonsDeletePrintDetail
         // 
         this.buttonsDeletePrintDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonsDeletePrintDetail.Location = new System.Drawing.Point(12, 415);
         this.buttonsDeletePrintDetail.Name = "buttonsDeletePrintDetail";
         this.buttonsDeletePrintDetail.Size = new System.Drawing.Size(760, 35);
         this.buttonsDeletePrintDetail.TabIndex = 2;
         // 
         // dateTimePickerFilterTransaksi
         // 
         this.dateTimePickerFilterTransaksi.Location = new System.Drawing.Point(12, 58);
         this.dateTimePickerFilterTransaksi.Name = "dateTimePickerFilterTransaksi";
         this.dateTimePickerFilterTransaksi.Size = new System.Drawing.Size(446, 115);
         this.dateTimePickerFilterTransaksi.TabIndex = 3;
         // 
         // LaporanReturnPenjualanView
         // 
         this.AccessibleName = "Laporan";
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.dateTimePickerFilterTransaksi);
         this.Controls.Add(this.buttonsDeletePrintDetail);
         this.Controls.Add(this.listDataGrid);
         this.Name = "LaporanReturnPenjualanView";
         this.Text = "Laporan Return Penjualan";
         this.Load += new System.EventHandler(this.LaporanReturnPenjualanView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.buttonsDeletePrintDetail, 0);
         this.Controls.SetChildIndex(this.dateTimePickerFilterTransaksi, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.ListDataGrid listDataGrid;
      private CommonControls.ButtonsDeletePrintDetail buttonsDeletePrintDetail;
      private CommonControls.DateTimePickerFilterTransaksi dateTimePickerFilterTransaksi;
   }
}