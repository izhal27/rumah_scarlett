using System;

namespace RumahScarlett.Domain.Models.HutangOperasional
{
   public interface IHutangOperasionalModel
   {
      uint id { get; set; }
      decimal jumlah { get; set; }
      string keterangan { get; set; }
      bool status_hutang { get; set; }
      string status_hutang_nama { get; }
      DateTime tanggal { get; set; }
   }
}