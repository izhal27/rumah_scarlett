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
      private DbContext _context;
      private IPenjualanDetailRepository _pdRepo;

      public PenjualanRepository()
      {
         _context = new DbContext();
         _modelName = "penjualan";
         _pdRepo = new PenjualanDetailRepository(_context);
      }

      public void Insert(IPenjualanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         model.no_nota = DbHelper.GetMaxID("penjualan", "no_nota");

         Insert(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var queryStr = "INSERT INTO penjualan (no_nota, tanggal, diskon) " +
                              "VALUES (@no_nota, @tanggal, @diskon);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = _context.Conn.Query<uint>(queryStr, new
               {
                  model.no_nota,
                  model.tanggal,
                  model.diskon
               }, transaction).Single();

               if (insertedId > 0)
               {
                  model.id = insertedId;
                  model.PenjualanDetails = model.PenjualanDetails.Map(p => p.penjualan_id = model.id).ToList();

                  foreach (var pd in model.PenjualanDetails)
                  {
                     _pdRepo.Insert(pd, transaction);
                  }

                  foreach (var pd in model.PenjualanDetails)
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id, transaction);
                     var customMessage = string.Empty;

                     if (barang == null)
                     {
                        customMessage = "Salah satu barang yang ingin dimasukkan dalam tabel penjualan tidak ditemukan.";
                     }
                     else
                     {
                        if (barang.stok == 0)
                        {
                           customMessage = "Salah satu barang yang ingin dimasukan ke dalam tabel penjualan " +
                                           "belum mempunyai stok.";
                        }
                        else if (barang.minimal_stok == barang.stok || barang.minimal_stok > (barang.stok - pd.qty))
                        {
                           customMessage = "Salah satu barang yang ingin dimasukan ke dalam tabel penjualan " +
                                           "melebihi minimal stok.";
                        }

                        if (string.IsNullOrWhiteSpace(customMessage))
                        {
                           barang.stok -= pd.qty;

                           _context.Conn.Update(barang, transaction);
                        }
                        else
                        {
                           var ex = new DataAccessException(dataAccessStatus);
                           SetDataAccessValues(ex, customMessage);
                           throw ex;
                        }
                     }
                  }
               }

               transaction.Commit();
            }
         }, dataAccessStatus, () => CheckInsert(model));
      }

      public void Update(IPenjualanModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenjualanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var listPenjualanDetails = _context.Conn.Query<PenjualanDetailModel>(
                                          "SELECT * FROM penjualan_detail where penjualan_id=@id",
                                          new { model.id }, transaction).ToList();

               var success = _context.Conn.Delete((PenjualanModel)model, transaction);

               if (success)
               {
                  foreach (var pd in listPenjualanDetails)
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id, transaction);

                     if (barang != null)
                     {
                        barang.stok += pd.qty;

                        _context.Conn.Update(barang, transaction);
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin dicari dalam tabel penjualan tidak ditemukan.");
                        throw ex;
                     }
                  }
               }

               transaction.Commit();
            }
         }, dataAccessStatus, () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPenjualanModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            var listPembelians = _context.Conn.GetAll<PenjualanModel>().ToList();

            if (listPembelians.Count > 0)
            {
               foreach (var p in listPembelians)
               {
                  var listPenjualanDetails = _pdRepo.GetAll(p).ToList();
                  p.PenjualanDetails = listPenjualanDetails;
               }
            }

            return listPembelians;
         }, dataAccessStatus);
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

      private bool CheckInsert(IPenjualanModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penjualan WHERE no_nota=@no_nota "
                                                  + "AND id=(SELECT id FROM penjualan ORDER BY ID DESC LIMIT 1)",
                                                  new { model.no_nota });
      }

      private bool CheckUpdateDelete(IPenjualanModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penjualan WHERE id=@id",
                                                  new { model.id });
      }
   }
}
