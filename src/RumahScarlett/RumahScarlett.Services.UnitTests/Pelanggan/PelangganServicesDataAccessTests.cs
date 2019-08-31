using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pelanggan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pelanggan;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Pelanggan
{
   [Trait("Category", "Data Access Validations")]
   public class PelangganServicesDataAccessTests
   {
      private IPelangganServices _services;
      private ITestOutputHelper _testOutputHelper;

      public PelangganServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _services = new PelangganServices(new PelangganRepository(), new ModelDataAnnotationCheck());
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
               var model = new PelangganModel()
               {
                  nama = $"Pelanggan #{i}",
                  alamat = $"Alamat Pelanggan #{i}",
                  telpon = "+62 8123456789",
                  keterangan = $"Keterangan Pelanggan #{i}"
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
      private void ShouldReturnErrorDuplicateInsert()
      {
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new PelangganModel()
            {
               nama = "Pelanggan #2",
            };

            _services.Insert(model);
         }
         catch (DataAccessException ex)
         {
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForUpdate()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new PelangganModel()
            {
               id = 1,
               nama = $"Pelanggan #1 (Update)",
               alamat = $"Alamat Pelanggan #1",
               telpon = "+62 8123456789",
               keterangan = $"Keterangan Pelanggan #1"
            };

            _services.Update(model);
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
            _testOutputHelper.WriteLine("Data berhasil diubah.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnErrorDuplicateUpdate()
      {
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new PelangganModel()
            {
               id = 1,
               nama = "Pelanggan #2",
            };

            _services.Update(model);
         }
         catch (DataAccessException ex)
         {
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
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
            var model = new PelangganModel()
            {
               id = 10,
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
      public void ShouldReturnListOfModels()
      {
         var listModels = (List<PelangganModel>)_services.GetAll();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnModelMatchingId()
      {
         PelangganModel model = null;
         var idToGet = 1;

         try
         {
            model = (PelangganModel)_services.GetById(idToGet);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(model != null);
         Assert.True(model.id == idToGet);

         if (model != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, model);
         }
      }

   }
}
