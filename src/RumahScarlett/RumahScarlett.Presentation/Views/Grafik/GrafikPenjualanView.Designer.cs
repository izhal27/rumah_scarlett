namespace RumahScarlett.Presentation.Views.Grafik
{
   partial class GrafikPenjualanView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrafikPenjualanView));
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.numericUpDownTahun = new System.Windows.Forms.NumericUpDown();
         this.radioButtonBulan = new System.Windows.Forms.RadioButton();
         this.radioButtonPeriode = new System.Windows.Forms.RadioButton();
         this.label1 = new System.Windows.Forms.Label();
         this.buttonTampilkan = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.comboBoxBulan = new RumahScarlett.Presentation.Views.CommonControls.ComboBoxBulan();
         this.comboBoxBulanAwal = new RumahScarlett.Presentation.Views.CommonControls.ComboBoxBulan();
         this.numericUpDownTahunAwal = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownTahunAkhir = new System.Windows.Forms.NumericUpDown();
         this.comboBoxBulanAkhir = new RumahScarlett.Presentation.Views.CommonControls.ComboBoxBulan();
         this.chartPenjualan = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.buttonTutup = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahun)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahunAwal)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahunAkhir)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chartPenjualan)).BeginInit();
         this.tlpButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(583, 115);
         this.groupBox1.TabIndex = 6;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ FILTER BY ]";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 7;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.numericUpDownTahun, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.radioButtonBulan, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.radioButtonPeriode, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label1, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.buttonTampilkan, 2, 2);
         this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxBulan, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxBulanAwal, 2, 1);
         this.tableLayoutPanel1.Controls.Add(this.numericUpDownTahunAwal, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.numericUpDownTahunAkhir, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxBulanAkhir, 5, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 90);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // numericUpDownTahun
         // 
         this.numericUpDownTahun.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.numericUpDownTahun.Location = new System.Drawing.Point(242, 5);
         this.numericUpDownTahun.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.numericUpDownTahun.Minimum = new decimal(new int[] {
            1945,
            0,
            0,
            0});
         this.numericUpDownTahun.Name = "numericUpDownTahun";
         this.numericUpDownTahun.Size = new System.Drawing.Size(65, 20);
         this.numericUpDownTahun.TabIndex = 6;
         this.numericUpDownTahun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.numericUpDownTahun.Value = new decimal(new int[] {
            1945,
            0,
            0,
            0});
         // 
         // radioButtonBulan
         // 
         this.radioButtonBulan.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.radioButtonBulan.AutoSize = true;
         this.radioButtonBulan.Checked = true;
         this.radioButtonBulan.Location = new System.Drawing.Point(3, 6);
         this.radioButtonBulan.Name = "radioButtonBulan";
         this.radioButtonBulan.Size = new System.Drawing.Size(52, 17);
         this.radioButtonBulan.TabIndex = 0;
         this.radioButtonBulan.TabStop = true;
         this.radioButtonBulan.Text = "Bulan";
         this.radioButtonBulan.UseVisualStyleBackColor = true;
         // 
         // radioButtonPeriode
         // 
         this.radioButtonPeriode.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.radioButtonPeriode.AutoSize = true;
         this.radioButtonPeriode.Location = new System.Drawing.Point(3, 36);
         this.radioButtonPeriode.Name = "radioButtonPeriode";
         this.radioButtonPeriode.Size = new System.Drawing.Size(61, 17);
         this.radioButtonPeriode.TabIndex = 0;
         this.radioButtonPeriode.Text = "Periode";
         this.radioButtonPeriode.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(313, 38);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(23, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "s/d";
         // 
         // buttonTampilkan
         // 
         this.buttonTampilkan.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonTampilkan.Location = new System.Drawing.Point(86, 63);
         this.buttonTampilkan.Name = "buttonTampilkan";
         this.buttonTampilkan.Size = new System.Drawing.Size(75, 23);
         this.buttonTampilkan.TabIndex = 3;
         this.buttonTampilkan.Tag = "ignore";
         this.buttonTampilkan.Text = "Tampilkan";
         this.buttonTampilkan.UseVisualStyleBackColor = true;
         this.buttonTampilkan.Click += new System.EventHandler(this.buttonTampilkan_Click);
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(70, 8);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(10, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = ":";
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(70, 38);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(10, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = ":";
         // 
         // comboBoxBulan
         // 
         this.comboBoxBulan.DataSource = ((object)(resources.GetObject("comboBoxBulan.DataSource")));
         this.comboBoxBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxBulan.Location = new System.Drawing.Point(86, 3);
         this.comboBoxBulan.Name = "comboBoxBulan";
         this.comboBoxBulan.Size = new System.Drawing.Size(150, 21);
         this.comboBoxBulan.TabIndex = 7;
         // 
         // comboBoxBulanAwal
         // 
         this.comboBoxBulanAwal.DataSource = ((object)(resources.GetObject("comboBoxBulanAwal.DataSource")));
         this.comboBoxBulanAwal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxBulanAwal.Location = new System.Drawing.Point(86, 33);
         this.comboBoxBulanAwal.Name = "comboBoxBulanAwal";
         this.comboBoxBulanAwal.Size = new System.Drawing.Size(150, 21);
         this.comboBoxBulanAwal.TabIndex = 7;
         // 
         // numericUpDownTahunAwal
         // 
         this.numericUpDownTahunAwal.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.numericUpDownTahunAwal.Location = new System.Drawing.Point(242, 35);
         this.numericUpDownTahunAwal.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.numericUpDownTahunAwal.Minimum = new decimal(new int[] {
            1945,
            0,
            0,
            0});
         this.numericUpDownTahunAwal.Name = "numericUpDownTahunAwal";
         this.numericUpDownTahunAwal.Size = new System.Drawing.Size(65, 20);
         this.numericUpDownTahunAwal.TabIndex = 6;
         this.numericUpDownTahunAwal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.numericUpDownTahunAwal.Value = new decimal(new int[] {
            1945,
            0,
            0,
            0});
         // 
         // numericUpDownTahunAkhir
         // 
         this.numericUpDownTahunAkhir.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.numericUpDownTahunAkhir.Location = new System.Drawing.Point(498, 35);
         this.numericUpDownTahunAkhir.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.numericUpDownTahunAkhir.Minimum = new decimal(new int[] {
            1945,
            0,
            0,
            0});
         this.numericUpDownTahunAkhir.Name = "numericUpDownTahunAkhir";
         this.numericUpDownTahunAkhir.Size = new System.Drawing.Size(65, 20);
         this.numericUpDownTahunAkhir.TabIndex = 6;
         this.numericUpDownTahunAkhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.numericUpDownTahunAkhir.Value = new decimal(new int[] {
            1945,
            0,
            0,
            0});
         // 
         // comboBoxBulanAkhir
         // 
         this.comboBoxBulanAkhir.DataSource = ((object)(resources.GetObject("comboBoxBulanAkhir.DataSource")));
         this.comboBoxBulanAkhir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxBulanAkhir.Location = new System.Drawing.Point(342, 33);
         this.comboBoxBulanAkhir.Name = "comboBoxBulanAkhir";
         this.comboBoxBulanAkhir.Size = new System.Drawing.Size(150, 21);
         this.comboBoxBulanAkhir.TabIndex = 7;
         // 
         // chartPenjualan
         // 
         chartArea3.Name = "ChartArea1";
         this.chartPenjualan.ChartAreas.Add(chartArea3);
         legend3.Name = "Legend1";
         this.chartPenjualan.Legends.Add(legend3);
         this.chartPenjualan.Location = new System.Drawing.Point(12, 179);
         this.chartPenjualan.Name = "chartPenjualan";
         series3.ChartArea = "ChartArea1";
         series3.Legend = "Legend1";
         series3.Name = "Series1";
         this.chartPenjualan.Series.Add(series3);
         this.chartPenjualan.Size = new System.Drawing.Size(760, 230);
         this.chartPenjualan.TabIndex = 7;
         this.chartPenjualan.Text = "chart1";
         // 
         // tlpButtons
         // 
         this.tlpButtons.BackColor = System.Drawing.SystemColors.Control;
         this.tlpButtons.ColumnCount = 1;
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpButtons.Controls.Add(this.buttonTutup, 0, 0);
         this.tlpButtons.Location = new System.Drawing.Point(12, 415);
         this.tlpButtons.Name = "tlpButtons";
         this.tlpButtons.RowCount = 1;
         this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpButtons.Size = new System.Drawing.Size(760, 35);
         this.tlpButtons.TabIndex = 8;
         // 
         // buttonTutup
         // 
         this.buttonTutup.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonTutup.Location = new System.Drawing.Point(682, 6);
         this.buttonTutup.Name = "buttonTutup";
         this.buttonTutup.Size = new System.Drawing.Size(75, 23);
         this.buttonTutup.TabIndex = 100;
         this.buttonTutup.Tag = "ignore";
         this.buttonTutup.Text = "Tutu&p";
         this.buttonTutup.UseVisualStyleBackColor = true;
         this.buttonTutup.Click += new System.EventHandler(this.buttonTutup_Click);
         // 
         // GrafikPenjualanView
         // 
         this.AccessibleName = "Laporan";
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.tlpButtons);
         this.Controls.Add(this.chartPenjualan);
         this.Controls.Add(this.groupBox1);
         this.Name = "GrafikPenjualanView";
         this.Tag = "";
         this.Text = "Grafik Penjualan View";
         this.Load += new System.EventHandler(this.GrafikPenjualanView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.Controls.SetChildIndex(this.chartPenjualan, 0);
         this.Controls.SetChildIndex(this.tlpButtons, 0);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahun)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahunAwal)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahunAkhir)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chartPenjualan)).EndInit();
         this.tlpButtons.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.NumericUpDown numericUpDownTahun;
      private System.Windows.Forms.RadioButton radioButtonBulan;
      private System.Windows.Forms.RadioButton radioButtonPeriode;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonTampilkan;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private CommonControls.ComboBoxBulan comboBoxBulan;
      private CommonControls.ComboBoxBulan comboBoxBulanAwal;
      private System.Windows.Forms.NumericUpDown numericUpDownTahunAwal;
      private System.Windows.Forms.NumericUpDown numericUpDownTahunAkhir;
      private CommonControls.ComboBoxBulan comboBoxBulanAkhir;
      private System.Windows.Forms.DataVisualization.Charting.Chart chartPenjualan;
      protected System.Windows.Forms.TableLayoutPanel tlpButtons;
      protected System.Windows.Forms.Button buttonTutup;
   }
}