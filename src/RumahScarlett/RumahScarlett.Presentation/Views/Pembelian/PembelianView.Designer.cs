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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PembelianView));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.comboBoxSupplier = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxSupplier();
         this.listDataGrid = new RumahScarlett.Presentation.Views.CommonControls.ListDataGrid();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label5 = new System.Windows.Forms.Label();
         this.labelTotalQty = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.labelTotalPembelian = new System.Windows.Forms.Label();
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
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(221, 60);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ DATA ]";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxSupplier, 1, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(209, 35);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 11);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Supplier";
         // 
         // comboBoxSupplier
         // 
         this.comboBoxSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxSupplier.DisplayMember = "Value";
         this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxSupplier.FormattingEnabled = true;
         this.comboBoxSupplier.Items.AddRange(new object[] {
            ((object)(resources.GetObject("comboBoxSupplier.Items"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items1"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items2"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items3"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items4"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items5"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items6"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items7"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items8"))),
            ((object)(resources.GetObject("comboBoxSupplier.Items9")))});
         this.comboBoxSupplier.Location = new System.Drawing.Point(54, 7);
         this.comboBoxSupplier.Name = "comboBoxSupplier";
         this.comboBoxSupplier.Size = new System.Drawing.Size(150, 21);
         this.comboBoxSupplier.TabIndex = 1;
         this.comboBoxSupplier.ValueMember = "Key";
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 124);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.ShowRowHeader = true;
         this.listDataGrid.Size = new System.Drawing.Size(534, 295);
         this.listDataGrid.TabIndex = 2;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.tableLayoutPanel2);
         this.groupBox2.Location = new System.Drawing.Point(552, 124);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(220, 85);
         this.groupBox2.TabIndex = 5;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "[ RINGKASAN ]";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel2.ColumnCount = 3;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.labelTotalQty, 2, 0);
         this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.label3, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.labelTotalPembelian, 2, 1);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 2;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 60);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(3, 8);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(50, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Total Qty";
         // 
         // labelTotalQty
         // 
         this.labelTotalQty.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelTotalQty.AutoSize = true;
         this.labelTotalQty.Location = new System.Drawing.Point(192, 8);
         this.labelTotalQty.Name = "labelTotalQty";
         this.labelTotalQty.Size = new System.Drawing.Size(13, 13);
         this.labelTotalQty.TabIndex = 1;
         this.labelTotalQty.Text = "0";
         // 
         // label6
         // 
         this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(92, 8);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(10, 13);
         this.label6.TabIndex = 0;
         this.label6.Text = ":";
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 38);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(83, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Total Pembelian";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(92, 38);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(10, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = ":";
         // 
         // labelTotalPembelian
         // 
         this.labelTotalPembelian.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelTotalPembelian.AutoSize = true;
         this.labelTotalPembelian.Location = new System.Drawing.Point(192, 38);
         this.labelTotalPembelian.Name = "labelTotalPembelian";
         this.labelTotalPembelian.Size = new System.Drawing.Size(13, 13);
         this.labelTotalPembelian.TabIndex = 1;
         this.labelTotalPembelian.Text = "0";
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.tableLayoutPanel3.ColumnCount = 9;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.label7, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.label8, 2, 0);
         this.tableLayoutPanel3.Controls.Add(this.label9, 3, 0);
         this.tableLayoutPanel3.Controls.Add(this.label10, 4, 0);
         this.tableLayoutPanel3.Controls.Add(this.label11, 5, 0);
         this.tableLayoutPanel3.Controls.Add(this.label12, 6, 0);
         this.tableLayoutPanel3.Controls.Add(this.label13, 7, 0);
         this.tableLayoutPanel3.Controls.Add(this.label14, 8, 0);
         this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 425);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 1;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(534, 25);
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
         this.label12.Size = new System.Drawing.Size(50, 13);
         this.label12.TabIndex = 0;
         this.label12.Text = "F5 Reset";
         // 
         // label13
         // 
         this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(272, 6);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(9, 13);
         this.label13.TabIndex = 0;
         this.label13.Text = "|";
         // 
         // label14
         // 
         this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(287, 6);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(56, 13);
         this.label14.TabIndex = 0;
         this.label14.Text = "F12 Tutup";
         // 
         // PembelianView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.listDataGrid);
         this.Controls.Add(this.groupBox1);
         this.KeyPreview = true;
         this.Name = "PembelianView";
         this.Text = "Pembelian";
         this.Load += new System.EventHandler(this.PembelianView_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PembelianView_KeyDown);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.groupBox2, 0);
         this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private ModelControls.ComboBoxSupplier comboBoxSupplier;
      private CommonControls.ListDataGrid listDataGrid;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label labelTotalQty;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label labelTotalPembelian;
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
   }
}