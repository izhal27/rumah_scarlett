namespace RumahScarlett.Presentation.Views.Pembelian
{
   partial class SimpanPembelianEntryView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpanPembelianEntryView));
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.buttonSimpan = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.panelUp = new RumahScarlett.Presentation.Views.CommonControls.PanelUp();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label24 = new System.Windows.Forms.Label();
         this.textBoxTanggal = new RumahScarlett.Presentation.Views.CommonControls.TextBoxTanggal();
         this.label25 = new System.Windows.Forms.Label();
         this.label28 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.textBoxGrandTotal = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.label11 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.textBoxTotalItem = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.textBoxTotalQty = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.comboBoxSupplier = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxSupplier();
         this.tlpButtons.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTanggal)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxGrandTotal)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTotalItem)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTotalQty)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpButtons
         // 
         this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.tlpButtons.BackColor = System.Drawing.SystemColors.Control;
         this.tlpButtons.ColumnCount = 2;
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.Controls.Add(this.buttonSimpan, 0, 0);
         this.tlpButtons.Controls.Add(this.btnCancel, 1, 0);
         this.tlpButtons.Location = new System.Drawing.Point(74, 239);
         this.tlpButtons.Name = "tlpButtons";
         this.tlpButtons.RowCount = 1;
         this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.Size = new System.Drawing.Size(200, 35);
         this.tlpButtons.TabIndex = 105;
         // 
         // buttonSimpan
         // 
         this.buttonSimpan.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonSimpan.Location = new System.Drawing.Point(22, 6);
         this.buttonSimpan.Name = "buttonSimpan";
         this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
         this.buttonSimpan.TabIndex = 99;
         this.buttonSimpan.Tag = "ignore";
         this.buttonSimpan.Text = "(F3) &Simpan";
         this.buttonSimpan.UseVisualStyleBackColor = true;
         this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(103, 6);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 100;
         this.btnCancel.Tag = "ignore";
         this.btnCancel.Text = "(F12) &Batal";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // panelUp
         // 
         this.panelUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panelUp.LabelInfo = "Info";
         this.panelUp.Location = new System.Drawing.Point(12, 12);
         this.panelUp.Name = "panelUp";
         this.panelUp.Size = new System.Drawing.Size(262, 40);
         this.panelUp.TabIndex = 104;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(262, 175);
         this.groupBox1.TabIndex = 103;
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
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label24, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.textBoxTanggal, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label25, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label28, 1, 4);
         this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
         this.tableLayoutPanel1.Controls.Add(this.textBoxGrandTotal, 2, 4);
         this.tableLayoutPanel1.Controls.Add(this.label11, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.label12, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.label14, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.label15, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.textBoxTotalItem, 2, 2);
         this.tableLayoutPanel1.Controls.Add(this.textBoxTotalQty, 2, 3);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxSupplier, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 5;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 150);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 8);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tanggal";
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 38);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(66, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Supplier (F2)";
         // 
         // label24
         // 
         this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label24.AutoSize = true;
         this.label24.Location = new System.Drawing.Point(75, 8);
         this.label24.Name = "label24";
         this.label24.Size = new System.Drawing.Size(10, 13);
         this.label24.TabIndex = 0;
         this.label24.Text = ":";
         // 
         // textBoxTanggal
         // 
         this.textBoxTanggal.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxTanggal.BeforeTouchSize = new System.Drawing.Size(150, 20);
         this.textBoxTanggal.Location = new System.Drawing.Point(91, 5);
         this.textBoxTanggal.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxTanggal.Name = "textBoxTanggal";
         this.textBoxTanggal.ReadOnly = true;
         this.textBoxTanggal.Size = new System.Drawing.Size(150, 20);
         this.textBoxTanggal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxTanggal.TabIndex = 1;
         this.textBoxTanggal.TabStop = false;
         this.textBoxTanggal.Text = "07/09/2019";
         // 
         // label25
         // 
         this.label25.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label25.AutoSize = true;
         this.label25.Location = new System.Drawing.Point(75, 38);
         this.label25.Name = "label25";
         this.label25.Size = new System.Drawing.Size(10, 13);
         this.label25.TabIndex = 0;
         this.label25.Text = ":";
         // 
         // label28
         // 
         this.label28.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label28.AutoSize = true;
         this.label28.Location = new System.Drawing.Point(75, 128);
         this.label28.Name = "label28";
         this.label28.Size = new System.Drawing.Size(10, 13);
         this.label28.TabIndex = 0;
         this.label28.Text = ":";
         // 
         // label7
         // 
         this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(3, 128);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(63, 13);
         this.label7.TabIndex = 0;
         this.label7.Text = "Grand Total";
         // 
         // textBoxGrandTotal
         // 
         this.textBoxGrandTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxGrandTotal.BeforeTouchSize = new System.Drawing.Size(150, 20);
         this.textBoxGrandTotal.Location = new System.Drawing.Point(91, 125);
         this.textBoxGrandTotal.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxGrandTotal.Name = "textBoxGrandTotal";
         this.textBoxGrandTotal.ReadOnly = true;
         this.textBoxGrandTotal.Size = new System.Drawing.Size(150, 20);
         this.textBoxGrandTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxGrandTotal.TabIndex = 11;
         this.textBoxGrandTotal.TabStop = false;
         this.textBoxGrandTotal.Text = "0";
         this.textBoxGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label11
         // 
         this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(75, 68);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(10, 13);
         this.label11.TabIndex = 0;
         this.label11.Text = ":";
         // 
         // label12
         // 
         this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(75, 98);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(10, 13);
         this.label12.TabIndex = 0;
         this.label12.Text = ":";
         // 
         // label14
         // 
         this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(3, 68);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(54, 13);
         this.label14.TabIndex = 0;
         this.label14.Text = "Total Item";
         // 
         // label15
         // 
         this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(3, 98);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(50, 13);
         this.label15.TabIndex = 0;
         this.label15.Text = "Total Qty";
         // 
         // textBoxTotalItem
         // 
         this.textBoxTotalItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxTotalItem.BeforeTouchSize = new System.Drawing.Size(150, 20);
         this.textBoxTotalItem.Location = new System.Drawing.Point(91, 65);
         this.textBoxTotalItem.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxTotalItem.Name = "textBoxTotalItem";
         this.textBoxTotalItem.ReadOnly = true;
         this.textBoxTotalItem.Size = new System.Drawing.Size(150, 20);
         this.textBoxTotalItem.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxTotalItem.TabIndex = 11;
         this.textBoxTotalItem.TabStop = false;
         this.textBoxTotalItem.Text = "0";
         this.textBoxTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // textBoxTotalQty
         // 
         this.textBoxTotalQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxTotalQty.BeforeTouchSize = new System.Drawing.Size(150, 20);
         this.textBoxTotalQty.Location = new System.Drawing.Point(91, 95);
         this.textBoxTotalQty.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxTotalQty.Name = "textBoxTotalQty";
         this.textBoxTotalQty.ReadOnly = true;
         this.textBoxTotalQty.Size = new System.Drawing.Size(150, 20);
         this.textBoxTotalQty.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxTotalQty.TabIndex = 11;
         this.textBoxTotalQty.TabStop = false;
         this.textBoxTotalQty.Text = "0";
         this.textBoxTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // comboBoxSupplier
         // 
         this.comboBoxSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxSupplier.Location = new System.Drawing.Point(91, 34);
         this.comboBoxSupplier.Name = "comboBoxSupplier";
         this.comboBoxSupplier.Size = new System.Drawing.Size(150, 21);
         this.comboBoxSupplier.TabIndex = 13;
         // 
         // SimpanPembelianEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(286, 286);
         this.Controls.Add(this.tlpButtons);
         this.Controls.Add(this.panelUp);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SimpanPembelianEntryView";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Bayar Pembelian";
         this.Load += new System.EventHandler(this.SimpanPembelianEntryView_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SimpanPembelianEntryView_KeyDown);
         this.tlpButtons.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTanggal)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxGrandTotal)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTotalItem)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTotalQty)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.TableLayoutPanel tlpButtons;
      protected System.Windows.Forms.Button buttonSimpan;
      protected System.Windows.Forms.Button btnCancel;
      private CommonControls.PanelUp panelUp;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label24;
      private CommonControls.TextBoxTanggal textBoxTanggal;
      private System.Windows.Forms.Label label25;
      private System.Windows.Forms.Label label28;
      private System.Windows.Forms.Label label7;
      private CommonControls.BaseTextBox textBoxGrandTotal;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label label15;
      private CommonControls.BaseTextBox textBoxTotalItem;
      private CommonControls.BaseTextBox textBoxTotalQty;
      private ModelControls.ComboBoxSupplier comboBoxSupplier;
   }
}