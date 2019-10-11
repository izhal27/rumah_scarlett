using RumahScarlett.Domain.Models.Role;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Role
{
   public class RoleServicesFixture : BaseServicesFixture<IRoleModel, IRoleServices>
   {
      public RoleServicesFixture()
      {
         Model = new RoleModel();
         Services = new RoleServices(null, new ModelDataAnnotationCheck());
      }
   }
}
