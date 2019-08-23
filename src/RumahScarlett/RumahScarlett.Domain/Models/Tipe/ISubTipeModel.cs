namespace RumahScarlett.Domain.Models.Tipe
{
   public interface ISubTipeModel
   {
      uint id { get; set; }
      TipeModel Tipe { get; set; }
      uint tipe_id { get; }
      string tipe_nama { get; }
      string nama { get; set; }
      string keterangan { get; set; }
   }
}