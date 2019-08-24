using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pengeluaran;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pengeluaran;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pengeluaran;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Pengeluaran
{
   [Trait("Category", "Data Access Validations")]
   public class PengeluaranServicesDataAccessTests
   {
      private PengeluaranServices _services;
      private ITestOutputHelper _testOutputHelper;

      public PengeluaranServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _services = new PengeluaranServices(new PengeluaranRepository(), new ModelDataAnnotationCheck());
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
            for (int i = 1; i <= 10; i++)
            {
               var model = new PengeluaranModel()
               {
                  nama = $"Nama Pengeluaran #{i}",
                  jumlah = (i * 1000),
                  keterangan = $"Keterangan Pengeluaran #{i}"
               };

               _services.Insert(model);
            }

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
            var model = new PengeluaranModel()
            {
               id = 10
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
         var listModels = (List<PengeluaranModel>)_services.GetByDate(DateTime.Now);

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnListOfModelsBetweenDate()
      {
         var listModels = (List<PengeluaranModel>)_services.GetByDate(DateTime.Now, DateTime.Now.AddDays(3));

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }
   }
}
