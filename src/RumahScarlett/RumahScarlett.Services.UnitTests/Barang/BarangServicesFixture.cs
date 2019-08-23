using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Barang
{
   public class BarangServicesFixture: BaseServicesFixture<IBarangModel, IBarangServices>
   {
      public BarangServicesFixture()
      {
         Model = new BarangModel();
         Services = new BarangServices(null, new ModelDataAnnotationCheck());
      }
   }
}
