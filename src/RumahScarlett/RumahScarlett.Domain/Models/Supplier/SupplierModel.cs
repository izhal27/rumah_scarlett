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
   public class SupplierModel : ISupplierModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama supplier harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama supplier harus diantara 3 sampai 100 karakter !!!")]
      [Display(Name = "Nama")]
      public string nama { get; set; }

      [DefaultValue("")]
      [StringLength(200, ErrorMessage = "Panjang maksimal Alamat 200 karakter !!!")]
      [Display(Name = "Alamat")]
      public string alamat { get; set; }

      [DefaultValue("")]
      [StringLength(30, ErrorMessage = "Panjang maksimal Telpon 30 karakter !!!")]
      [Display(Name = "Telpon")]
      public string telpon { get; set; }

      [DefaultValue("")]
      [StringLength(30, ErrorMessage = "Panjang maksimal Fax 30 karakter !!!")]
      [Display(Name = "Fax")]
      public string fax { get; set; }

      [DefaultValue("")]
      [EmailAddress(ErrorMessage = "Format email tidak valid")]
      [StringLength(150, ErrorMessage = "Panjang maksimal Email 150 karakter !!!")]
      [Display(Name = "Email")]
      public string email { get; set; }

      [DefaultValue("")]
      [Url(ErrorMessage = "Format URL Website tidak valid")]
      [StringLength(100, ErrorMessage = "Panjang maksimal Website 100 karakter !!!")]
      [Display(Name = "Website")]
      public string website { get; set; }

      [DefaultValue("")]
      [StringLength(100, ErrorMessage = "Panjang maksimal Contact Person 100 karakter !!!")]
      [Display(Name = "Contact Person")]
      public string contact_person { get; set; }
   }
}
