using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Supplier
{
   [Table("supplier")]
   public class Supplier : ISupplier
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama supplier harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama supplier harus diantara 3 sampai 100 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }
      
      [DefaultValue("")]
      [DisplayName("Alamat")]
      [StringLength(200, ErrorMessage = "Panjang maksimal Alamat 200 karakter !!!")]
      public string alamat { get; set; }

      [DefaultValue("")]
      [DisplayName("Telpon")]
      [StringLength(30, ErrorMessage = "Panjang maksimal Telpon 30 karakter !!!")]
      public string telpon { get; set; }

      [DefaultValue("")]
      [DisplayName("Fax")]
      [StringLength(30, ErrorMessage = "Panjang maksimal Fax 30 karakter !!!")]
      public string fax { get; set; }
      
      [DisplayName("Email")]
      [StringLength(150, ErrorMessage = "Panjang maksimal Email 150 karakter !!!")]
      public string email { get; set; }

      [DefaultValue("")]
      [DisplayName("Website")]
      [StringLength(100, ErrorMessage = "Panjang maksimal Website 100 karakter !!!")]
      public string website { get; set; }
      
      [DefaultValue("")]
      [DisplayName("Contact Person")]
      [StringLength(100, ErrorMessage = "Panjang maksimal Contact Person 100 karakter !!!")]
      public string contact_person { get; set; }
   }
}
