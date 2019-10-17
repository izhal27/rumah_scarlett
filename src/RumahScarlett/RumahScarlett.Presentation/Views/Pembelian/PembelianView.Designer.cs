namespace RumahScarlett.Presentation.Views.Pembelian
{
   partial class PembelianView
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label18 = new System.Windows.Forms.Label();
         this.textBoxNoNota = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.label21 = new System.Windows.Forms.Label();
         this.listDataGrid = new RumahScarlett.Presentation.Views.CommonControls.ListDataGrid();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.label4 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.label16 = new System.Windows.Forms.Label();
         this.panelInfoDigital = new RumahScarlett.Presentation.Views.CommonControls.PanelInfoDigital();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxNoNota)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.tableLayoutPanel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(241, 55);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ DATA ]";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.label18, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.textBoxNoNota, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label21, 1, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 30);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label18
         // 
         this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label18.AutoSize = true;
         this.label18.Location = new System.Drawing.Point(3, 8);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(47, 13);
         this.label18.TabIndex = 0;
         this.label18.Text = "No Nota";
         // 
         // textBoxNoNota
         // 
         this.textBoxNoNota.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxNoNota.BeforeTouchSize = new System.Drawing.Size(148, 20);
         this.textBoxNoNota.Location = new System.Drawing.Point(72, 5);
         this.textBoxNoNota.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxNoNota.Name = "textBoxNoNota";
         this.textBoxNoNota.ReadOnly = true;
         this.textBoxNoNota.Size = new System.Drawing.Size(148, 20);
         this.textBoxNoNota.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxNoNota.TabIndex = 8;
         this.textBoxNoNota.TabStop = false;
         // 
         // label21
         // 
         this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label21.AutoSize = true;
         this.label21.Location = new System.Drawing.Point(56, 8);
         this.label21.Name = "label21";
         this.label21.Size = new System.Drawing.Size(10, 13);
         this.label21.TabIndex = 0;
         this.label21.Text = ":";
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.AllowEditing = false;
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 119);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.ShowRowHeader = true;
         this.listDataGrid.Size = new System.Drawing.Size(760, 300);
         this.listDataGrid.TabIndex = 2;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel3.ColumnCount = 11;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333F));
         this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.label7, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.label8, 2, 0);
         this.tableLayoutPanel3.Controls.Add(this.label9, 3, 0);
         this.tableLayoutPanel3.Controls.Add(this.label10, 4, 0);
         this.tableLayoutPanel3.Controls.Add(this.label11, 5, 0);
         this.tableLayoutPanel3.Controls.Add(this.label12, 6, 0);
         this.tableLayoutPanel3.Controls.Add(this.label13, 7, 0);
         this.tableLayoutPanel3.Controls.Add(this.label14, 8, 0);
         this.tableLayoutPanel3.Controls.Add(this.label15, 9, 0);
         this.tableLayoutPanel3.Controls.Add(this.label16, 10, 0);
         this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 425);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 1;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(760, 25);
         this.tableLayoutPanel3.TabIndex = 6;
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 6);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "F2 Cari";
         // 
         // label7
         // 
         this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(49, 6);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(9, 13);
         this.label7.TabIndex = 0;
         this.label7.Text = "|";
         // 
         // label8
         // 
         this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(64, 6);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(53, 13);
         this.label8.TabIndex = 0;
         this.label8.Text = "F3 Hapus";
         // 
         // label9
         // 
         this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(123, 6);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(9, 13);
         this.label9.TabIndex = 0;
         this.label9.Text = "|";
         // 
         // label10
         // 
         this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(138, 6);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(57, 13);
         this.label10.TabIndex = 0;
         this.label10.Text = "F4 Simpan";
         // 
         // label11
         // 
         this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(201, 6);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(9, 13);
         this.label11.TabIndex = 0;
         this.label11.Text = "|";
         // 
         // label12
         // 
         this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(216, 6);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(93, 13);
         this.label12.TabIndex = 0;
         this.label12.Text = "F5 Bersihkan data";
         // 
         // label13
         // 
         this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(315, 6);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(9, 13);
         this.label13.TabIndex = 0;
         this.label13.Text = "|";
         // 
         // label14
         // 
         this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(330, 6);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(74, 13);
         this.label14.TabIndex = 0;
         this.label14.Text = "F6 Cetak nota";
         // 
         // label15
         // 
         this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(410, 6);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(9, 13);
         this.label15.TabIndex = 0;
         this.label15.Text = "|";
         // 
         // label16
         // 
         this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label16.AutoSize = true;
         this.label16.Location = new System.Drawing.Point(430, 6);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(56, 13);
         this.label16.TabIndex = 0;
         this.label16.Text = "F12 Tutup";
         // 
         // panelInfoDigital
         // 
         this.panelInfoDigital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.panelInfoDigital.BackColor = System.Drawing.Color.Black;
         this.panelInfoDigital.Location = new System.Drawing.Point(372, 58);
         this.panelInfoDigital.Name = "panelInfoDigital";
         this.panelInfoDigital.Size = new System.Drawing.Size(400, 55);
         this.panelInfoDigital.TabIndex = 7;
         // 
         // PembelianView
         // 
         this.AccessibleName = "Transaksi";
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.panelInfoDigital);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.listDataGrid);
         this.Controls.Add(this.groupBox1);
         this.KeyPreview = true;
         this.Name = "PembelianView";
         this.Text = "Pembelian Barang";
         this.Load += new System.EventHandler(this.PembelianView_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PembelianView_KeyDown);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
         this.Controls.SetChildIndex(this.panelInfoDigital, 0);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxNoNota)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private CommonControls.ListDataGrid listDataGrid;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label label18;
      private CommonControls.BaseTextBox textBoxNoNota;
      private System.Windows.Forms.Label label21;
      private CommonControls.PanelInfoDigital panelInfoDigital;
   }
}