namespace RumahScarlett.Domain.Models.Supplier
{
   public interface ISupplierModel
   {
      uint id { get; set; }
      string nama { get; set; }
      string alamat { get; set; }
      string telpon { get; set; }
      string fax { get; set; }
      string email { get; set; }
      string website { get; set; }
      string contact_person { get; set; }
   }
}