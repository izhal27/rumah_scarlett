﻿namespace RumahScarlett.Presentation.Views.HutangOperasional
{
   partial class HutangOperasionalView
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
         this.crudcButtons = new RumahScarlett.Presentation.Views.CommonControls.CRUDCButtons();
         this.listDataGrid = new RumahScarlett.Presentation.Views.CommonControls.ListDataGrid();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.labelBelumLunas = new System.Windows.Forms.Label();
         this.labelLunas = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.labelTotal = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // crudcButtons
         // 
         this.crudcButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.crudcButtons.BackColor = System.Drawing.Color.Transparent;
         this.crudcButtons.Location = new System.Drawing.Point(12, 415);
         this.crudcButtons.Name = "crudcButtons";
         this.crudcButtons.Size = new System.Drawing.Size(760, 35);
         this.crudcButtons.TabIndex = 1;
         // 
         // listDataGrid
         // 
         this.listDataGrid.AccessibleName = "Table";
         this.listDataGrid.AllowEditing = false;
         this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
         this.listDataGrid.Location = new System.Drawing.Point(12, 58);
         this.listDataGrid.Name = "listDataGrid";
         this.listDataGrid.Size = new System.Drawing.Size(525, 351);
         this.listDataGrid.TabIndex = 2;
         this.listDataGrid.Text = "listDataGrid1";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Location = new System.Drawing.Point(543, 58);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(229, 145);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "[ DATA ]";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.labelLunas, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.labelTotal, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.labelBelumLunas, 1, 3);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(217, 120);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 38);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(36, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Lunas";
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label3.AutoSize = true;
         this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
         this.label3.Location = new System.Drawing.Point(4, 68);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(208, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "-------------------------------------------------------------------";
         // 
         // labelBelumLunas
         // 
         this.labelBelumLunas.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelBelumLunas.AutoSize = true;
         this.labelBelumLunas.Location = new System.Drawing.Point(201, 98);
         this.labelBelumLunas.Name = "labelBelumLunas";
         this.labelBelumLunas.Size = new System.Drawing.Size(13, 13);
         this.labelBelumLunas.TabIndex = 1;
         this.labelBelumLunas.Text = "0";
         // 
         // labelLunas
         // 
         this.labelLunas.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelLunas.AutoSize = true;
         this.labelLunas.Location = new System.Drawing.Point(201, 38);
         this.labelLunas.Name = "labelLunas";
         this.labelLunas.Size = new System.Drawing.Size(13, 13);
         this.labelLunas.TabIndex = 1;
         this.labelLunas.Text = "0";
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 98);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(68, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Belum Lunas";
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(3, 8);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(31, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Total";
         // 
         // labelTotal
         // 
         this.labelTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
         this.labelTotal.AutoSize = true;
         this.labelTotal.Location = new System.Drawing.Point(201, 8);
         this.labelTotal.Name = "labelTotal";
         this.labelTotal.Size = new System.Drawing.Size(13, 13);
         this.labelTotal.TabIndex = 1;
         this.labelTotal.Text = "0";
         // 
         // HutangOperasionalView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 462);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.listDataGrid);
         this.Controls.Add(this.crudcButtons);
         this.Name = "HutangOperasionalView";
         this.Text = "Hutang Operasional";
         this.Load += new System.EventHandler(this.HutangOperasionalView_Load);
         this.Controls.SetChildIndex(this.panelUp, 0);
         this.Controls.SetChildIndex(this.crudcButtons, 0);
         this.Controls.SetChildIndex(this.listDataGrid, 0);
         this.Controls.SetChildIndex(this.groupBox1, 0);
         ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private CommonControls.CRUDCButtons crudcButtons;
      private CommonControls.ListDataGrid listDataGrid;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label labelBelumLunas;
      private System.Windows.Forms.Label labelLunas;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label labelTotal;
   }
}