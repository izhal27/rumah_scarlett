using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
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
   public class PenjualanServicesDataAccessTests
   {
      private IModelDataAnnotationCheck _modelDAC;
      private IPenjualanServices _services;
      private ITestOutputHelper _testOutputHelper;

      public PenjualanServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _modelDAC = new ModelDataAnnotationCheck();
         _services = new PenjualanServices(new PenjualanRepository(), _modelDAC);
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
            var listPenjualanDetails = new List<PenjualanDetailModel>
               {
                  new PenjualanDetailModel
                  {
                     barang_id = 1,
                     qty = 5
                  },
                  new PenjualanDetailModel
                  {
                     barang_id = 2,
                     qty = 5
                  },
                  new PenjualanDetailModel
                  {
                     barang_id = 3,
                     qty = 5
                  }
               };

            var penjualanModel = new PenjualanModel
            {
               pelanggan_id = default(uint),
               tanggal = DateTime.Now,
               diskon = 0,
               PenjualanDetails = listPenjualanDetails
            };

            _services.Insert(penjualanModel);

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
            //for (uint i = 1; i <= 5; i++)
            //{
            //   var model = new PenjualanModel()
            //   {
            //      id = i,
            //   };

            //   _services.Delete(model);
            //}

            var model = new PenjualanModel()
            {
               id = 1,
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
         var listModels = _services.GetByDate(DateTime.Now).ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnListOfModelsBetweenDate()
      {
         var listModels = _services.GetByDate(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(3)).ToList();

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
         var listModels = _services.GetReportByDate(DateTime.Now.AddDays(-(DateTime.Now.Day)).Date, DateTime.Now.Date).ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }
   }
}
