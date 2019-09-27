using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.Pembelian
{
   [Table("pembelian_return")]
   public class PembelianReturnModel : IPembelianReturnModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm")]
      [Display(Name = "Tanggal")]
      public DateTime tanggal { get; set; }

      [Display(Name = "No Nota")]
      public string no_nota { get; set; }

      [Dp.Write(false)]
      public IPembelianModel Pembelian { get; set; }

      private uint _pembelian_id;

      [Dp.Write(false)]
      [Browsable(false)]
      [Display(Name = "Pembelian ID")]
      [Range(1, uint.MaxValue, ErrorMessage = "Pembelian harus diisi !!!")]
      public uint pembelian_id
      {
         get { return Pembelian.id != default(uint) ? Pembelian.id : _pembelian_id; }
         set { _pembelian_id = value; }
      }

      public IEnumerable<IPembelianReturnDetailModel> PembelianReturnDetails { get; set; }

      public PembelianReturnModel()
      {
         Pembelian = new PembelianModel();
         PembelianReturnDetails = new List<PembelianReturnDetailModel>();
      }
   }
}
