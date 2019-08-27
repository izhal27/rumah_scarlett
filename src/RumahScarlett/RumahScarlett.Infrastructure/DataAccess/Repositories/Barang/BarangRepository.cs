using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Services.Services.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Barang
{
   public class BarangRepository : BaseRepository<IBarangModel>, IBarangRepository
   {
      public BarangRepository()
      {
         _modelName = "barang";
      }

      public void Insert(IBarangModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((BarangModel)model), dataAccessStatus,
                  () => CheckInsert(context, model));
         }
      }

      public void Update(IBarangModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((BarangModel)model), dataAccessStatus,
                  () => CheckUpdateDelete(context, model));
         }
      }

      public void Delete(IBarangModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((BarangModel)model), dataAccessStatus,
                  () => CheckUpdateDelete(context, model));
         }
      }

      public IEnumerable<IBarangModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() =>
            {
               var listObj = context.Conn.GetAll<BarangModel>();

               if (listObj != null && listObj.ToList().Count > 0)
               {
                  listObj = listObj.Map(b =>
                  {
                     var queryStr = "SELECT * FROM penyesuaian_stok_detail where barang_id=@id";

                     var listObject = context.Conn.Query<PenyesuaianStokDetailModel>(queryStr, new { b.id });

                     if (listObject != null && listObject.ToList().Count > 0)
                     {
                        b.PenyesuaianStokDetails = listObject;
                     }
                  });
               }

               return listObj;
            }, dataAccessStatus);
         }
      }

      public IBarangModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<BarangModel>(id), dataAccessStatus);
         }
      }

      private void ValidateModel(DbContext context, IBarangModel model, DataAccessStatus dataAccessStatus)
      {
         var existsKode = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE kode=@kode AND id!=@id",
                                                            new { model.kode, model.id });

         if (existsKode)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("kode", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }

         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE nama=@nama AND id!=@id",
                                                            new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(DbContext context, IBarangModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE kode=@kode "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.kode });
      }

      private bool CheckUpdateDelete(DbContext context, IBarangModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE id=@id",
                                                  new { model.id });
      }
   }
}
