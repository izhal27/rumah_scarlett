using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
using RumahScarlett.Services.Services.Laporan;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Laporan
{
   [Trait("Category", "Data Access Validations")]
   public class LaporanTransaksiByDateServicesDataAccessTests
   {
      private ITransaksiByDateServices _services;
      private ITestOutputHelper _testOutputHelper;

      public LaporanTransaksiByDateServicesDataAccessTests(ITestOutputHelper testOutupuHelper)
      {
         _services = new TransaksiByDateServices(new LaporanTransaksiByDateRepository());
         _testOutputHelper = testOutupuHelper;
      }

      [Fact]
      private void ShouldReturnSuccessForGet()
      {
         TransaksiByDateModel model = null;

         try
         {
            model = (TransaksiByDateModel)_services.Get(DateTime.Now.Date);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(model != null);

         if (model != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, model);
         }
      }
   }
}
