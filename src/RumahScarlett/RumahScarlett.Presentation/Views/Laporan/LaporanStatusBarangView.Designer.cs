namespace RumahScarlett.Presentation.Views.Laporan
{
   partial class LaporanStatusBarangView
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
         this.dateTimePickerFilterTransaksi = new RumahScarlett.Presentation.Views.CommonControls.DateTimePickerFilterTransaksi();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.buttonTutup = new System.Windows.Forms.Button();
         this.buttonCetak = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.tableLayoutPanel1.SuspendLayout();
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
         this.listDataGrid.Size = new System.Drawing.Size(760, 235);
         this.listDataGrid.TabIndex = 1;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // dateTimePickerFilterTransaksi
         // 
         this.dateTimePickerFilterTransaksi.Location = new System.Drawing.Point(12, 58);
         this.dateTimePickerFilterTransaksi.Name = "dateTimePickerFilterTransaksi";
         this.dateTimePickerFilterTransaksi.Size = new System.Drawing.Size(446, 115);
         this.dateTimePickerFilterTransaksi.TabIndex = 2;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.buttonTutup, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.buttonCetak, 0, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 420);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 30);
         this.tableLayoutPanel1.TabIndex = 3;
         // 
         // buttonTutup
         // 
         this.buttonTutup.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonTutup.Location = new System.Drawing.Point(682, 3);
         this.buttonTutup.Name = "buttonTutup";
         this.buttonTutup.Size = new System.Drawing.Size(75, 23);
         this.buttonTutup.TabIndex = 100;
         this.buttonTutup.Text = "&Tutup";
         this.buttonTutup.UseVisualStyleBackColor = true;
         this.buttonTutup.Click += new System.EventHandler(this.buttonTutup_Click);
         // 
         // buttonCetak
         // 
         this.buttonCetak.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonCetak.Location = new System.Drawing.Point(3, 3);
         this.buttonCetak.Name = "buttonCetak";
         this.buttonCetak.Size = new System.Drawing.Size(75, 23);
         this.buttonCetak.TabIndex = 99;
         this.buttonCetak.Text = "&Cetak";
         this.buttonCetak.UseVisualStyleBackColor = true;
         this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
         // 
         // LaporanStatusBarangView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.dateTimePickerFilterTransaksi);
         this.Controls.Add(this.listDataGrid);
         this.Name = "LaporanStatusBarangView";
         this.Text = "Laporan Status Barang";
         this.Load += new System.EventHandler(this.LaporanStatusBarangView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.dateTimePickerFilterTransaksi, 0);
         this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.ListDataGrid listDataGrid;
      private CommonControls.DateTimePickerFilterTransaksi dateTimePickerFilterTransaksi;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Button buttonTutup;
      private System.Windows.Forms.Button buttonCetak;
   }
}