namespace RumahScarlett.Domain.Models.Laporan
{
   public interface ILabaRugiModel
   {
      decimal total_penjualan { get; set; }
      decimal total_hpp { get; set; }
      decimal total_pengeluaran { get; set; }
      decimal total_diskon_penjualan { get; set; }
   }
}