namespace RumahScarlett.Presentation.Views.CommonControls
{
   partial class NavigationEntryButtons
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
         this.btnFirst = new System.Windows.Forms.Button();
         this.btnReverse = new System.Windows.Forms.Button();
         this.btnLast = new System.Windows.Forms.Button();
         this.btnNext = new System.Windows.Forms.Button();
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.tlpButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnFirst
         // 
         this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.btnFirst.Location = new System.Drawing.Point(4, 6);
         this.btnFirst.Name = "btnFirst";
         this.btnFirst.Size = new System.Drawing.Size(65, 23);
         this.btnFirst.TabIndex = 2;
         this.btnFirst.Tag = "ignore";
         this.btnFirst.Text = "|<";
         this.btnFirst.UseVisualStyleBackColor = true;
         this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
         // 
         // btnReverse
         // 
         this.btnReverse.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.btnReverse.Location = new System.Drawing.Point(75, 6);
         this.btnReverse.Name = "btnReverse";
         this.btnReverse.Size = new System.Drawing.Size(65, 23);
         this.btnReverse.TabIndex = 2;
         this.btnReverse.Tag = "ignore";
         this.btnReverse.Text = "<<";
         this.btnReverse.UseVisualStyleBackColor = true;
         this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
         // 
         // btnLast
         // 
         this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnLast.Location = new System.Drawing.Point(217, 6);
         this.btnLast.Name = "btnLast";
         this.btnLast.Size = new System.Drawing.Size(65, 23);
         this.btnLast.TabIndex = 2;
         this.btnLast.Tag = "ignore";
         this.btnLast.Text = ">|";
         this.btnLast.UseVisualStyleBackColor = true;
         this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
         // 
         // btnNext
         // 
         this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnNext.Location = new System.Drawing.Point(146, 6);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(65, 23);
         this.btnNext.TabIndex = 2;
         this.btnNext.Tag = "ignore";
         this.btnNext.Text = ">>";
         this.btnNext.UseVisualStyleBackColor = true;
         this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
         // 
         // tlpButtons
         // 
         this.tlpButtons.ColumnCount = 4;
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpButtons.Controls.Add(this.btnFirst, 0, 0);
         this.tlpButtons.Controls.Add(this.btnLast, 3, 0);
         this.tlpButtons.Controls.Add(this.btnReverse, 1, 0);
         this.tlpButtons.Controls.Add(this.btnNext, 2, 0);
         this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpButtons.Location = new System.Drawing.Point(0, 0);
         this.tlpButtons.Name = "tlpButtons";
         this.tlpButtons.RowCount = 1;
         this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpButtons.Size = new System.Drawing.Size(286, 35);
         this.tlpButtons.TabIndex = 3;
         // 
         // NavigationEntryButtons
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpButtons);
         this.Name = "NavigationEntryButtons";
         this.Size = new System.Drawing.Size(286, 35);
         this.tlpButtons.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion
      protected System.Windows.Forms.Button btnFirst;
      protected System.Windows.Forms.Button btnReverse;
      protected System.Windows.Forms.Button btnLast;
      protected System.Windows.Forms.Button btnNext;
      private System.Windows.Forms.TableLayoutPanel tlpButtons;
   }
}
