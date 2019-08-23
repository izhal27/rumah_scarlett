using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests
{
   /// <summary>
   /// Base of model services fixture
   /// </summary>
   /// <typeparam name="TDomainModel">Type of domain model</typeparam>
   /// <typeparam name="TServicesModel">Type of services model</typeparam>
   public class BaseServicesFixture<TDomainModel, TServicesModel>
   {
      public TDomainModel Model { get; set; }
      public TServicesModel Services { get; set; }
   }
}
