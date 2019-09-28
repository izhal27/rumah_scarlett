using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Services.Services.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian
{
   public class PembelianReturnRepository : BaseRepository<IPembelianReturnModel>, IPembelianReturnRepository
   {
      public PembelianReturnRepository()
      {
         _modelName = "return pembelian";
      }

      public void Insert(IPembelianReturnModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            model.no_nota = DbHelper.GetMaxID(context, context.Transaction, "pembelian_return", "no_nota");
            model.tanggal = DateTime.Now;

            Insert(model, () =>
            {
               var queryStr = "INSERT INTO pembelian_return (tanggal, no_nota, pembelian_id) " +
                              "VALUES (@tanggal, @no_nota, @pembelian_id);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = context.Conn.Query<uint>(queryStr, new
               {
                  model.tanggal,
                  model.no_nota,
                  model.pembelian_id
               }, context.Transaction).Single();

               if (insertedId > 0 && model.PembelianReturnDetails.ToList().Count > 0)
               {
                  model.id = insertedId;
                  model.PembelianReturnDetails = model.PembelianReturnDetails.Map(p => p.pembelian_return_id = model.id).ToList();
                  model.PembelianReturnDetails = model.PembelianReturnDetails.Map(pd =>
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
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel pembelian return tidak ditemukan.");
                        throw ex;
                     }
                  });

                  var prdRepo = new PembelianReturnDetailRepository(context);

                  var laporanStatusBarangModel = new StatusBarangModel();

                  queryStr = "SELECT SUM(stok) FROM barang";
                  var stokAwal = context.Conn.ExecuteScalar<int>(queryStr);

                  laporanStatusBarangModel.stok_awal = stokAwal;
                  laporanStatusBarangModel.tanggal = model.tanggal;
                  laporanStatusBarangModel.PembelianReturn = model;

                  context.Conn.Insert(laporanStatusBarangModel, context.Transaction);

                  queryStr = "SELECT * FROM pembelian_detail WHERE pembelian_id = @pembelian_id";
                  var listPembelianDetails = context.Conn.Query<PembelianDetailModel>(queryStr, new { model.pembelian_id }).ToList();

                  foreach (var pd in listPembelianDetails)
                  {
                     foreach (var prd in model.PembelianReturnDetails)
                     {
                        if (pd.barang_id == prd.barang_id)
                        {
                           pd.qty_return += prd.qty;
                        }
                     }

                     context.Conn.Update(pd, context.Transaction);
                  }

                  if (listPembelianDetails.Any(pd => pd.qty_return > pd.qty))
                  {
                     var ex = new DataAccessException(dataAccessStatus);
                     SetDataAccessValues(ex, "Salah satu qty return pembelian yang ingin disimpan melebihi qty yang terjual.");
                     throw ex;
                  }

                  foreach (var prd in model.PembelianReturnDetails)
                  {
                     prdRepo.Insert(prd, context.Transaction);

                     prd.Barang.stok += prd.qty;

                     context.Conn.Update((BarangModel)prd.Barang, context.Transaction);
                  }

                  context.Commit();
               }
            }, dataAccessStatus,
            () => CheckAfterInsert(context, "SELECT COUNT(1) FROM pembelian_return WHERE no_nota = @no_nota "
                                   + "AND id = (SELECT id FROM pembelian_return ORDER BY ID DESC LIMIT 1)",
                                   new { model.no_nota }));
         }
      }

      public void Update(IPembelianReturnModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPembelianReturnModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            Delete(model, () =>
            {
               model.PembelianReturnDetails = new PembelianReturnDetailRepository(context).GetAll(model, context.Transaction);

               var queryStr = "SELECT * FROM pembelian_detail WHERE pembelian_id = @pembelian_id";
               var listPembelianDetails = context.Conn.Query<PembelianDetailModel>(queryStr, new { model.pembelian_id }).ToList();

               var success = context.Conn.Delete((PembelianReturnModel)model, context.Transaction);

               if (success)
               {
                  if (model.PembelianReturnDetails.ToList().Count > 0)
                  {
                     foreach (var pd in listPembelianDetails)
                     {
                        foreach (var prd in model.PembelianReturnDetails)
                        {
                           if (pd.barang_id == prd.barang_id)
                           {
                              pd.qty_return -= prd.qty;
                           }
                           
                           context.Conn.Update(pd, context.Transaction);
                        }
                     }

                     foreach (var prd in model.PembelianReturnDetails)
                     {
                        var barangModel = context.Conn.Get<BarangModel>(prd.barang_id);

                        barangModel.stok -= prd.qty;

                        context.Conn.Update(barangModel, context.Transaction);
                     }

                     context.Commit();
                  }
               }
            }, dataAccessStatus, () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPembelianReturnModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IPembelianReturnModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<PembelianReturnModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      public IEnumerable<IPembelianReturnModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PembelianReturnModel>(StringHelper.QueryStringByDate("pembelian_return"), new { date });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      public IEnumerable<IPembelianReturnModel> GetByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PembelianReturnModel>(StringHelper.QueryStringByBetweenDate("pembelian_return"), new { startDate, endDate });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      private IEnumerable<PembelianReturnModel> MappingObjects(DbContext context, IEnumerable<PembelianReturnModel> listObj)
      {
         if (listObj != null && listObj.ToList().Count > 0)
         {
            var pdRepo = new PembelianReturnDetailRepository(context);

            foreach (var p in listObj)
            {
               p.PembelianReturnDetails = pdRepo.GetAll(p);
            }
         }

         return listObj;
      }
      
      public IEnumerable<IPembelianReturnReportModel> GetReportByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = QueryStrReport("DATE(pbr.tanggal) = @date");

            var listObjs = context.Conn.Query<PembelianReturnReportModel>(queryStr, new { date });

            return listObjs;
         }
      }

      public IEnumerable<IPembelianReturnReportModel> GetReportByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = QueryStrReport("DATE(pbr.tanggal) >= @startDate AND DATE(pbr.tanggal) <= @endDate");

            var listObjs = context.Conn.Query<PembelianReturnReportModel>(queryStr, new { startDate, endDate });

            return listObjs;
         }
      }

      private string QueryStrReport(string where)
      {
         return "SELECT pbr.tanggal, pbr.no_nota, b.kode AS barang_kode, b.nama AS barang_nama, pbrd.qty, " +
                "s.nama AS satuan_nama, pbrd.hpp, pbrd.status, pbrd.keterangan FROM pembelian_return pbr " +
                "INNER JOIN pembelian_return_detail pbrd ON pbr.id = pbrd.pembelian_return_id " +
                "INNER JOIN barang b ON pbrd.barang_id = b.id " +
                $"INNER JOIN satuan s ON b.satuan_id = s.id WHERE { where}";
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM pembelian_return WHERE id=@id",
                                new { id });
      }
   }
}
