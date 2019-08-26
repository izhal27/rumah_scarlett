using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.PenyesuaianStok;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.PenyesuaianStok
{
   [Trait("Category", "Data Access Validations")]
   public class PenyesuaianStokServicesDataAccessTests
   {
      private ModelDataAnnotationCheck _modelDAC;
      private PenyesuaianStokServices _services;
      private ITestOutputHelper _testOutputHelper;

      public PenyesuaianStokServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _modelDAC = new ModelDataAnnotationCheck();
         _services = new PenyesuaianStokServices(new PenyesuaianStokRepository(), _modelDAC);
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
            var listPenyesuaianStokDetails = new List<PenyesuaianStokDetailModel>
            {
               new PenyesuaianStokDetailModel
               {
                  barang_id = 1,
                  qty = 1,
                  keterangan = "Tester"
               },
               new PenyesuaianStokDetailModel
               {
                  barang_id = 2,
                  qty = 2,
                  keterangan = "Tester"
               },
               new PenyesuaianStokDetailModel
               {
                  barang_id = 3,
                  qty = 3,
                  keterangan = "Tester"
               }
            };

            var penyesuaianStokModel = new PenyesuaianStokModel
            {
               tanggal = DateTime.Now,
               PenyesuaianStokDetails = listPenyesuaianStokDetails
            };

            _services.Insert(penyesuaianStokModel);
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
            var model = new PenyesuaianStokModel()
            {
               id = 23,
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
