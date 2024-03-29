﻿namespace RumahScarlett.Presentation.Views.Grafik
{
   partial class GrafikBarangTerjualView
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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.numericUpDownTahun = new System.Windows.Forms.NumericUpDown();
         this.radioButtonBulan = new System.Windows.Forms.RadioButton();
         this.buttonTampilkan = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.comboBoxBulan = new RumahScarlett.Presentation.Views.CommonControls.ComboBoxBulan();
         this.chartBarangTerjual = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.buttonTutup = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahun)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chartBarangTerjual)).BeginInit();
         this.tlpButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(318, 85);
         this.groupBox1.TabIndex = 6;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ FILTER BY ]";
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
         this.tableLayoutPanel1.Controls.Add(this.numericUpDownTahun, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.radioButtonBulan, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.buttonTampilkan, 2, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxBulan, 2, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 60);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // numericUpDownTahun
         // 
         this.numericUpDownTahun.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.numericUpDownTahun.Location = new System.Drawing.Point(233, 5);
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
         // buttonTampilkan
         // 
         this.buttonTampilkan.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonTampilkan.Location = new System.Drawing.Point(77, 33);
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
         this.label3.Location = new System.Drawing.Point(61, 8);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(10, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = ":";
         // 
         // comboBoxBulan
         // 
         this.comboBoxBulan.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxBulan.FormattingEnabled = true;
         this.comboBoxBulan.Location = new System.Drawing.Point(77, 4);
         this.comboBoxBulan.Name = "comboBoxBulan";
         this.comboBoxBulan.Size = new System.Drawing.Size(150, 21);
         this.comboBoxBulan.TabIndex = 7;
         // 
         // chartBarangTerjual
         // 
         this.chartBarangTerjual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         chartArea1.Name = "ChartArea1";
         this.chartBarangTerjual.ChartAreas.Add(chartArea1);
         legend1.Name = "Legend1";
         this.chartBarangTerjual.Legends.Add(legend1);
         this.chartBarangTerjual.Location = new System.Drawing.Point(12, 149);
         this.chartBarangTerjual.Name = "chartBarangTerjual";
         this.chartBarangTerjual.Size = new System.Drawing.Size(760, 260);
         this.chartBarangTerjual.TabIndex = 7;
         this.chartBarangTerjual.Text = "chart1";
         // 
         // tlpButtons
         // 
         this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
         // GrafikBarangTerjualView
         // 
         this.AccessibleName = "Laporan";
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.tlpButtons);
         this.Controls.Add(this.chartBarangTerjual);
         this.Controls.Add(this.groupBox1);
         this.Name = "GrafikBarangTerjualView";
         this.Tag = "";
         this.Text = "Grafik Barang Terjual";
         this.Load += new System.EventHandler(this.GrafikPenjualanView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.Controls.SetChildIndex(this.chartBarangTerjual, 0);
         this.Controls.SetChildIndex(this.tlpButtons, 0);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTahun)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chartBarangTerjual)).EndInit();
         this.tlpButtons.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.NumericUpDown numericUpDownTahun;
      private System.Windows.Forms.RadioButton radioButtonBulan;
      private System.Windows.Forms.Button buttonTampilkan;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.DataVisualization.Charting.Chart chartBarangTerjual;
      protected System.Windows.Forms.TableLayoutPanel tlpButtons;
      protected System.Windows.Forms.Button buttonTutup;
      private CommonControls.ComboBoxBulan comboBoxBulan;
   }
}