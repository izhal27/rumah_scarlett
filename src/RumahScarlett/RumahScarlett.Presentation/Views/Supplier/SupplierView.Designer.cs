namespace RumahScarlett.Presentation.Views.Supplier
{
   partial class SupplierView
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
         this.crudcButtons = new RumahScarlett.Presentation.Views.CommonControls.CRUDCButtons();
         this.listDataGrid = new RumahScarlett.Presentation.Views.CommonControls.ListDataGrid();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // crudcButtons
         // 
         this.crudcButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.crudcButtons.BackColor = System.Drawing.Color.Transparent;
         this.crudcButtons.Location = new System.Drawing.Point(12, 415);
         this.crudcButtons.Name = "crudcButtons";
         this.crudcButtons.Size = new System.Drawing.Size(760, 35);
         this.crudcButtons.TabIndex = 1;
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.AllowEditing = false;
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 58);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.Size = new System.Drawing.Size(760, 351);
         this.listDataGrid.TabIndex = 2;
         this.listDataGrid.TabStop = false;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // SupplierView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.listDataGrid);
         this.Controls.Add(this.crudcButtons);
         this.Name = "SupplierView";
         this.Text = "Supplier";
         this.Load += new System.EventHandler(this.SupplierView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.crudcButtons, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.CRUDCButtons crudcButtons;
      private CommonControls.ListDataGrid listDataGrid;
   }
}