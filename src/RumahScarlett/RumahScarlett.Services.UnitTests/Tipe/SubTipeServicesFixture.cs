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
   public class SubTipeServicesFixture
   {
      private ISubTipeModel _subTipeModel;
      private ISubTipeServices _tipeServices;

      public SubTipeServicesFixture()
      {
         _subTipeModel = new SubTipeModel();
         _tipeServices = new SubTipeServices(null, new ModelDataAnnotationCheck());
      }

      public ISubTipeModel SubTipeModel
      {
         get { return (SubTipeModel)_subTipeModel; }
         set { _subTipeModel = value; }
      }

      public ISubTipeServices SubTipeServices
      {
         get { return (SubTipeServices)_tipeServices; }
         set { _tipeServices = value; }
      }
   }
}
