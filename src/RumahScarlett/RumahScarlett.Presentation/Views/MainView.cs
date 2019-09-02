using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Presenters.Barang;
using RumahScarlett.Presentation.Presenters.HutangOperasional;
using RumahScarlett.Presentation.Presenters.KasAwal;
using RumahScarlett.Presentation.Presenters.Pelanggan;
using RumahScarlett.Presentation.Presenters.Satuan;
using RumahScarlett.Presentation.Presenters.Supplier;
using RumahScarlett.Presentation.Presenters.Tipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RumahScarlett.Presentation.Views
{
   public partial class MainView : DockContent, IMainView
   {
      private DockPanel _dockPanel;

      public event EventHandler OnTipeViewOpen;
      public event EventHandler OnSubTipeViewOpen;
      public event EventHandler OnSupplierViewOpen;
      public event EventHandler OnSatuanViewOpen;
      public event EventHandler OnBarangViewOpen;
      public event EventHandler OnPelangganViewOpen;
      public event EventHandler OnKasAwalViewOpen;
      public event EventHandler OnHutangOperasionalViewOpen;
      public event EventHandler OnPenjualanViewOpen;
      public event EventHandler OnPembelianViewOpen;
      public event EventHandler OnPengeluaranViewOpen;
      public event EventHandler OnPenyesuaianStokViewOpen;

      public MainView()
      {
         InitializeComponent();

         _dockPanel = new DockPanel();
         _dockPanel.Parent = this;
         _dockPanel.Dock = DockStyle.Fill;
         _dockPanel.BackgroundImageLayout = ImageLayout.Stretch;
         _dockPanel.BringToFront();
         _dockPanel.DocumentTabStripLocation = DocumentTabStripLocation.Top;
         _dockPanel.AllowEndUserDocking = false;
         _dockPanel.AllowEndUserNestedDocking = false;
         _dockPanel.ShowDocumentIcon = false;
         //_dockPanel.Theme = new VS2015LightTheme();
         _dockPanel.DockBackColor = Color.Transparent;
      }
      
      private void tipeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnTipeViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }
      
      private void subTipeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnSubTipeViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnSupplierViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }
      
      private void supplierToolStripButton_Click(object sender, EventArgs e)
      {
         supplierToolStripMenuItem_Click(sender, e);
      }

      private void barangToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnBarangViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void barangToolStripButton_Click(object sender, EventArgs e)
      {
         barangToolStripMenuItem_Click(sender, e);
      }

      private void satuanToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnSatuanViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPelangganViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void kasAwalToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         OnKasAwalViewOpen?.Invoke(sender, e);
      }

      private void hutangOperasionalToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnHutangOperasionalViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPenjualanViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void penjualanToolStripButton_Click(object sender, EventArgs e)
      {
         penjualanToolStripMenuItem_Click(sender, e);
      }

      private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPembelianViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void pengeluaranToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPengeluaranViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }

      private void penyesuaianStokToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPenyesuaianStokViewOpen?.Invoke(sender, new EventArgs<DockPanel>(_dockPanel));
      }
   }
}
