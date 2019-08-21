using RumahScarlett.Services.Services.Tipe;
using RumahScarlett.Domain.Models.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using Dapper;
using MySql.Data.MySqlClient;
using RumahScarlett.Services.CommonServices;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class TipeRepository : BaseRepositories<ITipeModel>, ITipeRepository
   {
      private DbContext _context;

      public TipeRepository()
      {
         _context = new DbContext();
         _modelName = "tipe";
      }

      public void Insert(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         try
         {
            _context.Conn.Insert((TipeModel)model);
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

      public void Update(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         try
         {
            RecordExistsCheck((TipeModel)model,
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
            _context.Conn.Update((TipeModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Update);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Delete(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((TipeModel)model, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            _context.Conn.Delete((TipeModel)model);
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

      public IEnumerable<ITipeModel> GetAll()
      {
         var listObj = new List<TipeModel>();
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            listObj = _context.Conn.GetAll<TipeModel>().ToList();

            //if (listObj != null)
            //{
            //   listObj = listObj.Map(
            //      t => t.SubTipeModels = null
            //      ).ToList();
            //}
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.GetList);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return listObj;
      }

      public ITipeModel GetById(object id)
      {
         TipeModel model = null;
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            model = _context.Conn.Get<TipeModel>(id);
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

      private void ValidateModel(ITipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE nama=@nama AND id!=@id",
                                                                 new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(ITipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(ITipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE id=@id",
                                                  new { model.id });
      }
   }
}
