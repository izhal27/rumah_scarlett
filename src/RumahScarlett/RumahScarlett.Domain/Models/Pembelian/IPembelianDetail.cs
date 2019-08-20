namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianDetail
   {
      uint id { get; set; }
      uint pembelian_id { get; set; }
      uint barang_id { get; set; }
      string barang_nama { get; set; }
      uint qty { get; set; }
      decimal hpp { get; set; }
      decimal total { get; set; }
   }
}