using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.UnitTests.Tipe
{
   public class TipeServicesFixture
   {
      private ITipeModel _tipeModel;
      private ITipeServices _tipeServices;

      public TipeServicesFixture()
      {
         _tipeModel = new TipeModel();
         _tipeServices = new TipeServices(null, new ModelDataAnnotationCheck());
      }

      public ITipeModel TipeModel
      {
         get { return (TipeModel)_tipeModel; }
         set { _tipeModel = value; }
      }

      public ITipeServices TipeServices
      {
         get { return (TipeServices)_tipeServices; }
         set { _tipeServices = value; }
      }
   }
}
