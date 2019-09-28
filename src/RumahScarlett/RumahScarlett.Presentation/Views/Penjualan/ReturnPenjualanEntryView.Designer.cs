namespace RumahScarlett.Presentation.Views.Penjualan
{
   partial class ReturnPenjualanEntryView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnPenjualanEntryView));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.labelMax = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.comboBoxBarang = new System.Windows.Forms.ComboBox();
         this.comboBoxStatus = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.buttonOk = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.textBoxQty = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBoxDigit();
         this.textBoxKeterangan = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.panelUp = new RumahScarlett.Presentation.Views.CommonControls.PanelUp();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tlpButtons.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxQty)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(362, 230);
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
         this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxBarang, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxStatus, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.textBoxKeterangan, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
         this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 205);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.textBoxQty, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.labelMax, 1, 0);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(71, 30);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 30);
         this.tableLayoutPanel2.TabIndex = 103;
         // 
         // labelMax
         // 
         this.labelMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.labelMax.AutoSize = true;
         this.labelMax.Location = new System.Drawing.Point(109, 8);
         this.labelMax.Name = "labelMax";
         this.labelMax.Size = new System.Drawing.Size(27, 13);
         this.labelMax.TabIndex = 0;
         this.labelMax.Text = "Max";
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.ForeColor = System.Drawing.Color.Red;
         this.label4.Location = new System.Drawing.Point(327, 7);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(11, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "*";
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 7);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(41, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Barang";
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 70);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(37, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Status";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 141);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Keterangan";
         // 
         // comboBoxBarang
         // 
         this.comboBoxBarang.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxBarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxBarang.FormattingEnabled = true;
         this.comboBoxBarang.Location = new System.Drawing.Point(71, 3);
         this.comboBoxBarang.Name = "comboBoxBarang";
         this.comboBoxBarang.Size = new System.Drawing.Size(250, 21);
         this.comboBoxBarang.TabIndex = 0;
         // 
         // comboBoxStatus
         // 
         this.comboBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxStatus.FormattingEnabled = true;
         this.comboBoxStatus.Location = new System.Drawing.Point(71, 66);
         this.comboBoxStatus.Name = "comboBoxStatus";
         this.comboBoxStatus.Size = new System.Drawing.Size(250, 21);
         this.comboBoxStatus.TabIndex = 2;
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.ForeColor = System.Drawing.Color.Red;
         this.label5.Location = new System.Drawing.Point(327, 70);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(11, 13);
         this.label5.TabIndex = 2;
         this.label5.Text = "*";
         // 
         // label6
         // 
         this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(3, 38);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(23, 13);
         this.label6.TabIndex = 0;
         this.label6.Text = "Qty";
         // 
         // label7
         // 
         this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label7.AutoSize = true;
         this.label7.ForeColor = System.Drawing.Color.Red;
         this.label7.Location = new System.Drawing.Point(327, 38);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(11, 13);
         this.label7.TabIndex = 2;
         this.label7.Text = "*";
         // 
         // tlpButtons
         // 
         this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.tlpButtons.BackColor = System.Drawing.SystemColors.Control;
         this.tlpButtons.ColumnCount = 2;
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.Controls.Add(this.buttonOk, 0, 0);
         this.tlpButtons.Controls.Add(this.buttonCancel, 1, 0);
         this.tlpButtons.Location = new System.Drawing.Point(168, 294);
         this.tlpButtons.Name = "tlpButtons";
         this.tlpButtons.RowCount = 1;
         this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.Size = new System.Drawing.Size(200, 36);
         this.tlpButtons.TabIndex = 102;
         // 
         // buttonOk
         // 
         this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonOk.Location = new System.Drawing.Point(22, 6);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 99;
         this.buttonOk.Tag = "ignore";
         this.buttonOk.Text = "&Ok";
         this.buttonOk.UseVisualStyleBackColor = true;
         this.buttonOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(103, 6);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 100;
         this.buttonCancel.Tag = "ignore";
         this.buttonCancel.Text = "&Batal";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // textBoxQty
         // 
         this.textBoxQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxQty.BackGroundColor = System.Drawing.SystemColors.Window;
         this.textBoxQty.BeforeTouchSize = new System.Drawing.Size(250, 100);
         this.textBoxQty.IntegerValue = ((long)(1));
         this.textBoxQty.Location = new System.Drawing.Point(3, 5);
         this.textBoxQty.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxQty.MinValue = ((long)(1));
         this.textBoxQty.Name = "textBoxQty";
         this.textBoxQty.NullString = "";
         this.textBoxQty.Size = new System.Drawing.Size(100, 20);
         this.textBoxQty.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxQty.TabIndex = 1;
         this.textBoxQty.Text = "1";
         this.textBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // textBoxKeterangan
         // 
         this.textBoxKeterangan.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxKeterangan.BeforeTouchSize = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Location = new System.Drawing.Point(71, 97);
         this.textBoxKeterangan.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxKeterangan.Multiline = true;
         this.textBoxKeterangan.Name = "textBoxKeterangan";
         this.textBoxKeterangan.Size = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxKeterangan.TabIndex = 3;
         // 
         // panelUp
         // 
         this.panelUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panelUp.LabelInfo = "Info";
         this.panelUp.Location = new System.Drawing.Point(12, 12);
         this.panelUp.Name = "panelUp";
         this.panelUp.Size = new System.Drawing.Size(362, 40);
         this.panelUp.TabIndex = 0;
         this.panelUp.TabStop = false;
         // 
         // ReturnPenjualanEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(386, 342);
         this.Controls.Add(this.tlpButtons);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.panelUp);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ReturnPenjualanEntryView";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Return Barang";
         this.Load += new System.EventHandler(this.ReturnPenjualanEntryView_Load);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tlpButtons.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.textBoxQty)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.PanelUp panelUp;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox comboBoxBarang;
      private System.Windows.Forms.ComboBox comboBoxStatus;
      private CommonControls.BaseTextBox textBoxKeterangan;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      protected System.Windows.Forms.TableLayoutPanel tlpButtons;
      protected System.Windows.Forms.Button buttonOk;
      protected System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label label6;
      private CommonControls.BaseTextBoxDigit textBoxQty;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label labelMax;
   }
}