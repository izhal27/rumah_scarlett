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
   public class BaseRepositories<T>
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
      }

      protected static string _modelName = "";

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
               customMessage = $"Gagal mengambil data list {_modelName} dari database.";
               break;
            case ErrorMessageType.GetById:
               customMessage = $"Gagal mengambil data {_modelName} yang sesuai dengan id yang diminta.";
               break;
            default:
               break;
         }

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
                                "yang ingin di proses tidak ditemukan di database.";
               break;
            case ErrorMessageType.FailedDelete:
               customMessage = $"Gagal menghapus data {_modelName} di database.";
               break;
            default:
               break;
         }

         ex.DataAccessStatusInfo.Status = "Error";
         ex.DataAccessStatusInfo.OperationSucceeded = false;
         ex.DataAccessStatusInfo.CustomMessage = customMessage;
         ex.DataAccessStatusInfo.ExceptionMessage = !string.IsNullOrWhiteSpace(ex.Message) ? string.Copy(ex.Message) : "";
         ex.DataAccessStatusInfo.StackTrace = !string.IsNullOrWhiteSpace(ex.StackTrace) ? string.Copy(ex.StackTrace) : "";
      }

      protected void RecordExistsCheck(T model, TypeOfExistenceCheck typeOfExistenceCheck,
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
