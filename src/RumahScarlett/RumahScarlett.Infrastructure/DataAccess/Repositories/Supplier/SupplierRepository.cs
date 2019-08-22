using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Services.CommonServices;
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
      private DbContext _context;

      public SupplierRepository()
      {
         _context = new DbContext();
         _modelName = "supplier";
      }

      public void Insert(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Insert(model, () => _context.Conn.Insert((SupplierModel)model), dataAccessStatus,
                () => CheckInsert(model));
      }

      public void Update(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Update(model, () => _context.Conn.Update((SupplierModel)model), dataAccessStatus,
                () => CheckUpdateDelete(model));
      }

      public void Delete(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () => _context.Conn.Delete((SupplierModel)model), dataAccessStatus,
                () => CheckUpdateDelete(model));
      }

      public IEnumerable<ISupplierModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            return _context.Conn.GetAll<SupplierModel>().ToList();
         }, dataAccessStatus);
      }

      public ISupplierModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetBy(() => _context.Conn.Get<SupplierModel>(id), dataAccessStatus);
      }

      private void ValidateModel(ISupplierModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM supplier WHERE nama=@nama AND id!=@id",
                                                             new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(ISupplierModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM supplier WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(ISupplierModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM supplier WHERE id=@id",
                                                  new { model.id });
      }
   }
}
