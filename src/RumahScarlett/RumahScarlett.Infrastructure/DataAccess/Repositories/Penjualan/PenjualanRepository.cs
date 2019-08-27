using RumahScarlett.Services.Services.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.CommonComponents;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using Dapper;
using RumahScarlett.Domain.Models.Barang;
using Dapper.Contrib.Extensions;

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

            Insert(model, () =>
            {
               var queryStr = "INSERT INTO penjualan (no_nota, tanggal, diskon) " +
                              "VALUES (@no_nota, @tanggal, @diskon);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = context.Conn.Query<uint>(queryStr, new
               {
                  model.no_nota,
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

                  var barangNotPassed = model.PenjualanDetails.Any(pd => pd.Barang.minimal_stok > (pd.Barang.stok - pd.qty) || pd.Barang.harga_jual == 0);

                  if (barangNotPassed)
                  {
                     var ex = new DataAccessException(dataAccessStatus);
                     SetDataAccessValues(ex, "Salah satu barang yang ingin dimasukan ke dalam tabel penjualan " +
                                             "belum memiliki harga jual atau qty melebihi minimal stok dari barang tersebut.");
                     throw ex;
                  }
                  else
                  {
                     var pdRepo = new PenjualanDetailRepository(context);

                     foreach (var pd in model.PenjualanDetails)
                     {
                        pd.harga_jual = pd.Barang.harga_jual;
                        pdRepo.Insert(pd, context.Transaction);

                        pd.Barang.stok -= pd.qty;

                        context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                     }

                     context.Transaction.Commit();
                  }
               }
            }, dataAccessStatus, () => CheckInsert(model, context));
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

                     context.Transaction.Commit();
                  }
               }
            }, dataAccessStatus, () => CheckUpdateDelete(model, context));
         }
      }

      public IEnumerable<IPenjualanModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() =>
            {
               var listPembelians = context.Conn.GetAll<PenjualanModel>().ToList();

               if (listPembelians.Count > 0)
               {
                  var pdRepo = new PenjualanDetailRepository(context);

                  foreach (var p in listPembelians)
                  {
                     p.PenjualanDetails = pdRepo.GetAll(p);
                  }
               }

               return listPembelians;
            }, dataAccessStatus);
         }
      }

      public IEnumerable<IPenjualanModel> GetByDate(object date)
      {
         return GetAll().Where(p => p.tanggal.Date == ((DateTime)date).Date);
      }

      public IEnumerable<IPenjualanModel> GetByDate(object startDate, object endDate)
      {
         return GetAll().Where(p => p.tanggal.Date >= ((DateTime)startDate).Date && p.tanggal.Date <= ((DateTime)endDate).Date);
      }

      public IPenjualanModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      private bool CheckInsert(IPenjualanModel model, DbContext context)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penjualan WHERE no_nota=@no_nota "
                                                  + "AND id=(SELECT id FROM penjualan ORDER BY ID DESC LIMIT 1)",
                                                  new { model.no_nota });
      }

      private bool CheckUpdateDelete(IPenjualanModel model, DbContext context)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penjualan WHERE id=@id",
                                                  new { model.id });
      }
   }
}
