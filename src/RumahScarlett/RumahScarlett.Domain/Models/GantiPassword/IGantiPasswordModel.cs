using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.GantiPassword
{
   public interface IGantiPasswordModel
   {
      string login_id { get; set; }
      string password_sekarang { get; set; }
      string password_baru { get; set; }
      string konf_password_baru { get; set; }
   }
}
