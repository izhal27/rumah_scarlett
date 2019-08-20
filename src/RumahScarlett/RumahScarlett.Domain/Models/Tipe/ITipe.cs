namespace RumahScarlett.Domain.Models.Tipe
{
   public interface ITipe
   {
      uint id { get; set; }
      string nama { get; set; }
      string keterangan { get; set; }
   }
}