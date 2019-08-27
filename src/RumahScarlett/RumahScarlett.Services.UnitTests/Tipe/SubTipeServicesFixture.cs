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
   public class SubTipeServicesFixture : BaseServicesFixture<ISubTipeModel, ITipeServices>
   {
      public SubTipeServicesFixture()
      {
         Model = new SubTipeModel();
         Services = new TipeServices(null, new ModelDataAnnotationCheck());
      }
   }
}