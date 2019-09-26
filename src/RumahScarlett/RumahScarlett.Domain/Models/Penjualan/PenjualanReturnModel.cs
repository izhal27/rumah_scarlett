using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.Penjualan
{
   [Table("penjualan_return")]
   public class PenjualanReturnModel : IPenjualanReturnModel
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
      public IPenjualanModel Penjualan { get; set; }

      private uint _penjualan_id;

      [Dp.Write(false)]
      [Browsable(false)]
      [Display(Name = "Penjualan ID")]
      [Range(1, uint.MaxValue, ErrorMessage = "Penjualan harus diisi !!!")]
      public uint penjualan_id
      {
         get { return Penjualan.id != default(uint) ? Penjualan.id : _penjualan_id; }
         set { _penjualan_id = value; }
      }

      public IEnumerable<IPenjualanReturnDetailModel> PenjualanReturnDetails { get; set; }

      public PenjualanReturnModel()
      {
         Penjualan = new PenjualanModel();
         PenjualanReturnDetails = new List<PenjualanReturnDetailModel>();
      }
   }
}
