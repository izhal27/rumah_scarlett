using System;

namespace RumahScarlett.Domain.Models.HutangOperasional
{
   public interface IHutangOperasionalModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      string keterangan { get; set; }
      bool status_hutang { get; set; }
      string status_hutang_nama { get; }
      decimal jumlah { get; set; }
   }
}