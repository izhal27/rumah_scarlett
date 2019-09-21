namespace RumahScarlett.Presentation.Views.Penjualan
{
   partial class UangKembaliView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UangKembaliView));
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.panelInfoDigital = new RumahScarlett.Presentation.Views.CommonControls.PanelInfoDigital();
         this.buttonOk = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.panelInfoDigital, 0, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 70);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // panelInfoDigital
         // 
         this.panelInfoDigital.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.panelInfoDigital.BackColor = System.Drawing.Color.Black;
         this.panelInfoDigital.Location = new System.Drawing.Point(3, 7);
         this.panelInfoDigital.Name = "panelInfoDigital";
         this.panelInfoDigital.Size = new System.Drawing.Size(422, 55);
         this.panelInfoDigital.TabIndex = 10;
         this.panelInfoDigital.TabStop = false;
         // 
         // buttonOk
         // 
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Location = new System.Drawing.Point(365, 94);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 1;
         this.buttonOk.Text = "OK";
         this.buttonOk.UseVisualStyleBackColor = true;
         // 
         // UangKembaliView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(452, 129);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UangKembaliView";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Uang Kembali";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private CommonControls.PanelInfoDigital panelInfoDigital;
      private System.Windows.Forms.Button buttonOk;
   }
}