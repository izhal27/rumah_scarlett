﻿namespace RumahScarlett.Presentation.Views.ModelControls
{
   partial class CariBarangView
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
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // CariBarangView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Name = "CariBarangView";
         this.Text = "Cari Barang";
         this.Load += new System.EventHandler(this.CariBarangView_Load);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
   }
}