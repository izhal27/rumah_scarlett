using System;

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public interface IBayarPenjualanEntryView
   {
      event EventHandler<PembayaranEventArgs> OnBayarPenjualan;
   }
}