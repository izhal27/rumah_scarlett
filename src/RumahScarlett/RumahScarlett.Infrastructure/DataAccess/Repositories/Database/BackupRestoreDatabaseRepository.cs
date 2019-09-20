using MySql.Data.MySqlClient;
using RumahScarlett.Services.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Database
{
   public class BackupRestoreDatabaseRepository : IBackupRestoreDatabaseRepository
   {
      public void BackupDatabase(string fileLocation)
      {
         try
         {
            using (var context = new DbContext())
            {
               var mysqlBackup = new MySqlBackup();
               mysqlBackup.Command = (MySqlCommand)context.Conn.CreateCommand();
               mysqlBackup.ExportToFile(fileLocation);
            }
         }
         catch (MySqlException ex)
         {
            throw ex;
         }
      }

      public void RestoreDatabase(string fileLocation)
      {
         try
         {
            using (var context = new DbContext())
            {
               var mysqlBackup = new MySqlBackup();
               mysqlBackup.Command = (MySqlCommand)context.Conn.CreateCommand();
               mysqlBackup.ImportFromFile(fileLocation);
            }
         }
         catch (MySqlException ex)
         {
            throw ex;
         }
      }
   }
}
