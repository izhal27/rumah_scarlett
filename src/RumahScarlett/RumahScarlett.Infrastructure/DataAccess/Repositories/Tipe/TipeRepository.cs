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

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class TipeRepository : BaseRepositories<ITipeModel>, ITipeRepository
   {
      private DbContext _context;
      private static string _modelName = "tipe";

      public TipeRepository(string connStr)
      {
         _context = new DbContext(connStr);
      }

      public void Create(ITipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         var exists = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) from tipe where nama=@nama",
                                                        new { model.nama });

         if (exists)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = $"Nama {_modelName} sudah ada, " +
                                              $"silahkan ganti dengan nama {_modelName} yang lain.";

            throw new DataAccessException(dataAccessStatus); ;
         }

         try
         {
            _context.Conn.Insert((TipeModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: $"Terjadi kesalahan saat menambahkan data {_modelName}.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(model, CheckAdd(model), CheckUpdateDelete(model),
                              TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.Status = "Error";
            ex.DataAccessStatusInfo.OperationSucceeded = false;
            ex.DataAccessStatusInfo.CustomMessage = $"Tidak dapat menemukan data {_modelName} " +
                                                     "di database setelah sukses menambahkan data.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }
      }

      public void Update(ITipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((TipeModel)model, CheckAdd(model), CheckUpdateDelete(model),
                              TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.CustomMessage = $"Tipe tidak dapat diubah, dikarenakan data {_modelName} " +
                                                     "tidak ditemukan di database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }

         try
         {
            _context.Conn.Update((TipeModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: $"Terjadi kesalahan saat menyimpan data {_modelName}.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Delete(ITipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((TipeModel)model, CheckAdd(model), CheckUpdateDelete(model), TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.CustomMessage = $"Tipe tidak dapat dihapus, dikarenakan data {_modelName} " +
                                                     "tidak ditemukan di database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }

         try
         {
            _context.Conn.Delete((TipeModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: $"Terjadi kesalahan saat menghapus data {_modelName}.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(model, CheckAdd(model), CheckUpdateDelete(model),
                              TypeOfExistenceCheck.DoesNotExistInDB, RequestType.ConfirmDelete);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.Status = "Error";
            ex.DataAccessStatusInfo.OperationSucceeded = false;
            ex.DataAccessStatusInfo.CustomMessage = $"Gagal menghapus data {_modelName} di database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

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
         }
         catch (MySqlException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: $"Tidak dapat mengambil list {_modelName} dari database.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
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
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: $"Tidak dapat mengambil data {_modelName} yang sesuai dengan id yang diminta.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         if (model == null)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                                       customMessage: $"Data {_modelName} tidak ditemukan. " +
                                       $"Tidak dapat mengambil data {_modelName} yang sesuai dengan id yang diminta {id}. " +
                                       $"ID {id} tidak ditemukan di database.",
                                       helpLink: "", errorCode: 0, stackTrace: "");
            throw new DataAccessException(dataAccessStatus: dataAccessStatus);
         }

         return model;
      }

      private bool CheckAdd(ITipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) from tipe where nama=@nama",
                                                   new { model.nama });
      }

      private bool CheckUpdateDelete(ITipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) from tipe where id=@id",
                                                  new { model.id });
      }
   }
}
