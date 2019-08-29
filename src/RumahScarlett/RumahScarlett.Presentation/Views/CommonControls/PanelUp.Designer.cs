namespace RumahScarlett.Presentation.Views.CommonControls
{
   partial class PanelUp
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.pnlUp = new System.Windows.Forms.Panel();
         this.lblInfo = new System.Windows.Forms.Label();
         this.pnlUp.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlUp
         // 
         this.pnlUp.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
         this.pnlUp.Controls.Add(this.lblInfo);
         this.pnlUp.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlUp.Location = new System.Drawing.Point(0, 0);
         this.pnlUp.Name = "pnlUp";
         this.pnlUp.Size = new System.Drawing.Size(803, 40);
         this.pnlUp.TabIndex = 1;
         // 
         // lblInfo
         // 
         this.lblInfo.AutoSize = true;
         this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblInfo.ForeColor = System.Drawing.SystemColors.Control;
         this.lblInfo.Location = new System.Drawing.Point(12, 10);
         this.lblInfo.Name = "lblInfo";
         this.lblInfo.Size = new System.Drawing.Size(37, 20);
         this.lblInfo.TabIndex = 1;
         this.lblInfo.Text = "Info";
         // 
         // PanelUp
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlUp);
         this.Name = "PanelUp";
         this.Size = new System.Drawing.Size(803, 40);
         this.pnlUp.ResumeLayout(false);
         this.pnlUp.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.Panel pnlUp;
      protected System.Windows.Forms.Label lblInfo;
   }
}
