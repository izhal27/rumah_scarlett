using RumahScarlett.Domain.Models.User;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.User
{
   public class UserServicesFixture : BaseServicesFixture<IUserModel, IUserServices>
   {
      public UserServicesFixture()
      {
         Model = new UserModel();
         Services = new UserServices(null, new ModelDataAnnotationCheck());
      }
   }
}
