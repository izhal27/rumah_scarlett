using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Penjualan
{
   public class PenjualanReturnServicesFixture : BaseServicesFixture<IPenjualanReturnModel, IPenjualanReturnServices>
   {
      public PenjualanReturnServicesFixture()
      {
         Model = new PenjualanReturnModel();
         Services = new PenjualanReturnServices(null, new ModelDataAnnotationCheck());
      }
   }
}
