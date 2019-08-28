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
   public partial class ButtonsCRUD : UserControl
   {
      public event EventHandler OnTambahClickEvent;
      public event EventHandler OnUbahClickEvent;
      public event EventHandler OnHapusClickEvent;
      public event EventHandler OnRefreshClickEvent;
      public event EventHandler OnCetakClickEvent;
      public event EventHandler OnTutupClickEvent;

      public bool ButtonCetakVisible { set { btnCetak.Visible = value; } }

      public ButtonsCRUD()
      {
         InitializeComponent();
      }

      private void btnTambah_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnTambahClickEvent, e);
      }

      private void btnUbah_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnUbahClickEvent, e);
      }

      private void btnHapus_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnHapusClickEvent, e);
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnRefreshClickEvent, e);
      }

      private void btnCetak_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCetakClickEvent, e);
      }

      private void btnTutup_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnTutupClickEvent, e);
      }
   }
}
