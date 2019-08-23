using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Pembelian
{
   public class PembelianServicesFixture : BaseServicesFixture<IPembelianModel, IPembelianServices>
   {
      public PembelianServicesFixture()
      {
         Model = new PembelianModel();
         Services = new PembelianServices(null, new ModelDataAnnotationCheck());
      }
   }
}
