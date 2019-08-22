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
   /// <typeparam name="M">Model</typeparam>
   /// <typeparam name="S">Services</typeparam>
   public class BaseServicesFixture<M, S>
   {
      public M Model { get; set; }
      public S Services { get; set; }
   }
}
