using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      event EventHandler OnLaporanTransaksiByDateClick;
   }
}
