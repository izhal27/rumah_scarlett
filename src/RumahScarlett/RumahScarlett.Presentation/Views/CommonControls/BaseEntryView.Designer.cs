namespace RumahScarlett.Presentation.Views.CommonControls
{
   partial class BaseEntryView
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
         this.panelUp1 = new RumahScarlett.Presentation.Views.CommonControls.PanelUp();
         this.SuspendLayout();
         // 
         // panelUp1
         // 
         this.panelUp1.LabelInfo = "Info";
         this.panelUp1.Location = new System.Drawing.Point(12, 12);
         this.panelUp1.Name = "panelUp1";
         this.panelUp1.Size = new System.Drawing.Size(460, 40);
         this.panelUp1.TabIndex = 2;
         // 
         // BaseEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(484, 362);
         this.Controls.Add(this.panelUp1);
         this.Name = "BaseEntryView";
         this.Text = "BaseEntryView";
         this.Load += new System.EventHandler(this.BaseEntryView_Load);
         this.ResumeLayout(false);

      }

      #endregion
      private PanelUp panelUp1;
   }
}