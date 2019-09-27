using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Penjualan;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Penjualan
{
   [Trait("Category", "Data Access Validations")]
   public class PenjualanReturnServicesDataAccessTests
   {
      private IPenjualanReturnServices _services;
      private ITestOutputHelper _testOutputHelper;

      public PenjualanReturnServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _services = new PenjualanReturnServices(new PenjualanReturnRepository(), new ModelDataAnnotationCheck());
         _testOutputHelper = testOutputHelper;
      }


      [Fact]
      private void ShouldReturnSuccessForInsert()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            //operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = ex.DataAccessStatusInfo.OperationSucceeded;
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }

         try
         {
            Assert.True(operationSecceded);
            _testOutputHelper.WriteLine("Data berhasil ditambahkan.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForDelete()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new PenjualanReturnModel()
            {
               id = 12,
               penjualan_id =  13
            };

            _services.Delete(model);

            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = ex.DataAccessStatusInfo.OperationSucceeded;
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }

         try
         {
            Assert.True(operationSecceded);
            _testOutputHelper.WriteLine("Data berhasil dihapus.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      public void ShouldReturnListOfModelsDateNow()
      {
         var listModels = _services.GetByDate(DateTime.Now.Date).ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnListOfModelsBetweenDate()
      {
         var listModels = _services.GetByDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date, DateTime.Now.Date).ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }
      
      [Fact]
      public void ShouldReturnListOfReportModelsDateNow()
      {
         var listModels = _services.GetReportByDate(DateTime.Now.Date).ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnListOfReportModelsBetweenDate()
      {
         var listModels = _services.GetReportByDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date, DateTime.Now.Date).ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }
   }
}
