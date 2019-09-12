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
   public class LabaRugiServicesDataAccessTests
   {
      private ILabaRugiServices _services;
      private ITestOutputHelper _testOutputHelper;

      public LabaRugiServicesDataAccessTests(ITestOutputHelper testOutupuHelper)
      {
         _services = new LabaRugiServices(new LabaRugiRepository());
         _testOutputHelper = testOutupuHelper;
      }

      [Fact]
      private void ShouldReturnSuccessForGetByDate()
      {
         ILabaRugiModel model = null;

         try
         {
            model = _services.GetByMonthYear(DateTime.Now.Date.Month, DateTime.Now.Year);
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
