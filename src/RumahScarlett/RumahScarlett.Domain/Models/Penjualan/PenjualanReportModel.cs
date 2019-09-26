using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pelanggan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public class PenjualanReportModel : IPenjualanReportModel
   {
      public uint id { get; set; }

      public uint penjualan_id { get; set; }

      public DateTime tanggal { get; set; }

      public string no_nota { get; set; }

      public IPelangganModel Pelanggan { get; set; }

      public uint pelanggan_id { get; set; }

      private string _pelanggan_nama;

      public string pelanggan_nama
      {
         get { return _pelanggan_nama; }
         set { _pelanggan_nama = string.IsNullOrWhiteSpace(value) ? string.Empty : value; }
      }

      public bool status_pembayaran { get; set; }

      public string status_pembayaran_nama
      {
         get { return status_pembayaran ? "Cash" : "Transfer"; }
      }

      public IBarangModel Barang { get; set; }

      public uint barang_id { get; set; }

      public string barang_kode { get; set; }

      public string barang_nama { get; set; }

      public int qty { get; set; }

      public int qty_return { get; set; }

      public string barang_satuan { get; set; }

      public decimal harga_jual { get; set; }

      public decimal sub_total
      {
         get { return qty > 0M ? decimal.Parse((qty * harga_jual).ToString()) : 0M; }
      }

      public decimal total { get; }

      public decimal diskon { get; set; }

      public decimal grand_total { get; }

      public decimal jumlah_bayar { get; set; }

      public decimal kembali { get; set; }

      public decimal hpp { get; set; }

      public IEnumerable<IPenjualanDetailModel> PenjualanDetails { get; set; }
   }
}
