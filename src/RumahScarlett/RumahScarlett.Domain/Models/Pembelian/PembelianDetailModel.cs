using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Pembelian
{
   [Table("pembelian_detail")]
   public class PembelianDetailModel : IPembelianDetailModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Display(Name = "Pembelian ID")]
      public uint pembelian_id { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IBarangModel Barang { get; set; }

      private uint _barang_id;

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Barang ID harus diisi !!!")]
      [Display(Name = "Barang ID")]
      public uint barang_id
      {
         get { return Barang.id != default(uint) ? Barang.id : _barang_id; }
         set { _barang_id = value; }
      }

      [Dp.Write(false)]
      [Display(Name = "Kode Barang")]
      public string barang_kode { get { return Barang != null ? Barang.kode : string.Empty; } }

      [Dp.Write(false)]
      [Display(Name = "Nama Barang")]
      public string barang_nama { get { return Barang != null ? Barang.nama : string.Empty; } }

      [Range(1, int.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [Display(Name = "Qty")]
      public int qty { get; set; }
      
      [Display(Name = "HPP")]
      public decimal hpp { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Total")]
      public decimal total
      {
         get
         {
            return qty > 0M ? decimal.Parse((qty * hpp).ToString()) : 0M;
         }
      }

      public PembelianDetailModel()
      {
         Barang = new BarangModel();
      }
   }
}
