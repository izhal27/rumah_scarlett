using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.GantiPassword
{
   public class GantiPasswordModel : IGantiPasswordModel
   {
      public string login_id
      {
         get; set;
      }

      public string password_baru
      {
         get; set;
      }

      public string password_sekarang
      {
         get; set;
      }

      public string konf_password_baru
      {
         get; set;
      }
   }
}
