namespace RumahScarlett.Domain.Models.Role
{
   public interface IRoleModel
   {
      uint id { get; set; }
      string kode { get; set; }
      string nama { get; set; }
      string keterangan { get; set; }
   }
}
