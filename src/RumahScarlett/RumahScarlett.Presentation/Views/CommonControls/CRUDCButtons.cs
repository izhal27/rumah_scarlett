using System;
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

      public bool ButtonCetakVisible { set { btnCetak.Visible = value; } }

      public CRUDCButtons()
      {
         InitializeComponent();
      }

      private void btnTambah_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnTambahClick, e);
      }

      private void btnUbah_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnUbahClick, e);
      }

      private void btnHapus_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnHapusClick, e);
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnRefreshClick, e);
      }

      private void btnCetak_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCetakClick, e);
      }

      private void btnTutup_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnTutupClick, e);
      }
   }
}
