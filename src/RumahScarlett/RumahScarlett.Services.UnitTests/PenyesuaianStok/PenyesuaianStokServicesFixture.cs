using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.PenyesuaianStok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.PenyesuaianStok
{
   public class PenyesuaianStokServicesFixture : BaseServicesFixture<IPenyesuaianStokModel, IPenyesuaianStokServices>
   {
      public PenyesuaianStokServicesFixture()
      {
         Model = new PenyesuaianStokModel();
         Services = new PenyesuaianStokServices(null, new ModelDataAnnotationCheck());
      }
   }
}
