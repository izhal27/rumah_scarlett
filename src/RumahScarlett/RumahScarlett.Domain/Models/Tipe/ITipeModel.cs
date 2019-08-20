namespace RumahScarlett.Domain.Models.Tipe
{
   public interface ITipeModel
   {
      uint id { get; set; }
      string nama { get; set; }
      string keterangan { get; set; }
   }
}