﻿using RumahScarlett.Domain.Helper;
using RumahScarlett.Domain.Models.Barang;
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
   [Table("pembelian_return_detail")]
   public class PembelianReturnDetailModel : IPembelianReturnDetailModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Display(Name = "Pembelian Return ID")]
      public uint pembelian_return_id { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Barang")]
      public IBarangModel Barang { get; set; }

      private uint _barang_id;

      [Browsable(false)]
      [Display(Name = "Barang ID")]
      [Range(1, uint.MaxValue, ErrorMessage = "Barang harus diisi !!!")]
      public uint barang_id
      {
         get { return Barang.id != default(uint) ? Barang.id : _barang_id; }
         set { _barang_id = value; }
      }

      [Dp.Write(false)]
      [Display(Name = "Kode Barang")]
      public string barang_kode
      {
         get { return Barang.id != default(uint) ? Barang.kode : string.Empty; }
      }

      [Dp.Write(false)]
      [Display(Name = "Nama Barang")]
      public string barang_nama
      {
         get { return Barang.id != default(uint) ? Barang.nama : string.Empty; }
      }

      [Display(Name = "Qty")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public int qty { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Satuan")]
      public string satuan_nama
      {
         get { return Barang.id != default(uint) ? Barang.satuan_nama : string.Empty; }
      }

      private decimal _hpp;
      
      [Display(Name = "Hpp")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public decimal hpp
      {
         get { return Barang.id != default(uint) ? Barang.hpp : _hpp; }
         set { _hpp = value; }
      }
      
      [Dp.Write(false)]
      [Display(Name = "Sub Total")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public decimal sub_total
      {
         get { return qty > 0 ? (qty * hpp) : 0; }
      }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Status harus diisi !!!")]
      public int status { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Status")]
      public string status_nama
      {
         get { return DataSourceHelper.StatusReturn.Where(sr => (int)sr.Key == status).FirstOrDefault().Value; }
      }

      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }

      public PembelianReturnDetailModel()
      {
         Barang = new BarangModel();
      }
   }
}
