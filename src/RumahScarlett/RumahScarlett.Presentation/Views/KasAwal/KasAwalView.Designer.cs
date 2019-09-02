namespace RumahScarlett.Presentation.Views.KasAwal
{
   partial class KasAwalView
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
         this.label1 = new System.Windows.Forms.Label();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.textBoxTotal = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBoxDigit();
         this.buttonSave = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTotal)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(31, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Total";
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
         this.tableLayoutPanel1.Controls.Add(this.textBoxTotal, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.buttonSave, 1, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 57);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // textBoxTotal
         // 
         this.textBoxTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBoxTotal.BackGroundColor = System.Drawing.SystemColors.Window;
         this.textBoxTotal.BeforeTouchSize = new System.Drawing.Size(150, 20);
         this.textBoxTotal.IntegerValue = ((long)(0));
         this.textBoxTotal.Location = new System.Drawing.Point(40, 3);
         this.textBoxTotal.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxTotal.MinValue = ((long)(0));
         this.textBoxTotal.Name = "textBoxTotal";
         this.textBoxTotal.NullString = "";
         this.textBoxTotal.Size = new System.Drawing.Size(150, 20);
         this.textBoxTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxTotal.TabIndex = 1;
         this.textBoxTotal.Text = "0";
         this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // buttonSave
         // 
         this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.buttonSave.Location = new System.Drawing.Point(117, 30);
         this.buttonSave.Name = "buttonSave";
         this.buttonSave.Size = new System.Drawing.Size(75, 23);
         this.buttonSave.TabIndex = 2;
         this.buttonSave.Text = "&Simpan";
         this.buttonSave.UseVisualStyleBackColor = true;
         this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
         // 
         // KasAwalView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(219, 81);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "KasAwalView";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Kas Awal";
         this.Load += new System.EventHandler(this.KasAwalView_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KasAwalView_KeyDown);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxTotal)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private CommonControls.BaseTextBoxDigit textBoxTotal;
      private System.Windows.Forms.Button buttonSave;
   }
}