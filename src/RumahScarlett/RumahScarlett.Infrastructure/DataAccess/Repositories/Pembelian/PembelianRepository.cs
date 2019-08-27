using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Services.Services.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian
{
   public class PembelianRepository : BaseRepository<IPembelianModel>, IPembelianRepository
   {
      public PembelianRepository()
      {
         _modelName = "pembelian";
      }

      public void Insert(IPembelianModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            model.no_nota = DbHelper.GetMaxID(context, context.Transaction, "pembelian", "no_nota");

            Insert(model, () =>
            {
               var queryStr = "INSERT INTO pembelian (supplier_id, no_nota, tanggal) " +
                              "VALUES (@supplier_id, @no_nota, @tanggal);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = context.Conn.Query<uint>(queryStr, new
               {
                  model.supplier_id,
                  model.no_nota,
                  model.tanggal
               }, context.Transaction).Single();

               if (insertedId > 0 && model.PembelianDetails.ToList().Count > 0)
               {
                  model.id = insertedId;
                  model.PembelianDetails = model.PembelianDetails.Map(p => p.pembelian_id = model.id).ToList();
                  model.PembelianDetails = model.PembelianDetails.Map(pd =>
                  {
                     var barang = context.Conn.Get<BarangModel>(pd.barang_id);

                     if (barang != null)
                     {
                        pd.Barang = barang;
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel pembelian tidak ditemukan.");
                        throw ex;
                     }
                  });

                  var pdRepo = new PembelianDetailRepository(context);

                  foreach (var pd in model.PembelianDetails)
                  {
                     pdRepo.Insert(pd, context.Transaction);
                     pd.Barang.stok += pd.qty;

                     if (pd.hpp > 0)
                     {
                        pd.Barang.hpp = pd.hpp;
                     }

                     context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                  }

                  context.Commit();
               }
            }, dataAccessStatus, () => CheckInsert(model, context));
         }
      }

      public void Update(IPembelianModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPembelianModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () =>
            {
               context.BeginTransaction();

               model.PembelianDetails = new PembelianDetailRepository(context).GetAll(model, context.Transaction).ToList();

               var success = context.Conn.Delete((PembelianModel)model, context.Transaction);

               if (success)
               {
                  if (model.PembelianDetails.ToList().Count > 0)
                  {
                     foreach (var pd in model.PembelianDetails)
                     {
                        pd.Barang.stok -= pd.qty;

                        context.Conn.Update((BarangModel)pd.Barang, context.Transaction);
                     }

                     context.Commit();
                  }
               }
            }, dataAccessStatus, () => CheckUpdateDelete(model, context));
         }
      }

      public IEnumerable<IPembelianModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() =>
            {
               var listObj = context.Conn.GetAll<PembelianModel>().ToList();

               if (listObj != null && listObj.Count > 0)
               {
                  listObj = listObj.Map(p => p.Supplier = context.Conn.Get<SupplierModel>(p.supplier_id)).ToList();

                  var pdRepo = new PembelianDetailRepository(context);

                  foreach (var p in listObj)
                  {
                     p.PembelianDetails = pdRepo.GetAll(p);
                  }
               }

               return listObj;
            }, dataAccessStatus);
         }
      }

      public IEnumerable<IPembelianModel> GetByDate(object date)
      {
         return GetAll().Where(p => p.tanggal.Date == ((DateTime)date).Date);
      }

      public IEnumerable<IPembelianModel> GetByDate(object startDate, object endDate)
      {
         return GetAll().Where(p => p.tanggal.Date >= ((DateTime)startDate).Date && p.tanggal.Date <= ((DateTime)endDate).Date);
      }

      public IPembelianModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      private bool CheckInsert(IPembelianModel model, DbContext context)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pembelian WHERE no_nota=@no_nota "
                                                  + "AND id=(SELECT id FROM pembelian ORDER BY ID DESC LIMIT 1)",
                                                  new { model.no_nota });
      }

      private bool CheckUpdateDelete(IPembelianModel model, DbContext context)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pembelian WHERE id=@id",
                                                  new { model.id });
      }
   }
}
