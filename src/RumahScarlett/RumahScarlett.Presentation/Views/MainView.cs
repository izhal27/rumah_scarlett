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
      private MainViewEventArgs _eventArgs;

      public event EventHandler<MainViewEventArgs> OnTipeViewClick;
      public event EventHandler<MainViewEventArgs> OnSubTipeViewClick;
      public event EventHandler<MainViewEventArgs> OnSupplierViewClick;
      public event EventHandler<MainViewEventArgs> OnSatuanViewClick;
      public event EventHandler<MainViewEventArgs> OnBarangViewClick;
      public event EventHandler<MainViewEventArgs> OnPelangganViewClick;
      public event EventHandler<MainViewEventArgs> OnPenyesuaianStokViewClick;
      public event EventHandler<MainViewEventArgs> OnHutangOperasionalViewClick;
      public event EventHandler OnKasAwalViewClick;
      public event EventHandler<MainViewEventArgs> OnPenjualanViewClick;
      public event EventHandler<MainViewEventArgs> OnPembelianViewClick;
      public event EventHandler<MainViewEventArgs> OnPengeluaranViewClick;
      public event EventHandler<MainViewEventArgs> OnLaporanPenjualanViewClick;
      public event EventHandler<MainViewEventArgs> OnLaporanPembelianViewClick;
      public event EventHandler<MainViewEventArgs> OnLaporanPengeluaranViewClick;
      public event EventHandler OnLaporanTransaksiByDateClick;
      public event EventHandler OnLaporanStatusBarangClick;

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

         _eventArgs = new MainViewEventArgs(_dockPanel);
      }

      private void toolStripMenuItemExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void toolStripMenuItemTipe_Click(object sender, EventArgs e)
      {
         OnTipeViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemSubTipe_Click(object sender, EventArgs e)
      {
         OnSubTipeViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemSupplier_Click(object sender, EventArgs e)
      {
         OnSupplierViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemBarang_Click(object sender, EventArgs e)
      {
         OnBarangViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripButtonBarang_Click(object sender, EventArgs e)
      {
         toolStripMenuItemBarang_Click(sender, e);
      }

      private void toolStripMenuItemSatuan_Click(object sender, EventArgs e)
      {
         OnSatuanViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemPelanggan_Click(object sender, EventArgs e)
      {
         OnPelangganViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemPenyesuaianStok_Click(object sender, EventArgs e)
      {
         OnPenyesuaianStokViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemHutangOperasional_Click(object sender, EventArgs e)
      {
         OnHutangOperasionalViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemKasAwal_Click(object sender, EventArgs e)
      {
         OnKasAwalViewClick?.Invoke(sender, e);
      }

      private void toolStripMenuItemPenjualan_Click(object sender, EventArgs e)
      {
         OnPenjualanViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripButtonPenjualan_Click(object sender, EventArgs e)
      {
         toolStripMenuItemPenjualan_Click(sender, e);
      }

      private void toolStripMenuItemPembelian_Click(object sender, EventArgs e)
      {
         OnPembelianViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripButtonPembelian_Click(object sender, EventArgs e)
      {
         toolStripMenuItemPembelian_Click(sender, e);
      }

      private void toolStripMenuItemPengeluaran_Click(object sender, EventArgs e)
      {
         OnPengeluaranViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemLaporanPenjualan_Click(object sender, EventArgs e)
      {
         OnLaporanPenjualanViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemLaporanPembelian_Click(object sender, EventArgs e)
      {
         OnLaporanPembelianViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemLaporanPengeluaran_Click(object sender, EventArgs e)
      {
         OnLaporanPengeluaranViewClick?.Invoke(sender, _eventArgs);
      }

      private void toolStripMenuItemTransaksiByDate_Click(object sender, EventArgs e)
      {
         OnLaporanTransaksiByDateClick?.Invoke(sender, e);
      }

      private void toolStripMenuItemStatusBarang_Click(object sender, EventArgs e)
      {
         OnLaporanStatusBarangClick?.Invoke(sender, e);
      }
   }

   public class MainViewEventArgs : EventArgs
   {
      public DockPanel DockPanel { get; }

      public MainViewEventArgs(DockPanel dockPanel)
      {
         DockPanel = dockPanel;
      }
   }
}
