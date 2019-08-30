namespace RumahScarlett.Domain.Models.Satuan
{
   public interface ISatuanModel
   {
      uint id { get; set; }
      string nama { get; set; }
      string keterangan { get; set; }
   }
}