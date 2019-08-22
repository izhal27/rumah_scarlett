using System;

namespace RumahScarlett.Domain.Models.Pengeluaran
{
   public interface IPengeluaranModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      string nama { get; set; }
      decimal jumlah { get; set; }
      string keterangan { get; set; }
   }
}