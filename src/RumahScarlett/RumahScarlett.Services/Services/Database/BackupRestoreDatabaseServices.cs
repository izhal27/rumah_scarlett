using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Database
{
   public class BackupRestoreDatabaseServices : IBackupRestoreDatabaseServices
   {
      private IBackupRestoreDatabaseRepository _repo;

      public BackupRestoreDatabaseServices(IBackupRestoreDatabaseRepository repo)
      {
         _repo = repo;
      }

      public void BackupDatabase(string fileLocation)
      {
         _repo.BackupDatabase(fileLocation);
      }

      public void RestoreDatabase(string fileLocation)
      {
         _repo.RestoreDatabase(fileLocation);
      }
   }
}
