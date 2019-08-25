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
            var barang1 = new BarangServices(new BarangRepository(), _modelDAC).GetById(1);
            var barang2 = new BarangServices(new BarangRepository(), _modelDAC).GetById(2);
            var barang3 = new BarangServices(new BarangRepository(), _modelDAC).GetById(3);

            var listPenjualanDetail = new List<PenjualanDetailModel>
            {
               new PenjualanDetailModel
               {
                  Barang = barang1,
                  qty = 2
               },
               new PenjualanDetailModel
               {
                  Barang = barang2,
                  qty = 6
               },
               new PenjualanDetailModel
               {
                  Barang = barang3,
                  qty = 10
               }
            };

            var penjualanModel = new PenjualanModel
            {
               tanggal = DateTime.Now,
               diskon = 5000,
               PenjualanDetails = listPenjualanDetail
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
            var model = new PenjualanModel()
            {
               id = 21,
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
   }
}
