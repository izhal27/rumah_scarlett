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
   public class PenjualanServicesFixture : BaseServicesFixture<IPenjualanModel, IPenjualanServices>
   {
      public PenjualanServicesFixture()
      {
         Model = new PenjualanModel();
         Services = new PenjualanServices(null, new ModelDataAnnotationCheck());
      }
   }
}
