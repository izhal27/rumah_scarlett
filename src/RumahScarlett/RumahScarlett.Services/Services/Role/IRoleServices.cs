using RumahScarlett.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Role
{
   public interface IRoleServices : IBaseServices<IRoleModel>
   {
      void Update(IRoleDetailModel model);
   }
}
