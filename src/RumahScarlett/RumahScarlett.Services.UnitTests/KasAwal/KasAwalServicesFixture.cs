using RumahScarlett.Domain.Models.KasAwal;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.KasAwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.KasAwal
{
   public class KasAwalServicesFixture : BaseServicesFixture<IKasAwalModel, IKasAwalServices>
   {
      public KasAwalServicesFixture()
      {
         Model = new KasAwalModel();
         Services = new KasAwalServices(null, new ModelDataAnnotationCheck());
      }
   }
}
