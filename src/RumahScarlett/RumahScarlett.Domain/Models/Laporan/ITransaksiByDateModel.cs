namespace RumahScarlett.Domain.Models.Laporan
{
   public interface ITransaksiByDateModel
   {
      decimal kas_awal { get; set; }
      decimal total_penjualan { get; set; }
      decimal total_diskon { get; set; }
      decimal total_pengeluaran { get; set; }
      decimal total_return_penjualan{ get; set; }
      decimal selisih { get; }
   }
}