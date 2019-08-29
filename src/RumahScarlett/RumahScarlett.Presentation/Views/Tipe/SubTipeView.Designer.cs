namespace RumahScarlett.Presentation.Views.Tipe
{
   partial class SubTipeView
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
         this.treeViewTipe = new System.Windows.Forms.TreeView();
         this.buttonsCRUD = new RumahScarlett.Presentation.Views.CommonControls.CRUDCButtons();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
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
         this.listDataGrid.Location = new System.Drawing.Point(268, 58);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.Size = new System.Drawing.Size(504, 351);
         this.listDataGrid.TabIndex = 2;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // treeViewTipe
         // 
         this.treeViewTipe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.treeViewTipe.Location = new System.Drawing.Point(12, 58);
         this.treeViewTipe.Name = "treeViewTipe";
         this.treeViewTipe.Size = new System.Drawing.Size(250, 351);
         this.treeViewTipe.TabIndex = 3;
         // 
         // buttonsCRUD
         // 
         this.buttonsCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonsCRUD.BackColor = System.Drawing.Color.Transparent;
         this.buttonsCRUD.Location = new System.Drawing.Point(12, 415);
         this.buttonsCRUD.Name = "buttonsCRUD";
         this.buttonsCRUD.Size = new System.Drawing.Size(760, 35);
         this.buttonsCRUD.TabIndex = 4;
         // 
         // SubTipeView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.buttonsCRUD);
         this.Controls.Add(this.treeViewTipe);
         this.Controls.Add(this.listDataGrid);
         this.Name = "SubTipeView";
         this.Text = "Sub Tipe";
         this.Load += new System.EventHandler(this.SubTipeView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.treeViewTipe, 0);
         this.Controls.SetChildIndex(this.buttonsCRUD, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.ListDataGrid listDataGrid;
      private System.Windows.Forms.TreeView treeViewTipe;
      private CommonControls.CRUDCButtons buttonsCRUD;
   }
}