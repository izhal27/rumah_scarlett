using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Database
{
   public interface IBackupRestoreDatabaseRepository
   {
      void BackupDatabase(string fileLocation);
      void RestoreDatabase(string fileLocation);
   }
}
