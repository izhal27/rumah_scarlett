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
         Add,
         Update,
         Delete,
         ConfirmAdd,
         ConfirmDelete
      }

      protected bool RecordExistsCheck(T model,
                                     bool checkAdd, bool checkUpdateDelete,
                                     TypeOfExistenceCheck typeOfExistenceCheck,
                                     RequestType requestType)
      {
         bool exists = false;
         bool recordExistsCheckPassed = true;
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            if (requestType == RequestType.Add || requestType == RequestType.ConfirmAdd)
            {
               exists = checkAdd;
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
            dataAccessStatus.Status = "Error";
            recordExistsCheckPassed = false;

            throw new DataAccessException(dataAccessStatus);
         }
         else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && exists)
         {
            dataAccessStatus.Status = "Error";
            recordExistsCheckPassed = false;

            throw new DataAccessException(dataAccessStatus);
         }

         return recordExistsCheckPassed;
      }
   }
}
