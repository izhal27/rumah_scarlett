using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IMainView : IView
   {
      event EventHandler OnTipeViewOpen;
      event EventHandler OnSubTipeViewOpen;
      event EventHandler OnSupplierViewOpen;
      event EventHandler OnSatuanViewOpen;
      event EventHandler OnBarangViewOpen;
      event EventHandler OnPelangganViewOpen;
      event EventHandler OnKasAwalViewOpen;
      event EventHandler OnHutangOperasionalViewOpen;
      event EventHandler OnPenjualanViewOpen;
      event EventHandler OnPembelianViewOpen;
      event EventHandler OnPengeluaranViewOpen;
      event EventHandler OnPenyesuaianStokViewOpen;
   }
}
