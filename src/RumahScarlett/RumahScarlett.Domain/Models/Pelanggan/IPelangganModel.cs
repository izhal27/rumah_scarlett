namespace RumahScarlett.Domain.Models.Pelanggan
{
   public interface IPelangganModel
   {
      uint id { get; set; }
      string nama { get; set; }
      string alamat { get; set; }
      string telpon { get; set; }
      string keterangan { get; set; }
   }
}