namespace RumahScarlett.Presentation.Views.HutangOperasional
{
   partial class HutangOperasionalEntryView
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
         this.textBoxKeterangan = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
         this.textBoxDigitJumlah = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBoxDigit();
         this.comboBoxStatusHutang = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxStatusHutang();
         this.label8 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxDigitJumlah)).BeginInit();
         this.SuspendLayout();
         // 
         // panelUp
         // 
         this.panelUp.Size = new System.Drawing.Size(371, 40);
         // 
         // operationButtons
         // 
         this.operationButtons.Location = new System.Drawing.Point(208, 281);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(371, 217);
         this.groupBox1.TabIndex = 4;
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
         this.tableLayoutPanel1.Controls.Add(this.textBoxKeterangan, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.dateTimePickerTanggal, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.textBoxDigitJumlah, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxStatusHutang, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 192);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // textBoxKeterangan
         // 
         this.textBoxKeterangan.BeforeTouchSize = new System.Drawing.Size(250, 20);
         this.textBoxKeterangan.Location = new System.Drawing.Point(84, 55);
         this.textBoxKeterangan.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxKeterangan.Multiline = true;
         this.textBoxKeterangan.Name = "textBoxKeterangan";
         this.textBoxKeterangan.Size = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxKeterangan.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tanggal";
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 32);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(40, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Jumlah";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 98);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Keterangan";
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 168);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(75, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Status Hutang";
         // 
         // dateTimePickerTanggal
         // 
         this.dateTimePickerTanggal.Location = new System.Drawing.Point(84, 3);
         this.dateTimePickerTanggal.MinDate = new System.DateTime(1945, 8, 17, 0, 0, 0, 0);
         this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
         this.dateTimePickerTanggal.Size = new System.Drawing.Size(150, 20);
         this.dateTimePickerTanggal.TabIndex = 1;
         // 
         // textBoxDigitJumlah
         // 
         this.textBoxDigitJumlah.BackGroundColor = System.Drawing.SystemColors.Window;
         this.textBoxDigitJumlah.BeforeTouchSize = new System.Drawing.Size(250, 20);
         this.textBoxDigitJumlah.IntegerValue = ((long)(0));
         this.textBoxDigitJumlah.Location = new System.Drawing.Point(84, 29);
         this.textBoxDigitJumlah.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxDigitJumlah.MinValue = ((long)(0));
         this.textBoxDigitJumlah.Name = "textBoxDigitJumlah";
         this.textBoxDigitJumlah.NullString = "";
         this.textBoxDigitJumlah.Size = new System.Drawing.Size(150, 20);
         this.textBoxDigitJumlah.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxDigitJumlah.TabIndex = 2;
         this.textBoxDigitJumlah.Text = "0";
         this.textBoxDigitJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // comboBoxStatusHutang
         // 
         this.comboBoxStatusHutang.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxStatusHutang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxStatusHutang.FormattingEnabled = true;
         this.comboBoxStatusHutang.Items.AddRange(new object[] {
            "Belum Lunas",
            "Lunas"});
         this.comboBoxStatusHutang.Location = new System.Drawing.Point(84, 164);
         this.comboBoxStatusHutang.Name = "comboBoxStatusHutang";
         this.comboBoxStatusHutang.Size = new System.Drawing.Size(150, 21);
         this.comboBoxStatusHutang.TabIndex = 4;
         // 
         // label8
         // 
         this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label8.AutoSize = true;
         this.label8.ForeColor = System.Drawing.Color.Red;
         this.label8.Location = new System.Drawing.Point(340, 32);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(11, 13);
         this.label8.TabIndex = 5;
         this.label8.Text = "*";
         // 
         // HutangOperasionalEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(395, 328);
         this.Controls.Add(this.groupBox1);
         this.Name = "HutangOperasionalEntryView";
         this.Text = "Hutang Operasional";
         this.Load += new System.EventHandler(this.HutangOperasionalEntryView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.operationButtons, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxDigitJumlah)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
      private CommonControls.BaseTextBoxDigit textBoxDigitJumlah;
      private CommonControls.BaseTextBox textBoxKeterangan;
      private ModelControls.ComboBoxStatusHutang comboBoxStatusHutang;
      private System.Windows.Forms.Label label8;
   }
}