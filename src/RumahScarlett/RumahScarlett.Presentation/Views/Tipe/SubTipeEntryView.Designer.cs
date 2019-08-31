namespace RumahScarlett.Presentation.Views.Tipe
{
   partial class SubTipeEntryView
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubTipeEntryView));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxNama = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.textBoxKeterangan = new RumahScarlett.Presentation.Views.CommonControls.BaseTextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.comboBoxTipe = new RumahScarlett.Presentation.Views.ModelControls.ComboBoxTipe();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxNama)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).BeginInit();
         this.SuspendLayout();
         // 
         // panelUp
         // 
         this.panelUp.Size = new System.Drawing.Size(358, 40);
         // 
         // operationButtons
         // 
         this.operationButtons.Location = new System.Drawing.Point(195, 252);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(12, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(358, 188);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ DATA ]";
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
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.textBoxNama, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.textBoxKeterangan, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboBoxTipe, 1, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 163);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 33);
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
         this.label2.Location = new System.Drawing.Point(327, 33);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(11, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "*";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 101);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Keterangan";
         // 
         // textBoxNama
         // 
         this.textBoxNama.BeforeTouchSize = new System.Drawing.Size(250, 100);
         this.textBoxNama.Location = new System.Drawing.Point(71, 30);
         this.textBoxNama.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxNama.Name = "textBoxNama";
         this.textBoxNama.Size = new System.Drawing.Size(250, 20);
         this.textBoxNama.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxNama.TabIndex = 1;
         // 
         // textBoxKeterangan
         // 
         this.textBoxKeterangan.BeforeTouchSize = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Location = new System.Drawing.Point(71, 56);
         this.textBoxKeterangan.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
         this.textBoxKeterangan.Multiline = true;
         this.textBoxKeterangan.Name = "textBoxKeterangan";
         this.textBoxKeterangan.Size = new System.Drawing.Size(250, 100);
         this.textBoxKeterangan.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
         this.textBoxKeterangan.TabIndex = 2;
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 7);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(28, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Tipe";
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.ForeColor = System.Drawing.Color.Red;
         this.label5.Location = new System.Drawing.Point(327, 7);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(11, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "*";
         // 
         // comboBoxTipe
         // 
         this.comboBoxTipe.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBoxTipe.DisplayMember = "Value";
         this.comboBoxTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxTipe.FormattingEnabled = true;
         this.comboBoxTipe.Items.AddRange(new object[] {
            ((object)(resources.GetObject("comboBoxTipe.Items"))),
            ((object)(resources.GetObject("comboBoxTipe.Items1"))),
            ((object)(resources.GetObject("comboBoxTipe.Items2"))),
            ((object)(resources.GetObject("comboBoxTipe.Items3"))),
            ((object)(resources.GetObject("comboBoxTipe.Items4"))),
            ((object)(resources.GetObject("comboBoxTipe.Items5"))),
            ((object)(resources.GetObject("comboBoxTipe.Items6"))),
            ((object)(resources.GetObject("comboBoxTipe.Items7"))),
            ((object)(resources.GetObject("comboBoxTipe.Items8"))),
            ((object)(resources.GetObject("comboBoxTipe.Items9"))),
            ((object)(resources.GetObject("comboBoxTipe.Items10"))),
            ((object)(resources.GetObject("comboBoxTipe.Items11")))});
         this.comboBoxTipe.Location = new System.Drawing.Point(71, 3);
         this.comboBoxTipe.Name = "comboBoxTipe";
         this.comboBoxTipe.Size = new System.Drawing.Size(250, 21);
         this.comboBoxTipe.TabIndex = 3;
         this.comboBoxTipe.ValueMember = "Key";
         // 
         // SubTipeEntryView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(382, 299);
         this.Controls.Add(this.groupBox1);
         this.Name = "SubTipeEntryView";
         this.Text = "Sub Tipe";
         this.Load += new System.EventHandler(this.SubTipeEntryView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.operationButtons, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxNama)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textBoxKeterangan)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private CommonControls.BaseTextBox textBoxNama;
      private CommonControls.BaseTextBox textBoxKeterangan;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private ModelControls.ComboBoxTipe comboBoxTipe;
   }
}