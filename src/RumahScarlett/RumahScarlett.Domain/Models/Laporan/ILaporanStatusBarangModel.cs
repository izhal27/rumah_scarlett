﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Laporan
{
   public interface ILaporanStatusBarangModel
   {
      DateTime tanggal { get; set; }
      string barang_kode { get; set; }
      string barang_nama { get; set; }
      int stok_masuk { get; set; }
      int stok_keluar { get; set; }
   }
}