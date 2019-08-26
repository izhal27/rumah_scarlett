using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Services.Services.PenyesuaianStok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok
{
   public class PenyesuaianStokRepository : BaseRepository<IPenyesuaianStokModel>, IPenyesuaianStokRepository
   {
      public PenyesuaianStokRepository()
      {
         _modelName = "penyesuaian stok";
      }

      public void Insert(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         model.no_nota = DbHelper.GetMaxID("penyesuaian_stok", "no_nota");

         Insert(model, () =>
         {
            using (var context = new DbContext())
            {
               context.BeginTransaction();

               var queryStr = "INSERT INTO penyesuaian_stok (no_nota, tanggal) " +
                              "VALUES (@no_nota, @tanggal);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = context.Conn.Query<uint>(queryStr, new
               {
                  model.no_nota,
                  model.tanggal
               }, context.Transaction).Single();

               if (insertedId > 0)
               {
                  model.id = insertedId;
                  model.PenyesuaianStokDetails = model.PenyesuaianStokDetails.Map(p => p.penyesuaian_stok_id = model.id).ToList();
                  model.PenyesuaianStokDetails = model.PenyesuaianStokDetails.Map(p =>
                  {
                     var barang = context.Conn.Get<BarangModel>(p.barang_id);

                     if (barang != null)
                     {
                        p.Barang = barang;
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel penyesuaian stok tidak ditemukan.");
                        throw ex;
                     }
                  });

                  var barangNotPassed = model.PenyesuaianStokDetails.Any(pd => pd.Barang.minimal_stok > (pd.Barang.stok - pd.qty));

                  if (barangNotPassed)
                  {
                     var ex = new DataAccessException(dataAccessStatus);
                     SetDataAccessValues(ex, "Salah satu barang yang ingin dimasukan ke dalam tabel penyesuaian stok " +
                                             "qty melebihi minimal stok dari barang tersebut.");
                     throw ex;
                  }
                  else
                  {
                     var psdRepo = new PenyesuaianStokDetailRepository(context);

                     foreach (var pd in model.PenyesuaianStokDetails)
                     {
                        psdRepo.Insert(pd, context.Transaction);

                        pd.Barang.stok -= pd.qty;

                        context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                     }

                     context.Transaction.Commit();
                  }
               }
            }
         }, dataAccessStatus, () => CheckInsert(model));
      }

      public void Update(IPenyesuaianStokModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () =>
         {
            using (var context = new DbContext())
            {
               context.BeginTransaction();

               model.PenyesuaianStokDetails = new PenyesuaianStokDetailRepository(context).GetAll(model);

               var success = context.Conn.Delete((PenyesuaianStokModel)model, context.Transaction);

               if (success)
               {
                  foreach (var pd in model.PenyesuaianStokDetails)
                  {
                     pd.Barang.stok += pd.qty;

                     context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                  }

                  context.Transaction.Commit();
               }
            }
         }, dataAccessStatus, () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPenyesuaianStokModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            using (var context = new DbContext())
            {
               var listPenyesuaianStoks = context.Conn.GetAll<PenyesuaianStokModel>().ToList();

               if (listPenyesuaianStoks.Count > 0)
               {
                  var psdRepo = new PenyesuaianStokDetailRepository(context);

                  foreach (var ps in listPenyesuaianStoks)
                  {
                     ps.PenyesuaianStokDetails = psdRepo.GetAll(ps).ToList();
                  }
               }

               return listPenyesuaianStoks;
            }
         }, dataAccessStatus);
      }

      public IEnumerable<IPenyesuaianStokModel> GetByDate(object date)
      {
         return GetAll().Where(ps => ps.tanggal.Date == ((DateTime)date).Date);
      }

      public IEnumerable<IPenyesuaianStokModel> GetByDate(object startDate, object endDate)
      {
         return GetAll().Where(ps => ps.tanggal.Date >= ((DateTime)startDate).Date && ps.tanggal.Date <= ((DateTime)endDate).Date);
      }

      public IPenyesuaianStokModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      private bool CheckInsert(IPenyesuaianStokModel model)
      {
         using (var context = new DbContext())
         {
            return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penyesuaian_stok WHERE no_nota=@no_nota "
                                                     + "AND id=(SELECT id FROM penyesuaian_stok ORDER BY ID DESC LIMIT 1)",
                                                     new { model.no_nota });
         }

      }

      private bool CheckUpdateDelete(IPenyesuaianStokModel model)
      {
         using (var context = new DbContext())
         {
            return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penyesuaian_stok WHERE id=@id",
                                                  new { model.id });
         }
      }
   }
}
