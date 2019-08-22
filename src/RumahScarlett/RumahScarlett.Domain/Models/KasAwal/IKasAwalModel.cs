using System;

namespace RumahScarlett.Domain.Models.KasAwal
{
   public interface IKasAwalModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      decimal total { get; set; }
   }
}