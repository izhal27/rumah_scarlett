using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using RumahScarlett.CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories
{
   public class BaseRepository<TDomainModel>
   {
      protected enum TypeOfExistenceCheck
      {
         DoesExistInDB,
         DoesNotExistInDB
      }

      protected enum RequestType
      {
         Insert,
         Update,
         Delete,
         ConfirmInsert,
         ConfirmDelete
      }

      protected enum ErrorMessageType
      {
         Insert,
         AfterInsert,
         ModelNotFound,
         Update,
         Delete,
         FailedDelete,
         GetList,
         GetById,
         QtyEmpty
      }

      protected enum ProcessType
      {
         Insert,
         Update,
         Delete
      }

      protected static string _modelName = "";

      protected void Insert(TDomainModel model, Action insertMethod, DataAccessStatus dataAccessStatus,
                                Func<bool> checkInsert)
      {
         try
         {
            insertMethod();
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
                              checkInsert: checkInsert());
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.AfterInsert);
            throw ex;
         }
      }

      protected void Update(TDomainModel model, Action updatetMethod, DataAccessStatus dataAccessStatus,
                                        Func<bool> checkUpdate)
      {
         try
         {
            RecordExistsCheck(model, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update,
                              checkUpdateDelete: checkUpdate());
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            updatetMethod();
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Update);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      protected void Delete(TDomainModel model, Action deleteMethod, DataAccessStatus dataAccessStatus,
                                Func<bool> checkDelete)
      {
         try
         {
            RecordExistsCheck(model, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete,
                              checkUpdateDelete: checkDelete());
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            deleteMethod();
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
                              checkUpdateDelete: checkDelete());
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.FailedDelete);
            throw ex;
         }
      }

      protected IEnumerable<TDomainModel> GetAll(Func<IEnumerable<TDomainModel>> getAllMethod, DataAccessStatus dataAccessStatus)
      {
         IEnumerable<TDomainModel> listObj = new List<TDomainModel>();

         try
         {
            listObj = getAllMethod();
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.GetList);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return listObj;
      }

      protected TDomainModel GetBy(Func<TDomainModel> getByMethod, DataAccessStatus dataAccessStatus)
      {
         TDomainModel model = default(TDomainModel);

         try
         {
            model = getByMethod();
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

      protected DataAccessStatus SetDataAccessValues(MySqlException ex, ErrorMessageType errorMessageType)
      {
         var customMessage = "";

         switch (errorMessageType)
         {
            case ErrorMessageType.Insert:
               customMessage = $"Terjadi kesalahan saat menambahkan data {_modelName}.";
               break;
            case ErrorMessageType.Update:
               customMessage = $"Terjadi kesalahan saat menyimpan data {_modelName}.";
               break;
            case ErrorMessageType.Delete:
               customMessage = $"Terjadi kesalahan saat menghapus data {_modelName}.";
               break;
            case ErrorMessageType.GetList:
               customMessage = $"Gagal mengambil data list {_modelName}.";
               break;
            case ErrorMessageType.GetById:
               customMessage = $"Gagal mengambil data {_modelName} yang sesuai dengan id yang diminta.";
               break;
            default:
               customMessage = "Terjadi keslahan saat melakukan operasi yang diminta.";
               break;
         }

         var dataAccessStatus = new DataAccessStatus();
         dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                    customMessage: customMessage,
                                    helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);

         return SetDataAccessValues(ex, customMessage);
      }

      protected DataAccessStatus SetDataAccessValues(MySqlException ex, string customMessage)
      {
         var dataAccessStatus = new DataAccessStatus();
         dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                    customMessage: customMessage,
                                    helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);

         return dataAccessStatus;
      }

      protected void SetDataAccessValues(DataAccessException ex, ErrorMessageType errorMessageType)
      {
         var customMessage = "";

         switch (errorMessageType)
         {
            case ErrorMessageType.AfterInsert:
               customMessage = $"Gagal menemukan data {_modelName} " +
                                "di database setelah sukses menambahkan data.";
               break;
            case ErrorMessageType.ModelNotFound:
               customMessage = $"{_modelName.FirstToUpper()} tidak dapat diproses, dikarenakan data {_modelName} " +
                                "yang ingin di proses tidak ditemukan.";
               break;
            case ErrorMessageType.FailedDelete:
               customMessage = $"Gagal menghapus data {_modelName}.";
               break;
            case ErrorMessageType.QtyEmpty:
               customMessage = $"Qty {_modelName} yang ingin di proses bernilai 0 (Nol).";
               break;
            default:
               customMessage = "Terjadi keslahan saat melakukan operasi yang diminta.";
               break;
         }

         SetDataAccessValues(ex, customMessage);
      }

      protected void SetDataAccessValues(DataAccessException ex, string customMessage)
      {
         ex.DataAccessStatusInfo.Status = "Error";
         ex.DataAccessStatusInfo.OperationSucceeded = false;
         ex.DataAccessStatusInfo.CustomMessage = customMessage;
         ex.DataAccessStatusInfo.ExceptionMessage = !string.IsNullOrWhiteSpace(ex.Message) ? string.Copy(ex.Message) : "";
         ex.DataAccessStatusInfo.StackTrace = !string.IsNullOrWhiteSpace(ex.StackTrace) ? string.Copy(ex.StackTrace) : "";
      }

      protected void RecordExistsCheck(TDomainModel model, TypeOfExistenceCheck typeOfExistenceCheck,
                                     RequestType requestType, bool checkInsert = false,
                                     bool checkUpdateDelete = false)
      {
         bool exists = false;

         try
         {
            if (requestType == RequestType.Insert || requestType == RequestType.ConfirmInsert)
            {
               exists = checkInsert;
            }
            else if (requestType == RequestType.Update || requestType == RequestType.ConfirmDelete ||
                     requestType == RequestType.Delete)
            {
               exists = checkUpdateDelete;
            }
         }
         catch (MySqlException ex)
         {
            throw ex;
         }

         if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesExistInDB) && !exists)
         {
            throw new DataAccessException(new DataAccessStatus());
         }
         else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && exists)
         {
            throw new DataAccessException(new DataAccessStatus());
         }
      }
   }
}
