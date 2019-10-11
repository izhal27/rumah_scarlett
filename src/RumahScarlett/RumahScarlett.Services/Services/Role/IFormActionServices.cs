using RumahScarlett.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Role
{
   public interface IFormActionServices : IBaseServices<IFormActionModel>
   {
      void DeleteAll();
   }
}
