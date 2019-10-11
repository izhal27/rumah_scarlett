using RumahScarlett.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.User
{
   public interface IUserRepository : IBaseRepository<IUserModel>
   {
   }
}
