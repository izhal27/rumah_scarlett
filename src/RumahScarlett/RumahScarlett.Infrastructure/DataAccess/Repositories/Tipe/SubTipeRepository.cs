using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.CommonComponents;
using Dapper;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class SubTipeRepository : BaseRepositories<ISubTipeModel>, ISubTipeRepository
   {
      private DbContext _context;
      protected new static string _modelName = "sub tipe";

      public SubTipeRepository()
      {
         _context = new DbContext();
      }

      public void Insert(ISubTipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         try
         {
            _context.Conn.Insert((SubTipeModel)model);
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

      public void Update(ISubTipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         try
         {
            RecordExistsCheck((SubTipeModel)model,
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
            _context.Conn.Update((SubTipeModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Update);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Delete(ISubTipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((SubTipeModel)model, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            _context.Conn.Delete((SubTipeModel)model);
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

      public IEnumerable<ISubTipeModel> GetAll()
      {
         var listObj = new List<SubTipeModel>();
         var dataAccessStatus = new DataAccessStatus();
         var queryStr = "SELECT s.*, t.id AS tipe_id, t.nama AS tipe_nama FROM sub_tipe s " +
                        "INNER JOIN tipe t ON s.tipe_id = t.id";

         try
         {
            listObj = _context.Conn.Query<SubTipeModel>(queryStr).ToList();
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.GetList);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return listObj;
      }

      public ISubTipeModel GetById(object id)
      {
         SubTipeModel model = null;
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            model = _context.Conn.Get<SubTipeModel>(id);
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


      private void ValidateModel(ISubTipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama AND id!=@id",
                                                            new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus);
         }
      }

      private bool CheckInsert(ISubTipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(ISubTipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE id=@id",
                                                  new { model.id });
      }
   }
}
