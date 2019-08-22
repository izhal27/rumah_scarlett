using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Supplier
{
   public class SupplierServiceFixture : BaseServicesFixture<ISupplierModel, ISupplierServices>
   {
      public SupplierServiceFixture()
      {
         Model = new SupplierModel();
         Services = new SupplierServices(null, new ModelDataAnnotationCheck());
      }
   }
}
