namespace RumahScarlett.Presentation.Views.CommonControls
{
   partial class ReportView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
         this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
         this.SuspendLayout();
         // 
         // reportViewer1
         // 
         this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.reportViewer1.Location = new System.Drawing.Point(0, 0);
         this.reportViewer1.Name = "reportViewer1";
         this.reportViewer1.Size = new System.Drawing.Size(684, 462);
         this.reportViewer1.TabIndex = 0;
         // 
         // ReportView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(684, 462);
         this.Controls.Add(this.reportViewer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ReportView";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Tag = "ignore";
         this.Text = "ReportPreview";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.ResumeLayout(false);

      }

      #endregion

      private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
   }
}