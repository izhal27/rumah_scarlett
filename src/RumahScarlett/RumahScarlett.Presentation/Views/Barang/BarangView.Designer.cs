namespace RumahScarlett.Presentation.Views.Barang
{
   partial class BarangView
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
         this.groupBoxFilter = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.radioButtonSemua = new System.Windows.Forms.RadioButton();
         this.radioButtonTipe = new System.Windows.Forms.RadioButton();
         this.radioButtonSupplier = new System.Windows.Forms.RadioButton();
         this.buttonTampilkan = new System.Windows.Forms.Button();
         this.comboBoxTipe = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxTipe();
         this.comboBoxSubTipe = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxSubTipe();
         this.comboBoxSupplier = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxSupplier();
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.buttonTambah = new System.Windows.Forms.Button();
         this.buttonRefresh = new System.Windows.Forms.Button();
         this.buttonUbah = new System.Windows.Forms.Button();
         this.buttonHapus = new System.Windows.Forms.Button();
         this.buttonTutup = new System.Windows.Forms.Button();
         this.buttonCetak = new System.Windows.Forms.Button();
         this.buttonDetailPenyesuainStok = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.groupBoxFilter.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tlpButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // panelUp
         // 
         this.panelUp.Size = new System.Drawing.Size(954, 40);
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.AllowEditing = false;
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 202);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.ShowRowHeader = true;
         this.listDataGrid.Size = new System.Drawing.Size(954, 207);
         this.listDataGrid.TabIndex = 1;
         this.listDataGrid.Text = "listDataGrid1";
         this.listDataGrid.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.listDataGrid_CellDoubleClick);
         // 
         // groupBoxFilter
         // 
         this.groupBoxFilter.Controls.Add(this.tableLayoutPanel2);
         this.groupBoxFilter.Location = new System.Drawing.Point(12, 58);
         this.groupBoxFilter.Name = "groupBoxFilter";
         this.groupBoxFilter.Size = new System.Drawing.Size(454, 138);
         this.groupBoxFilter.TabIndex = 5;
         this.groupBoxFilter.TabStop = false;
         this.groupBoxFilter.Text = "[ FILTER BY ]";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel2.ColumnCount = 4;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Controls.Add(this.label1, 2, 1);
         this.tableLayoutPanel2.Controls.Add(this.radioButtonSemua, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.radioButtonTipe, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.radioButtonSupplier, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.buttonTampilkan, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.comboBoxTipe, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.comboBoxSubTipe, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.comboBoxSupplier, 1, 2);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(442, 113);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(228, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(50, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Sub Tipe";
         // 
         // radioButtonSemua
         // 
         this.radioButtonSemua.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.radioButtonSemua.AutoSize = true;
         this.radioButtonSemua.Checked = true;
         this.radioButtonSemua.Location = new System.Drawing.Point(3, 3);
         this.radioButtonSemua.Name = "radioButtonSemua";
         this.radioButtonSemua.Size = new System.Drawing.Size(58, 17);
         this.radioButtonSemua.TabIndex = 10;
         this.radioButtonSemua.TabStop = true;
         this.radioButtonSemua.Text = "Semua";
         this.radioButtonSemua.UseVisualStyleBackColor = true;
         // 
         // radioButtonTipe
         // 
         this.radioButtonTipe.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.radioButtonTipe.AutoSize = true;
         this.radioButtonTipe.Location = new System.Drawing.Point(3, 28);
         this.radioButtonTipe.Name = "radioButtonTipe";
         this.radioButtonTipe.Size = new System.Drawing.Size(46, 17);
         this.radioButtonTipe.TabIndex = 10;
         this.radioButtonTipe.Text = "Tipe";
         this.radioButtonTipe.UseVisualStyleBackColor = true;
         // 
         // radioButtonSupplier
         // 
         this.radioButtonSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.radioButtonSupplier.AutoSize = true;
         this.radioButtonSupplier.Location = new System.Drawing.Point(3, 55);
         this.radioButtonSupplier.Name = "radioButtonSupplier";
         this.radioButtonSupplier.Size = new System.Drawing.Size(63, 17);
         this.radioButtonSupplier.TabIndex = 10;
         this.radioButtonSupplier.Text = "Supplier";
         this.radioButtonSupplier.UseVisualStyleBackColor = true;
         // 
         // buttonTampilkan
         // 
         this.buttonTampilkan.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonTampilkan.Location = new System.Drawing.Point(72, 82);
         this.buttonTampilkan.Name = "buttonTampilkan";
         this.buttonTampilkan.Size = new System.Drawing.Size(75, 25);
         this.buttonTampilkan.TabIndex = 8;
         this.buttonTampilkan.Text = "Tam&pilkan";
         this.buttonTampilkan.UseVisualStyleBackColor = true;
         // 
         // comboBoxTipe
         // 
         this.comboBoxTipe.Location = new System.Drawing.Point(72, 26);
         this.comboBoxTipe.Name = "comboBoxTipe";
         this.comboBoxTipe.Size = new System.Drawing.Size(150, 21);
         this.comboBoxTipe.TabIndex = 14;
         // 
         // comboBoxSubTipe
         // 
         this.comboBoxSubTipe.Location = new System.Drawing.Point(284, 26);
         this.comboBoxSubTipe.Name = "comboBoxSubTipe";
         this.comboBoxSubTipe.Size = new System.Drawing.Size(150, 21);
         this.comboBoxSubTipe.TabIndex = 15;
         // 
         // comboBoxSupplier
         // 
         this.comboBoxSupplier.Location = new System.Drawing.Point(72, 53);
         this.comboBoxSupplier.Name = "comboBoxSupplier";
         this.comboBoxSupplier.Size = new System.Drawing.Size(150, 21);
         this.comboBoxSupplier.TabIndex = 16;
         // 
         // tlpButtons
         // 
         this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tlpButtons.BackColor = System.Drawing.SystemColors.Control;
         this.tlpButtons.ColumnCount = 7;
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.Controls.Add(this.buttonTambah, 0, 0);
         this.tlpButtons.Controls.Add(this.buttonRefresh, 3, 0);
         this.tlpButtons.Controls.Add(this.buttonUbah, 1, 0);
         this.tlpButtons.Controls.Add(this.buttonHapus, 2, 0);
         this.tlpButtons.Controls.Add(this.buttonTutup, 6, 0);
         this.tlpButtons.Controls.Add(this.buttonCetak, 4, 0);
         this.tlpButtons.Controls.Add(this.buttonDetailPenyesuainStok, 5, 0);
         this.tlpButtons.Location = new System.Drawing.Point(12, 415);
         this.tlpButtons.Name = "tlpButtons";
         this.tlpButtons.RowCount = 1;
         this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpButtons.Size = new System.Drawing.Size(954, 35);
         this.tlpButtons.TabIndex = 6;
         // 
         // buttonTambah
         // 
         this.buttonTambah.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonTambah.Location = new System.Drawing.Point(3, 6);
         this.buttonTambah.Name = "buttonTambah";
         this.buttonTambah.Size = new System.Drawing.Size(75, 23);
         this.buttonTambah.TabIndex = 94;
         this.buttonTambah.Tag = "Tambah";
         this.buttonTambah.Text = "&Tambah";
         this.buttonTambah.UseVisualStyleBackColor = true;
         this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
         // 
         // buttonRefresh
         // 
         this.buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonRefresh.Location = new System.Drawing.Point(246, 6);
         this.buttonRefresh.Name = "buttonRefresh";
         this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
         this.buttonRefresh.TabIndex = 97;
         this.buttonRefresh.Tag = "Refresh";
         this.buttonRefresh.Text = "&Refresh";
         this.buttonRefresh.UseVisualStyleBackColor = true;
         this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
         // 
         // buttonUbah
         // 
         this.buttonUbah.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonUbah.Location = new System.Drawing.Point(84, 6);
         this.buttonUbah.Name = "buttonUbah";
         this.buttonUbah.Size = new System.Drawing.Size(75, 23);
         this.buttonUbah.TabIndex = 95;
         this.buttonUbah.Tag = "Ubah";
         this.buttonUbah.Text = "&Ubah";
         this.buttonUbah.UseVisualStyleBackColor = true;
         this.buttonUbah.Click += new System.EventHandler(this.buttonUbah_Click);
         // 
         // buttonHapus
         // 
         this.buttonHapus.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonHapus.Location = new System.Drawing.Point(165, 6);
         this.buttonHapus.Name = "buttonHapus";
         this.buttonHapus.Size = new System.Drawing.Size(75, 23);
         this.buttonHapus.TabIndex = 96;
         this.buttonHapus.Tag = "Hapus";
         this.buttonHapus.Text = "&Hapus";
         this.buttonHapus.UseVisualStyleBackColor = true;
         this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
         // 
         // buttonTutup
         // 
         this.buttonTutup.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonTutup.Location = new System.Drawing.Point(876, 6);
         this.buttonTutup.Name = "buttonTutup";
         this.buttonTutup.Size = new System.Drawing.Size(75, 23);
         this.buttonTutup.TabIndex = 100;
         this.buttonTutup.Tag = "ignore";
         this.buttonTutup.Text = "Tutu&p";
         this.buttonTutup.UseVisualStyleBackColor = true;
         this.buttonTutup.Click += new System.EventHandler(this.crudcButtons_OnTutupClickEvent);
         // 
         // buttonCetak
         // 
         this.buttonCetak.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonCetak.Location = new System.Drawing.Point(327, 6);
         this.buttonCetak.Name = "buttonCetak";
         this.buttonCetak.Size = new System.Drawing.Size(75, 23);
         this.buttonCetak.TabIndex = 98;
         this.buttonCetak.Tag = "Cetak";
         this.buttonCetak.Text = "&Cetak";
         this.buttonCetak.UseVisualStyleBackColor = true;
         this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
         // 
         // buttonDetailPenyesuainStok
         // 
         this.buttonDetailPenyesuainStok.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.buttonDetailPenyesuainStok.Location = new System.Drawing.Point(408, 6);
         this.buttonDetailPenyesuainStok.Name = "buttonDetailPenyesuainStok";
         this.buttonDetailPenyesuainStok.Size = new System.Drawing.Size(100, 23);
         this.buttonDetailPenyesuainStok.TabIndex = 99;
         this.buttonDetailPenyesuainStok.Tag = "Cetak";
         this.buttonDetailPenyesuainStok.Text = "Penyesuain Sto&k";
         this.buttonDetailPenyesuainStok.UseVisualStyleBackColor = true;
         this.buttonDetailPenyesuainStok.Click += new System.EventHandler(this.buttonDetailPenyesuainStok_Click);
         // 
         // BarangView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(978, 462);
         this.Controls.Add(this.tlpButtons);
         this.Controls.Add(this.groupBoxFilter);
         this.Controls.Add(this.listDataGrid);
         this.Name = "BarangView";
         this.Text = "Barang";
         this.Load += new System.EventHandler(this.BarangView_Load);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.groupBoxFilter, 0);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.tlpButtons, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.groupBoxFilter.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tlpButtons.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.ListDataGrid listDataGrid;
      private System.Windows.Forms.GroupBox groupBoxFilter;
      private System.Windows.Forms.Button buttonTampilkan;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.RadioButton radioButtonSemua;
      private System.Windows.Forms.RadioButton radioButtonTipe;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.RadioButton radioButtonSupplier;
      private ModelControls.ComboBoxTipe comboBoxTipe;
      private ModelControls.ComboBoxSubTipe comboBoxSubTipe;
      private ModelControls.ComboBoxSupplier comboBoxSupplier;
      protected System.Windows.Forms.TableLayoutPanel tlpButtons;
      protected System.Windows.Forms.Button buttonTambah;
      protected System.Windows.Forms.Button buttonRefresh;
      protected System.Windows.Forms.Button buttonUbah;
      protected System.Windows.Forms.Button buttonHapus;
      protected System.Windows.Forms.Button buttonTutup;
      protected System.Windows.Forms.Button buttonCetak;
      protected System.Windows.Forms.Button buttonDetailPenyesuainStok;
   }
}