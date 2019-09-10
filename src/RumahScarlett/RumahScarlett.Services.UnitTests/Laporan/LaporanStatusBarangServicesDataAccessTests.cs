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
   public class LaporanStatusBarangServicesDataAccessTests
   {
      private ILaporanStatusBarangServices _services;
      private ITestOutputHelper _testOutputHelper;

      public LaporanStatusBarangServicesDataAccessTests(ITestOutputHelper testOutupuHelper)
      {
         _services = new LaporanStatusBarangServices(new LaporanStatusBarangRepository());
         _testOutputHelper = testOutupuHelper;
      }

      [Fact]
      private void ShouldReturnSuccessForGetByDate()
      {
         List<ILaporanStatusBarangModel> listModels = null;
         try
         {
            listModels = _services.GetByDate(DateTime.Now.Date).ToList();
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(listModels != null);

         if (listModels != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, listModels);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForGetByBetweenDate()
      {
         List<ILaporanStatusBarangModel> listModels = null;

         try
         {
            listModels = _services.GetByDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date, DateTime.Now.Date).ToList();
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(listModels != null);
         
         if (listModels != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, listModels);
         }
      }
   }
}
