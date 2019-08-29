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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEntryView));
         this.panelUp = new RumahScarlett.Presentation.Views.CommonControls.PanelUp();
         this.SuspendLayout();
         // 
         // panelUp1
         // 
         this.panelUp.LabelInfo = "Info";
         this.panelUp.Location = new System.Drawing.Point(12, 12);
         this.panelUp.Name = "panelUp1";
         this.panelUp.Size = new System.Drawing.Size(460, 40);
         this.panelUp.TabIndex = 2;
         this.panelUp.TabStop = false;
         // 
         // BaseEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(484, 362);
         this.Controls.Add(this.panelUp);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BaseEntryView";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "BaseEntryView";
         this.Load += new System.EventHandler(this.BaseEntryView_Load);
         this.ResumeLayout(false);

      }

      #endregion

      protected PanelUp panelUp;
   }
}