namespace RumahScarlett.Presentation.Views.CommonControls
{
   partial class ButtonsCRUD
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
         this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
         this.btnTambah = new System.Windows.Forms.Button();
         this.btnRefresh = new System.Windows.Forms.Button();
         this.btnUbah = new System.Windows.Forms.Button();
         this.btnHapus = new System.Windows.Forms.Button();
         this.btnTutup = new System.Windows.Forms.Button();
         this.btnCetak = new System.Windows.Forms.Button();
         this.tlpButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // tlpButtons
         // 
         this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tlpButtons.BackColor = System.Drawing.SystemColors.Control;
         this.tlpButtons.ColumnCount = 6;
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpButtons.Controls.Add(this.btnTambah, 0, 0);
         this.tlpButtons.Controls.Add(this.btnRefresh, 3, 0);
         this.tlpButtons.Controls.Add(this.btnUbah, 1, 0);
         this.tlpButtons.Controls.Add(this.btnHapus, 2, 0);
         this.tlpButtons.Controls.Add(this.btnTutup, 5, 0);
         this.tlpButtons.Controls.Add(this.btnCetak, 4, 0);
         this.tlpButtons.Location = new System.Drawing.Point(0, 0);
         this.tlpButtons.Name = "tlpButtons";
         this.tlpButtons.RowCount = 1;
         this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpButtons.Size = new System.Drawing.Size(760, 35);
         this.tlpButtons.TabIndex = 3;
         // 
         // btnTambah
         // 
         this.btnTambah.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnTambah.Location = new System.Drawing.Point(3, 6);
         this.btnTambah.Name = "btnTambah";
         this.btnTambah.Size = new System.Drawing.Size(75, 23);
         this.btnTambah.TabIndex = 1;
         this.btnTambah.Tag = "Tambah";
         this.btnTambah.Text = "&Tambah";
         this.btnTambah.UseVisualStyleBackColor = true;
         this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
         // 
         // btnRefresh
         // 
         this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnRefresh.Location = new System.Drawing.Point(246, 6);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(75, 23);
         this.btnRefresh.TabIndex = 4;
         this.btnRefresh.Tag = "Refresh";
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.UseVisualStyleBackColor = true;
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // btnUbah
         // 
         this.btnUbah.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnUbah.Location = new System.Drawing.Point(84, 6);
         this.btnUbah.Name = "btnUbah";
         this.btnUbah.Size = new System.Drawing.Size(75, 23);
         this.btnUbah.TabIndex = 2;
         this.btnUbah.Tag = "Ubah";
         this.btnUbah.Text = "&Ubah";
         this.btnUbah.UseVisualStyleBackColor = true;
         this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
         // 
         // btnHapus
         // 
         this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnHapus.Location = new System.Drawing.Point(165, 6);
         this.btnHapus.Name = "btnHapus";
         this.btnHapus.Size = new System.Drawing.Size(75, 23);
         this.btnHapus.TabIndex = 3;
         this.btnHapus.Tag = "Hapus";
         this.btnHapus.Text = "&Hapus";
         this.btnHapus.UseVisualStyleBackColor = true;
         this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
         // 
         // btnTutup
         // 
         this.btnTutup.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.btnTutup.Location = new System.Drawing.Point(682, 6);
         this.btnTutup.Name = "btnTutup";
         this.btnTutup.Size = new System.Drawing.Size(75, 23);
         this.btnTutup.TabIndex = 10;
         this.btnTutup.Tag = "ignore";
         this.btnTutup.Text = "Tutu&p";
         this.btnTutup.UseVisualStyleBackColor = true;
         this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
         // 
         // btnCetak
         // 
         this.btnCetak.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.btnCetak.Location = new System.Drawing.Point(327, 6);
         this.btnCetak.Name = "btnCetak";
         this.btnCetak.Size = new System.Drawing.Size(75, 23);
         this.btnCetak.TabIndex = 4;
         this.btnCetak.Tag = "Cetak";
         this.btnCetak.Text = "&Cetak";
         this.btnCetak.UseVisualStyleBackColor = true;
         this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
         // 
         // ButtonsCRUD
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Transparent;
         this.Controls.Add(this.tlpButtons);
         this.Name = "ButtonsCRUD";
         this.Size = new System.Drawing.Size(760, 35);
         this.tlpButtons.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.TableLayoutPanel tlpButtons;
      protected System.Windows.Forms.Button btnTambah;
      protected System.Windows.Forms.Button btnRefresh;
      protected System.Windows.Forms.Button btnUbah;
      protected System.Windows.Forms.Button btnHapus;
      protected System.Windows.Forms.Button btnTutup;
      protected System.Windows.Forms.Button btnCetak;
   }
}
