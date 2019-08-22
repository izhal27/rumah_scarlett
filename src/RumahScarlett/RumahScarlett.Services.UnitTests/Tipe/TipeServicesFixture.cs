using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Tipe
{
   public class TipeServicesFixture : BaseServicesFixture<ITipeModel, ITipeServices>
   {
      public TipeServicesFixture()
      {
         Model = new TipeModel();
         Services = new TipeServices(null, new ModelDataAnnotationCheck());
      }
   }
}
