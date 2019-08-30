using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Satuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Satuan
{
   public class SatuanServicesFixture : BaseServicesFixture<ISatuanModel, ISatuanServices>
   {
      public SatuanServicesFixture()
      {
         Model = new SatuanModel();
         Services = new SatuanServices(null, new ModelDataAnnotationCheck());
      }
   }
}
