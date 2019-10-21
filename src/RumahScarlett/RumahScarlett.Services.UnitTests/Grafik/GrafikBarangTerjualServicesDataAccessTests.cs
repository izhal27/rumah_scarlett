using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Grafik;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Grafik;
using RumahScarlett.Services.Services.Grafik;
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
   public class GrafikBarangTerjualServicesDataAccessTests
   {
      private IGrafikBarangTerjualServices _services;
      private ITestOutputHelper _testOutputHelper;

      public GrafikBarangTerjualServicesDataAccessTests(ITestOutputHelper testOutupuHelper)
      {
         _services = new GrafikBarangTerjualServices(new GrafikBarangTerjualRepository());
         _testOutputHelper = testOutupuHelper;
      }

      [Fact]
      private void ShouldReturnSuccessForGetByMonthYear()
      {
         IEnumerable<IGrafikBarangTerjualModel> model = null;

         try
         {
            model = _services.GetByMonthYear(new MonthYear(10, 2019));
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

      [Fact]
      private void ShouldReturnSuccessForGetByBetweenMonthYear()
      {
         IEnumerable<IGrafikBarangTerjualModel> model = null;

         try
         {
            model = _services.GetByMonthYear(new MonthYear(1, 2019), new MonthYear(12, 2019));
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
