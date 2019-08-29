namespace RumahScarlett.Presentation.Views.Tipe
{
   partial class TipeEntryView
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
         this.operationButtons = new RumahScarlett.Presentation.Views.CommonControls.OperationButtons();
         this.groupBoxData = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxNama = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.textBoxKeterangan = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.groupBoxData.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxNama)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).BeginInit();
         this.SuspendLayout();
         // 
         // operationButtons
         // 
         this.operationButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.operationButtons.Location = new System.Drawing.Point(12, 228);
         this.operationButtons.Name = "operationButtons";
         this.operationButtons.Size = new System.Drawing.Size(356, 35);
         this.operationButtons.TabIndex = 3;
         this.operationButtons.TabStop = false;
         // 
         // groupBoxData
         // 
         this.groupBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxData.Controls.Add(this.tableLayoutPanel1);
         this.groupBoxData.Location = new System.Drawing.Point(12, 58);
         this.groupBoxData.Name = "groupBoxData";
         this.groupBoxData.Size = new System.Drawing.Size(356, 164);
         this.groupBoxData.TabIndex = 4;
         this.groupBoxData.TabStop = false;
         this.groupBoxData.Text = "[ DATA ]";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.textBoxNama, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.textBoxKeterangan, 1, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 139);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Nama";
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.Color.Red;
         this.label2.Location = new System.Drawing.Point(327, 6);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(11, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "*";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 76);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Keterangan";
         // 
         // textBoxNama
         // 
         this.textBoxNama.BeforeTouchSize = new System.Drawing.Size(250, 100);
         this.textBoxNama.Location = new System.Drawing.Point(71, 3);
         this.textBoxNama.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxNama.Name = "textBoxNama";
         this.textBoxNama.Size = new System.Drawing.Size(250, 20);
         this.textBoxNama.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxNama.TabIndex = 2;
         // 
         // textBoxKeterangan
         // 
         this.textBoxKeterangan.BeforeTouchSize = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Location = new System.Drawing.Point(71, 29);
         this.textBoxKeterangan.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxKeterangan.Multiline = true;
         this.textBoxKeterangan.Name = "textBoxKeterangan";
         this.textBoxKeterangan.Size = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxKeterangan.TabIndex = 2;
         // 
         // TipeEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(380, 275);
         this.Controls.Add(this.groupBoxData);
         this.Controls.Add(this.operationButtons);
         this.Name = "TipeEntryView";
         this.Text = "Tipe";
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.operationButtons, 0);
         this.Controls.SetChildIndex(this.groupBoxData, 0);
         this.groupBoxData.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxNama)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.OperationButtons operationButtons;
      private System.Windows.Forms.GroupBox groupBoxData;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private CommonControls.BaseTextBox textBoxNama;
      private CommonControls.BaseTextBox textBoxKeterangan;
   }
}