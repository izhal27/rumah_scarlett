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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarangView));
         this.listDataGrid = new RumahScarlett.Presentation.Views.CommonControls.ListDataGrid();
         this.crudcButtons = new RumahScarlett.Presentation.Views.CommonControls.CRUDCButtons();
         this.groupBoxFilter = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.radioButtonSemua = new System.Windows.Forms.RadioButton();
         this.radioButtonTipe = new System.Windows.Forms.RadioButton();
         this.comboBoxTipe = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxTipe();
         this.comboBoxSubTipe = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxSubTipe();
         this.radioButtonSupplier = new System.Windows.Forms.RadioButton();
         this.buttonTampilkan = new System.Windows.Forms.Button();
         this.comboBoxSupplier = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxSupplier();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.groupBoxFilter.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
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
         // crudcButtons
         // 
         this.crudcButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.crudcButtons.BackColor = System.Drawing.Color.Transparent;
         this.crudcButtons.Location = new System.Drawing.Point(12, 415);
         this.crudcButtons.Name = "crudcButtons";
         this.crudcButtons.Size = new System.Drawing.Size(954, 35);
         this.crudcButtons.TabIndex = 2;
         // 
         // groupBoxFilter
         // 
         this.groupBoxFilter.Controls.Add(this.tableLayoutPanel2);
         this.groupBoxFilter.Location = new System.Drawing.Point(12, 58);
         this.groupBoxFilter.Name = "groupBoxFilter";
         this.groupBoxFilter.Size = new System.Drawing.Size(464, 138);
         this.groupBoxFilter.TabIndex = 5;
         this.groupBoxFilter.TabStop = false;
         this.groupBoxFilter.Text = "Filter By";
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
         this.tableLayoutPanel2.Controls.Add(this.comboBoxTipe, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.comboBoxSubTipe, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.radioButtonSupplier, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.buttonTampilkan, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.comboBoxSupplier, 1, 2);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(452, 113);
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
         // comboBoxTipe
         // 
         this.comboBoxTipe.DisplayMember = "Value";
         this.comboBoxTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxTipe.FormattingEnabled = true;
         this.comboBoxTipe.Items.AddRange(new object[] {
            ((object)(resources.GetObject("comboBoxTipe.Items"))),
            ((object)(resources.GetObject("comboBoxTipe.Items1"))),
            ((object)(resources.GetObject("comboBoxTipe.Items2"))),
            ((object)(resources.GetObject("comboBoxTipe.Items3"))),
            ((object)(resources.GetObject("comboBoxTipe.Items4"))),
            ((object)(resources.GetObject("comboBoxTipe.Items5"))),
            ((object)(resources.GetObject("comboBoxTipe.Items6"))),
            ((object)(resources.GetObject("comboBoxTipe.Items7"))),
            ((object)(resources.GetObject("comboBoxTipe.Items8"))),
            ((object)(resources.GetObject("comboBoxTipe.Items9"))),
            ((object)(resources.GetObject("comboBoxTipe.Items10"))),
            ((object)(resources.GetObject("comboBoxTipe.Items11")))});
         this.comboBoxTipe.Location = new System.Drawing.Point(72, 26);
         this.comboBoxTipe.Name = "comboBoxTipe";
         this.comboBoxTipe.Size = new System.Drawing.Size(150, 21);
         this.comboBoxTipe.TabIndex = 11;
         this.comboBoxTipe.ValueMember = "Key";
         // 
         // comboBoxSubTipe
         // 
         this.comboBoxSubTipe.DisplayMember = "Value";
         this.comboBoxSubTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxSubTipe.FormattingEnabled = true;
         this.comboBoxSubTipe.Items.AddRange(new object[] {
            ((object)(resources.GetObject("comboBoxSubTipe.Items"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items1"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items2"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items3"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items4"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items5"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items6"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items7"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items8"))),
            ((object)(resources.GetObject("comboBoxSubTipe.Items9")))});
         this.comboBoxSubTipe.Location = new System.Drawing.Point(284, 26);
         this.comboBoxSubTipe.Name = "comboBoxSubTipe";
         this.comboBoxSubTipe.Size = new System.Drawing.Size(150, 21);
         this.comboBoxSubTipe.TabIndex = 12;
         this.comboBoxSubTipe.ValueMember = "Key";
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
            ((object)(resources.GetObject("comboBoxSupplier.Items7")))});
         this.comboBoxSupplier.Location = new System.Drawing.Point(72, 53);
         this.comboBoxSupplier.Name = "comboBoxSupplier";
         this.comboBoxSupplier.Size = new System.Drawing.Size(150, 21);
         this.comboBoxSupplier.TabIndex = 13;
         this.comboBoxSupplier.ValueMember = "Key";
         // 
         // BarangView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(978, 462);
         this.Controls.Add(this.groupBoxFilter);
         this.Controls.Add(this.crudcButtons);
         this.Controls.Add(this.listDataGrid);
         this.Name = "BarangView";
         this.Text = "Barang";
         this.Load += new System.EventHandler(this.BarangView_Load);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.crudcButtons, 0);
         this.Controls.SetChildIndex(this.groupBoxFilter, 0);
         this.Controls.SetChildIndex(this.panelUp, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.groupBoxFilter.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.ListDataGrid listDataGrid;
      private CommonControls.CRUDCButtons crudcButtons;
      private System.Windows.Forms.GroupBox groupBoxFilter;
      private System.Windows.Forms.Button buttonTampilkan;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.RadioButton radioButtonSemua;
      private System.Windows.Forms.RadioButton radioButtonTipe;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private ModelControls.ComboBoxTipe comboBoxTipe;
      private ModelControls.ComboBoxSubTipe comboBoxSubTipe;
      private System.Windows.Forms.RadioButton radioButtonSupplier;
      private ModelControls.ComboBoxSupplier comboBoxSupplier;
   }
}