using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace RumahScarlett.Presentation.Views
{
   public interface IMainView : IView
   {
      event EventHandler<MainViewEventArgs> OnTipeViewClick;
      event EventHandler<MainViewEventArgs> OnSubTipeViewClick;
      event EventHandler<MainViewEventArgs> OnSupplierViewClick;
      event EventHandler<MainViewEventArgs> OnSatuanViewClick;
      event EventHandler<MainViewEventArgs> OnBarangViewClick;
      event EventHandler<MainViewEventArgs> OnPelangganViewClick;
      event EventHandler<MainViewEventArgs> OnPenyesuaianStokViewClick;
      event EventHandler<MainViewEventArgs> OnHutangOperasionalViewClick;
      event EventHandler OnKasAwalViewClick;
      event EventHandler<MainViewEventArgs> OnPenjualanViewClick;
      event EventHandler<MainViewEventArgs> OnPembelianViewClick;
      event EventHandler<MainViewEventArgs> OnPengeluaranViewClick;
      event EventHandler<MainViewEventArgs> OnLaporanPenjualanViewClick;
      event EventHandler<MainViewEventArgs> OnLaporanPembelianViewClick;
      event EventHandler<MainViewEventArgs> OnLaporanPengeluaranViewClick;
      event EventHandler<MainViewEventArgs> OnReturnPenjualanViewClick;
      event EventHandler<MainViewEventArgs> OnReturnPembelianViewClick;
      event EventHandler OnLaporanTransaksiByDateViewClick;
      event EventHandler<MainViewEventArgs> OnLaporanReturnPenjualanViewClick;
      event EventHandler<MainViewEventArgs> OnLaporanReturnPembelianViewClick;
      event EventHandler OnLaporanStatusBarangViewClick;
      event EventHandler OnLaporanLabaRugiViewClick;
      event EventHandler OnPengaturanViewClick;
      event EventHandler OnBackupDatabaseViewClick;
      event EventHandler OnRestoreDatabaseViewClick;
      event EventHandler OnTentangViewClick;
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
