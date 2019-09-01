using RumahScarlett.Domain.Models.HutangOperasional;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.HutangOperasional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.HutangOperasional
{
   public class HutangOperasionalServicesFixture : BaseServicesFixture<IHutangOperasionalModel, IHutangOperasionalServices>
   {
      public HutangOperasionalServicesFixture()
      {
         Model = new HutangOperasionalModel();
         Services = new HutangOperasionalServices(null, new ModelDataAnnotationCheck());
      }
   }
}
