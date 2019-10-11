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
   public class FormActionServicesFixture : BaseServicesFixture<IFormActionModel, IFormActionServices>
   {
      public FormActionServicesFixture()
      {
         Model = new FormActionModel();
         Services = new FormActionServices(null, new ModelDataAnnotationCheck());
      }
   }
}
