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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaporanStatusBarangView));
         this.panelUp = new RumahScarlett.Presentation.Views.CommonControls.PanelUp();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.buttonCetak = new System.Windows.Forms.Button();
         this.buttonTutup = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.labelStokAwal = new System.Windows.Forms.Label();
         this.labelStokKeluar = new System.Windows.Forms.Label();
         this.labelStokAkhir = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.label17 = new System.Windows.Forms.Label();
         this.label18 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.labelStokMasuk = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
         this.label11 = new System.Windows.Forms.Label();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label16 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panelUp
         // 
         this.panelUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panelUp.LabelInfo = "Info";
         this.panelUp.Location = new System.Drawing.Point(12, 12);
         this.panelUp.Name = "panelUp";
         this.panelUp.Size = new System.Drawing.Size(280, 40);
         this.panelUp.TabIndex = 108;
         this.panelUp.TabStop = false;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.Controls.Add(this.buttonCetak, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.buttonTutup, 1, 0);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(121, 269);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(171, 30);
         this.tableLayoutPanel2.TabIndex = 107;
         // 
         // buttonCetak
         // 
         this.buttonCetak.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonCetak.Location = new System.Drawing.Point(7, 3);
         this.buttonCetak.Name = "buttonCetak";
         this.buttonCetak.Size = new System.Drawing.Size(75, 23);
         this.buttonCetak.TabIndex = 99;
         this.buttonCetak.Tag = "ignore";
         this.buttonCetak.Text = "&Cetak";
         this.buttonCetak.UseVisualStyleBackColor = true;
         this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
         // 
         // buttonTutup
         // 
         this.buttonTutup.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonTutup.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonTutup.Location = new System.Drawing.Point(88, 3);
         this.buttonTutup.Name = "buttonTutup";
         this.buttonTutup.Size = new System.Drawing.Size(75, 23);
         this.buttonTutup.TabIndex = 99;
         this.buttonTutup.Tag = "ignore";
         this.buttonTutup.Text = "&Tutup";
         this.buttonTutup.UseVisualStyleBackColor = true;
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
         this.label2.Location = new System.Drawing.Point(73, 8);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(10, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = ":";
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(3, 38);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(55, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Stok Awal";
         // 
         // label6
         // 
         this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(3, 98);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(62, 13);
         this.label6.TabIndex = 0;
         this.label6.Text = "Stok Keluar";
         // 
         // label7
         // 
         this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label7.AutoSize = true;
         this.tableLayoutPanel1.SetColumnSpan(this.label7, 4);
         this.label7.Location = new System.Drawing.Point(3, 128);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(262, 13);
         this.label7.TabIndex = 0;
         this.label7.Text = "---------------------------------------------------------------------------------" +
    "----";
         // 
         // label8
         // 
         this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(3, 158);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(56, 13);
         this.label8.TabIndex = 0;
         this.label8.Text = "Stok Akhir";
         // 
         // labelStokAwal
         // 
         this.labelStokAwal.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelStokAwal.AutoSize = true;
         this.labelStokAwal.Location = new System.Drawing.Point(226, 38);
         this.labelStokAwal.Name = "labelStokAwal";
         this.labelStokAwal.Size = new System.Drawing.Size(13, 13);
         this.labelStokAwal.TabIndex = 0;
         this.labelStokAwal.Text = "0";
         this.labelStokAwal.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // labelStokKeluar
         // 
         this.labelStokKeluar.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelStokKeluar.AutoSize = true;
         this.labelStokKeluar.Location = new System.Drawing.Point(226, 98);
         this.labelStokKeluar.Name = "labelStokKeluar";
         this.labelStokKeluar.Size = new System.Drawing.Size(13, 13);
         this.labelStokKeluar.TabIndex = 0;
         this.labelStokKeluar.Text = "0";
         this.labelStokKeluar.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // labelStokAkhir
         // 
         this.labelStokAkhir.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelStokAkhir.AutoSize = true;
         this.labelStokAkhir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelStokAkhir.Location = new System.Drawing.Point(226, 158);
         this.labelStokAkhir.Name = "labelStokAkhir";
         this.labelStokAkhir.Size = new System.Drawing.Size(13, 13);
         this.labelStokAkhir.TabIndex = 0;
         this.labelStokAkhir.Text = "0";
         this.labelStokAkhir.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label13
         // 
         this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(73, 38);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(10, 13);
         this.label13.TabIndex = 0;
         this.label13.Text = ":";
         // 
         // label17
         // 
         this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label17.AutoSize = true;
         this.label17.ForeColor = System.Drawing.Color.Green;
         this.label17.Location = new System.Drawing.Point(245, 38);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(13, 13);
         this.label17.TabIndex = 0;
         this.label17.Text = "+";
         // 
         // label18
         // 
         this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label18.AutoSize = true;
         this.label18.ForeColor = System.Drawing.Color.Red;
         this.label18.Location = new System.Drawing.Point(245, 98);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(10, 13);
         this.label18.TabIndex = 0;
         this.label18.Text = "-";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 68);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(64, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Stok Masuk";
         // 
         // label10
         // 
         this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label10.AutoSize = true;
         this.label10.ForeColor = System.Drawing.Color.Green;
         this.label10.Location = new System.Drawing.Point(245, 68);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(13, 13);
         this.label10.TabIndex = 0;
         this.label10.Text = "+";
         // 
         // labelStokMasuk
         // 
         this.labelStokMasuk.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelStokMasuk.AutoSize = true;
         this.labelStokMasuk.Location = new System.Drawing.Point(226, 68);
         this.labelStokMasuk.Name = "labelStokMasuk";
         this.labelStokMasuk.Size = new System.Drawing.Size(13, 13);
         this.labelStokMasuk.TabIndex = 0;
         this.labelStokMasuk.Text = "0";
         this.labelStokMasuk.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label15
         // 
         this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(73, 68);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(10, 13);
         this.label15.TabIndex = 0;
         this.label15.Text = ":";
         // 
         // dateTimePickerTanggal
         // 
         this.dateTimePickerTanggal.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dateTimePickerTanggal.Location = new System.Drawing.Point(89, 5);
         this.dateTimePickerTanggal.MinDate = new System.DateTime(1945, 8, 17, 0, 0, 0, 0);
         this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
         this.dateTimePickerTanggal.Size = new System.Drawing.Size(150, 20);
         this.dateTimePickerTanggal.TabIndex = 0;
         this.dateTimePickerTanggal.ValueChanged += new System.EventHandler(this.dateTimePickerTanggal_ValueChanged);
         // 
         // label11
         // 
         this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(73, 98);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(10, 13);
         this.label11.TabIndex = 0;
         this.label11.Text = ":";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 4;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
         this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
         this.tableLayoutPanel1.Controls.Add(this.labelStokAwal, 2, 1);
         this.tableLayoutPanel1.Controls.Add(this.labelStokKeluar, 2, 3);
         this.tableLayoutPanel1.Controls.Add(this.labelStokAkhir, 2, 5);
         this.tableLayoutPanel1.Controls.Add(this.label13, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label16, 1, 5);
         this.tableLayoutPanel1.Controls.Add(this.label17, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.label18, 3, 3);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.label10, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.labelStokMasuk, 2, 2);
         this.tableLayoutPanel1.Controls.Add(this.label15, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.dateTimePickerTanggal, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label11, 1, 3);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 6;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 180);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label16
         // 
         this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label16.AutoSize = true;
         this.label16.Location = new System.Drawing.Point(73, 158);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(10, 13);
         this.label16.TabIndex = 0;
         this.label16.Text = ":";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(280, 205);
         this.groupBox1.TabIndex = 106;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ DATA ]";
         // 
         // LaporanStatusBarangView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(304, 311);
         this.Controls.Add(this.panelUp);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.groupBox1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LaporanStatusBarangView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Laporan Status Barang";
         this.Load += new System.EventHandler(this.LaporanStatusBarangView_Load);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.PanelUp panelUp;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      protected System.Windows.Forms.Button buttonCetak;
      protected System.Windows.Forms.Button buttonTutup;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label labelStokAwal;
      private System.Windows.Forms.Label labelStokKeluar;
      private System.Windows.Forms.Label labelStokAkhir;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label labelStokMasuk;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.GroupBox groupBox1;
   }
}