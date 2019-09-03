namespace RumahScarlett.Presentation.Views.Pengeluaran
{
   partial class PengeluaranView
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
         this.crudcButtons = new RumahScarlett.Presentation.Views.CommonControls.CRUDCButtons();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label5 = new System.Windows.Forms.Label();
         this.labelTotal = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.AllowEditing = false;
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 122);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.ShowRowHeader = true;
         this.listDataGrid.Size = new System.Drawing.Size(534, 287);
         this.listDataGrid.TabIndex = 1;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // crudcButtons
         // 
         this.crudcButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.crudcButtons.BackColor = System.Drawing.Color.Transparent;
         this.crudcButtons.Location = new System.Drawing.Point(12, 415);
         this.crudcButtons.Name = "crudcButtons";
         this.crudcButtons.Size = new System.Drawing.Size(760, 35);
         this.crudcButtons.TabIndex = 2;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(222, 58);
         this.groupBox1.TabIndex = 3;
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
         this.tableLayoutPanel1.Controls.Add(this.dateTimePickerTanggal, 1, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(210, 33);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 10);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tanggal";
         // 
         // dateTimePickerTanggal
         // 
         this.dateTimePickerTanggal.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dateTimePickerTanggal.Location = new System.Drawing.Point(55, 6);
         this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
         this.dateTimePickerTanggal.Size = new System.Drawing.Size(150, 20);
         this.dateTimePickerTanggal.TabIndex = 1;
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.tableLayoutPanel2);
         this.groupBox2.Location = new System.Drawing.Point(552, 122);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(220, 55);
         this.groupBox2.TabIndex = 4;
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
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.labelTotal, 2, 0);
         this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 30);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(3, 8);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(31, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Total";
         // 
         // labelTotal
         // 
         this.labelTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelTotal.AutoSize = true;
         this.labelTotal.Location = new System.Drawing.Point(192, 8);
         this.labelTotal.Name = "labelTotal";
         this.labelTotal.Size = new System.Drawing.Size(13, 13);
         this.labelTotal.TabIndex = 1;
         this.labelTotal.Text = "0";
         // 
         // label6
         // 
         this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(42, 8);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(10, 13);
         this.label6.TabIndex = 0;
         this.label6.Text = ":";
         // 
         // PengeluaranView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.crudcButtons);
         this.Controls.Add(this.listDataGrid);
         this.Name = "PengeluaranView";
         this.Text = "Pengeluaran";
         this.Load += new System.EventHandler(this.PengeluaranView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.crudcButtons, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.Controls.SetChildIndex(this.groupBox2, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.ListDataGrid listDataGrid;
      private CommonControls.CRUDCButtons crudcButtons;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label labelTotal;
      private System.Windows.Forms.Label label6;
   }
}