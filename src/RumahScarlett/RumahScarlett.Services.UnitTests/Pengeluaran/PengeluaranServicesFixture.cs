using RumahScarlett.Domain.Models.Pengeluaran;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pengeluaran;
using RumahScarlett.Services.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Pengeluaran
{
   public class PengeluaranServicesFixture : BaseServicesFixture<IPengeluaranModel, IPengeluaranServices>
   {
      public PengeluaranServicesFixture()
      {
         Model = new PengeluaranModel();
         Services = new PengeluaranServices(null, new ModelDataAnnotationCheck());
      }
   }
}
