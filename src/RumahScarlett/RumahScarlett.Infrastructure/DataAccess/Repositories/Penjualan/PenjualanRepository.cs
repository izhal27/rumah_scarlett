using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Domain.Models.Penjualan;
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
               var queryStr = "INSERT INTO penjualan (no_nota, status_pembayaran, pelanggan_id, tanggal, diskon) " +
                              "VALUES (@no_nota, @status_pembayaran, @pelanggan_id, @tanggal, @diskon);" +
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
                  model.diskon
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

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM penjualan WHERE id=@id",
                                new { id });
      }
   }
}
