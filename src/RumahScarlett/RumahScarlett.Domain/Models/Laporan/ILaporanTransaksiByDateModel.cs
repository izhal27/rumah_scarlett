namespace RumahScarlett.Domain.Models.Laporan
{
   public interface ILaporanTransaksiByDateModel
   {
      decimal kas_awal { get; set; }
      decimal total_penjualan { get; set; }
      decimal total_diskon { get; set; }
      decimal total_pengeluaran { get; set; }
      decimal selisih { get; }
   }
}