namespace RumahScarlett.Domain.Models.SubTipe
{
   public interface ISubTipe
   {
      int id { get; set; }
      int tipe_id { get; set; }
      string tipe_nama { get; set; }
      string nama { get; set; }
      string keterangan { get; set; }
   }
}