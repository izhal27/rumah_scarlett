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

      public event EventHandler<MainViewEventArgs> OnTipeViewOpen;
      public event EventHandler<MainViewEventArgs> OnSubTipeViewOpen;
      public event EventHandler<MainViewEventArgs> OnSupplierViewOpen;
      public event EventHandler<MainViewEventArgs> OnSatuanViewOpen;
      public event EventHandler<MainViewEventArgs> OnBarangViewOpen;
      public event EventHandler<MainViewEventArgs> OnPelangganViewOpen;
      public event EventHandler OnKasAwalViewOpen;
      public event EventHandler<MainViewEventArgs> OnHutangOperasionalViewOpen;
      public event EventHandler<MainViewEventArgs> OnPenjualanViewOpen;
      public event EventHandler<MainViewEventArgs> OnPembelianViewOpen;
      public event EventHandler<MainViewEventArgs> OnPengeluaranViewOpen;
      public event EventHandler<MainViewEventArgs> OnPenyesuaianStokViewOpen;

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
         OnTipeViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }
      
      private void subTipeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnSubTipeViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnSupplierViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }
      
      private void barangToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnBarangViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void toolStripButtonBarang_Click(object sender, EventArgs e)
      {
         barangToolStripMenuItem_Click(sender, e);
      }

      private void satuanToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnSatuanViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPelangganViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void kasAwalToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         OnKasAwalViewOpen?.Invoke(sender, e);
      }

      private void hutangOperasionalToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnHutangOperasionalViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPenjualanViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void toolStripButtonPenjualan_Click(object sender, EventArgs e)
      {
         penjualanToolStripMenuItem_Click(sender, e);
      }

      private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPembelianViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }
      
      private void toolStripButtonPembelian_Click(object sender, EventArgs e)
      {
         pembelianToolStripMenuItem_Click(sender, e);
      }

      private void pengeluaranToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPengeluaranViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }

      private void penyesuaianStokToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OnPenyesuaianStokViewOpen?.Invoke(sender, new MainViewEventArgs(_dockPanel));
      }
   }

   public class MainViewEventArgs : EventArgs
   {
      public DockPanel DockPanel { get; private set; }

      public MainViewEventArgs(DockPanel dockPanel)
      {
         DockPanel = dockPanel;
      }
   }
}
