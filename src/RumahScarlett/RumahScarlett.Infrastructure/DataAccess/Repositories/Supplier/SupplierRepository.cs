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

         try
         {
            _context.Conn.Insert((SupplierModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Insert);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(model, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmInsert,
                              checkInsert: CheckInsert(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.AfterInsert);
            throw ex;
         }
      }
      
      public void Update(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         try
         {
            RecordExistsCheck((SupplierModel)model,
                              TypeOfExistenceCheck.DoesExistInDB, RequestType.Update,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            _context.Conn.Update((SupplierModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Update);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Delete(ISupplierModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((SupplierModel)model, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            _context.Conn.Delete((SupplierModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Delete);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(model, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.ConfirmDelete,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.FailedDelete);
            throw ex;
         }
      }

      public IEnumerable<ISupplierModel> GetAll()
      {
         var listObj = new List<SupplierModel>();
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            listObj = _context.Conn.GetAll<SupplierModel>().ToList();            
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.GetList);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return listObj;
      }

      public ISupplierModel GetById(object id)
      {
         SupplierModel model = null;
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            model = _context.Conn.Get<SupplierModel>(id);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.GetById);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         if (model == null)
         {
            var ex = new DataAccessException(dataAccessStatus);
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         return model;
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
