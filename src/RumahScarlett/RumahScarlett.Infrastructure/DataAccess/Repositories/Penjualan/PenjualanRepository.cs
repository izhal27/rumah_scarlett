﻿using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Services.Services.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan
{
   public class PenjualanRepository : BaseRepository<IPenjualanModel>, IPenjualanRepository
   {
      public PenjualanRepository()
      {
         _modelName = "penjualan";
      }

      public void Insert(IPenjualanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            model.no_nota = DbHelper.GetMaxID(context, context.Transaction, "penjualan", "no_nota");
            model.tanggal = DateTime.Now;

            Insert(model, () =>
            {
               var queryStr = "INSERT INTO penjualan (no_nota, status_pembayaran, pelanggan_id, tanggal, diskon, jumlah_bayar) " +
                              "VALUES (@no_nota, @status_pembayaran, @pelanggan_id, @tanggal, @diskon, @jumlah_bayar);" +
                              "SELECT LAST_INSERT_ID();";

               object pelanggan_id = DBNull.Value;

               if (model.pelanggan_id != default(uint))
               {
                  pelanggan_id = model.pelanggan_id;
               }

               var insertedId = context.Conn.Query<uint>(queryStr, new
               {
                  model.no_nota,
                  model.status_pembayaran,
                  pelanggan_id,
                  model.tanggal,
                  model.diskon,
                  model.jumlah_bayar
               }, context.Transaction).Single();

               if (insertedId > 0 && model.PenjualanDetails.ToList().Count > 0)
               {
                  model.id = insertedId;
                  model.PenjualanDetails = model.PenjualanDetails.Map(p => p.penjualan_id = model.id).ToList();
                  model.PenjualanDetails = model.PenjualanDetails.Map(pd =>
                  {
                     var barang = context.Conn.Get<BarangModel>(pd.barang_id);

                     if (barang != null)
                     {
                        barang.Satuan = context.Conn.Get<SatuanModel>(barang.satuan_id);
                        pd.Barang = barang;
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel penjualan tidak ditemukan.");
                        throw ex;
                     }
                  });

                  var barangNotPassed = model.PenjualanDetails.Any(pd => pd.Barang.harga_jual == 0);

                  if (barangNotPassed)
                  {
                     var ex = new DataAccessException(dataAccessStatus);
                     SetDataAccessValues(ex, "Salah satu barang yang ingin dimasukan ke dalam tabel penjualan " +
                                             "belum memiliki harga jual.");
                     throw ex;
                  }
                  else
                  {
                     var pdRepo = new PenjualanDetailRepository(context);

                     var laporanStatusBarangModel = new StatusBarangModel();

                     queryStr = "SELECT SUM(stok) FROM barang";
                     var stokAwal = context.Conn.ExecuteScalar<int>(queryStr);

                     laporanStatusBarangModel.stok_awal = stokAwal;
                     laporanStatusBarangModel.tanggal = model.tanggal;
                     laporanStatusBarangModel.Penjualan = model;

                     context.Conn.Insert(laporanStatusBarangModel, context.Transaction);

                     foreach (var pd in model.PenjualanDetails)
                     {
                        pd.harga_jual = pd.Barang.harga_jual;
                        pdRepo.Insert(pd, context.Transaction);

                        pd.Barang.stok -= pd.qty;

                        if (pd.Barang.minimal_stok > pd.Barang.stok)
                        {
                           var ex = new DataAccessException(dataAccessStatus);
                           SetDataAccessValues(ex, "Salah satu qty barang yang ingin dimasukan ke dalam tabel penjualan " +
                                                   "melebihi minimal stok dari barang tersebut.");
                           throw ex;
                        }

                        context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                     }

                     context.Commit();
                  }
               }
            }, dataAccessStatus,
            () => CheckAfterInsert(context, "SELECT COUNT(1) FROM penjualan WHERE no_nota=@no_nota "
                                   + "AND id=(SELECT id FROM penjualan ORDER BY ID DESC LIMIT 1)",
                                   new { model.no_nota }));
         }
      }

      public void Update(IPenjualanModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenjualanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            Delete(model, () =>
            {
               model.PenjualanDetails = new PenjualanDetailRepository(context).GetAll(model, context.Transaction);

               var success = context.Conn.Delete((PenjualanModel)model, context.Transaction);

               if (success)
               {
                  if (model.PenjualanDetails.ToList().Count > 0)
                  {
                     foreach (var pd in model.PenjualanDetails)
                     {
                        pd.Barang.stok += pd.qty;

                        context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                     }

                     context.Commit();
                  }
               }
            }, dataAccessStatus, () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPenjualanModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenjualanModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PenjualanModel>(StringHelper.QueryStringByDate(_modelName), new { date });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      public IEnumerable<IPenjualanModel> GetByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PenjualanModel>(StringHelper.QueryStringByBetweenDate(_modelName), new { startDate, endDate });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      private IEnumerable<PenjualanModel> MappingObjects(DbContext context, IEnumerable<PenjualanModel> listObj)
      {
         if (listObj != null && listObj.ToList().Count > 0)
         {
            listObj = listObj.Map(p =>
            {
               if (p.pelanggan_id != default(uint))
               {
                  p.Pelanggan = context.Conn.Get<PelangganModel>(p.pelanggan_id);
               }
            });

            var pdRepo = new PenjualanDetailRepository(context);

            foreach (var p in listObj)
            {
               p.PenjualanDetails = pdRepo.GetAll(p);
            }
         }

         return listObj;
      }

      public IPenjualanModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<PenjualanModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      public IPenjualanModel GetByNoNota(object noNota)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = "SELECT * FROM penjualan WHERE no_nota = @noNota";

            var model = context.Conn.Query<PenjualanModel>(queryStr, new { noNota }).FirstOrDefault();

            if (model != null)
            {
               if (model.pelanggan_id != default(uint))
               {
                  var pelangganModel = context.Conn.Get<PelangganModel>(model.pelanggan_id);

                  if (pelangganModel != null)
                  {
                     model.Pelanggan = pelangganModel;
                  }
               }

               var pdRepo = new PenjualanDetailRepository(context);

               model.PenjualanDetails = pdRepo.GetAll(model);
            }
            return model;
         }
      }

      public IEnumerable<IPenjualanReportModel> GetReportByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = QueryStrReport("DATE(pj.tanggal) = @date");

            var listObjs = context.Conn.Query<PenjualanReportModel>(queryStr, new { date });

            return listObjs;
         }
      }

      public IEnumerable<IPenjualanReportModel> GetReportByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = QueryStrReport("DATE(pj.tanggal) >= @startDate AND DATE(pj.tanggal) <= @endDate");

            var listObjs = context.Conn.Query<PenjualanReportModel>(queryStr, new { startDate, endDate });

            return listObjs;
         }
      }

      private string QueryStrReport(string where)
      {
         return "SELECT pj.tanggal, pj.no_nota, IFNULL(pl.nama, '') AS pelanggan_nama, pj.status_pembayaran, " +
                "b.kode AS barang_kode, b.nama AS barang_nama, pjd.qty, s.nama AS barang_satuan, " +
                "pjd.harga_jual, pj.diskon, pj.jumlah_bayar FROM penjualan pj " +
                "LEFT JOIN pelanggan pl ON pj.pelanggan_id = pl.id " +
                "INNER JOIN penjualan_detail pjd ON pj.id = pjd.penjualan_id " +
                "INNER JOIN barang b ON pjd.barang_id = b.id " +
                $"INNER JOIN satuan s ON b.satuan_id = s.id WHERE {where}";
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM penjualan WHERE id=@id",
                                new { id });
      }
   }
}
