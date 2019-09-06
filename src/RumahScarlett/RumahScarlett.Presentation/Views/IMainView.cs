using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IMainView : IView
   {
      event EventHandler<MainViewEventArgs> OnTipeViewOpen;
      event EventHandler<MainViewEventArgs> OnSubTipeViewOpen;
      event EventHandler<MainViewEventArgs> OnSupplierViewOpen;
      event EventHandler<MainViewEventArgs> OnSatuanViewOpen;
      event EventHandler<MainViewEventArgs> OnBarangViewOpen;
      event EventHandler<MainViewEventArgs> OnPelangganViewOpen;
      event EventHandler OnKasAwalViewOpen;
      event EventHandler<MainViewEventArgs> OnHutangOperasionalViewOpen;
      event EventHandler<MainViewEventArgs> OnPenjualanViewOpen;
      event EventHandler<MainViewEventArgs> OnPembelianViewOpen;
      event EventHandler<MainViewEventArgs> OnPengeluaranViewOpen;
      event EventHandler<MainViewEventArgs> OnPenyesuaianStokViewOpen;
   }
}
