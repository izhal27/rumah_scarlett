using RumahScarlett.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.User
{
   public interface IUserModel
   {
      uint id { get; set; }
      string login_id { get; set; }
      string password { get; set; }
      string role_kode { get; set; }
      string nama_kode { get; }
      IRoleModel Role { get; set; }
   }
}
