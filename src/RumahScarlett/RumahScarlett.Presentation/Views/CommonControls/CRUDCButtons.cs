﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RumahScarlett.CommonComponents;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class CRUDCButtons : UserControl
   {
      public event EventHandler OnTambahClick;
      public event EventHandler OnUbahClick;
      public event EventHandler OnHapusClick;
      public event EventHandler OnRefreshClick;
      public event EventHandler OnCetakClick;
      public event EventHandler OnTutupClick;

      public bool ButtonTambahVisible
      {
         set { buttonTambah.Visible = value; }
      }

      public bool ButtonUbahVisible
      {
         set { buttonUbah.Visible = value; }
      }

      public bool ButtonHapusVisible
      {
         set { buttonHapus.Visible = value; }
      }

      public bool ButtonRefreshVisible
      {
         set { buttonRefresh.Visible = value; }
      }

      public bool ButtonCetakVisible
      {
         set { buttonCetak.Visible = value; }
      }

      public Button ButtonTutup
      {
         get { return buttonTutup; }
      }

      public CRUDCButtons()
      {
         InitializeComponent();
      }

      private void btnTambah_Click(object sender, EventArgs e)
      {
         OnTambahClick?.Invoke(sender, e);
      }

      private void btnUbah_Click(object sender, EventArgs e)
      {
         OnUbahClick?.Invoke(sender, e);
      }

      private void btnHapus_Click(object sender, EventArgs e)
      {
         OnHapusClick?.Invoke(sender, e);
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         OnRefreshClick?.Invoke(sender, e);
      }

      private void btnCetak_Click(object sender, EventArgs e)
      {
         OnCetakClick?.Invoke(sender, e);
      }

      private void btnTutup_Click(object sender, EventArgs e)
      {
         OnTutupClick?.Invoke(sender, e);
      }
   }
}
