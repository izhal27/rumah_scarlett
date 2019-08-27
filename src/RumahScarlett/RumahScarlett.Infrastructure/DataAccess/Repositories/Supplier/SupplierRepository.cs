using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Services.Services.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier
{
   public class SupplierRepository : BaseRepository<ISupplierModel>, ISupplierRepository
   {
      public SupplierRepository()
      {
         _modelName = "supplier";
      }

      public void Insert(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((SupplierModel)model), dataAccessStatus,
                   () => CheckInsert(context, model));
         }
      }

      public void Update(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((SupplierModel)model), dataAccessStatus,
                   () => CheckUpdateDelete(context, model));
         }
      }

      public void Delete(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((SupplierModel)model), dataAccessStatus,
                () => CheckUpdateDelete(context, model));
         }
      }

      public IEnumerable<ISupplierModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => { return context.Conn.GetAll<SupplierModel>().ToList(); }, dataAccessStatus);
         }
      }

      public ISupplierModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<SupplierModel>(id), dataAccessStatus);
         }
      }

      private void ValidateModel(DbContext context, ISupplierModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM supplier WHERE nama=@nama AND id!=@id",
                                                             new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(DbContext context, ISupplierModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM supplier WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(DbContext context, ISupplierModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM supplier WHERE id=@id",
                                                  new { model.id });
      }
   }
}
