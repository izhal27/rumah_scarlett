using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pelanggan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Pelanggan
{
   public class PelangganServicesFixture : BaseServicesFixture<IPelangganModel, IPelangganServices>
   {
      public PelangganServicesFixture()
      {
         Model = new PelangganModel();
         Services = new PelangganServices(null, new ModelDataAnnotationCheck());
      }
   }
}
