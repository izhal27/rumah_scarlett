using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Satuan;
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
            model.tanggal = DateTime.Now;

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
                        barang.Satuan = context.Conn.Get<SatuanModel>(barang.satuan_id);
                        pd.Barang = barang;
                        pd.Barang.supplier_id = model.supplier_id;
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel pembelian tidak ditemukan.");
                        throw ex;
                     }
                  });

                  var pdRepo = new PembelianDetailRepository(context);

                  var laporanStatusBarangModel = new StatusBarangModel();

                  queryStr = "SELECT SUM(stok) FROM barang";
                  var stokAwal = context.Conn.ExecuteScalar<int>(queryStr);

                  laporanStatusBarangModel.stok_awal = stokAwal;
                  laporanStatusBarangModel.tanggal = model.tanggal;
                  laporanStatusBarangModel.Pembelian = model;

                  context.Conn.Insert(laporanStatusBarangModel, context.Transaction);

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
            }, dataAccessStatus,
            () => CheckAfterInsert(context, "SELECT COUNT(1) FROM pembelian WHERE no_nota=@no_nota "
                                   + "AND id=(SELECT id FROM pembelian ORDER BY ID DESC LIMIT 1)",
                                   new { model.no_nota }));
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
            }, dataAccessStatus, () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPembelianModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPembelianModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PembelianModel>(StringHelper.QueryStringByDate(_modelName), new { date });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      public IEnumerable<IPembelianModel> GetByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PembelianModel>(StringHelper.QueryStringByBetweenDate(_modelName), new { startDate, endDate });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      private IEnumerable<PembelianModel> MappingObjects(DbContext context, IEnumerable<PembelianModel> listObjs)
      {
         if (listObjs != null && listObjs.ToList().Count > 0)
         {
            listObjs = listObjs.Map(p => p.Supplier = context.Conn.Get<SupplierModel>(p.supplier_id));

            var pdRepo = new PembelianDetailRepository(context);

            foreach (var p in listObjs)
            {
               p.PembelianDetails = pdRepo.GetAll(p);
            }
         }

         return listObjs;
      }

      public IPembelianModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<PembelianModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      public IEnumerable<IPembelianReportModel> GetReportByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = QueryStrReport("WHERE DATE(pb.tanggal) = @date");

            var listObjs = context.Conn.Query<PembelianReportModel>(queryStr, new { date });

            return listObjs;
         }
      }

      public IEnumerable<IPembelianReportModel> GetReportByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = QueryStrReport("WHERE DATE(pb.tanggal) >= @startDate AND DATE(pb.tanggal) <= @endDate");

            var listObjs = context.Conn.Query<PembelianReportModel>(queryStr, new { startDate, endDate });

            return listObjs;
         }
      }

      private string QueryStrReport(string where)
      {
         return "SELECT pb.tanggal, pb.no_nota, sp.nama AS supplier_nama, b.kode AS barang_kode, " +
                "b.nama AS barang_nama, pbd.qty, st.nama AS barang_satuan, pbd.hpp FROM pembelian pb " +
                "INNER JOIN supplier sp ON pb.supplier_id = sp.id " +
                "INNER JOIN pembelian_detail pbd ON pb.id = pbd.pembelian_id " +
                "INNER JOIN barang b ON pbd.barang_id = b.id " +
                $"INNER JOIN satuan st ON b.satuan_id = st.id {where}";
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM pembelian WHERE id=@id",
                                new { id });
      }
   }
}
