using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Tipe
{
   [Trait("Category", "Data Access Validations")]
   public class SubTipeServicesDataAccessTests
   {
      private ISubTipeServices _services;
      private readonly ITestOutputHelper _testOutputHelper;

      public SubTipeServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _testOutputHelper = testOutputHelper;
         _services = new SubTipeServices(new SubTipeRepository(), new ModelDataAnnotationCheck());
      }

      [Fact]
      private void ShouldReturnSuccessForInsert()
      {
         var operationSecceded = false;
         var formattedJsonStr = string.Empty;

         try
         {
            for (int i = 1; i <= 5; i++)
            {
               var model = new SubTipeModel()
               {
                  Tipe = new TipeModel { id = 1 },
                  nama = $"Sub tipe #{i}",
                  keterangan = $"Keterangan Sub tipe #{i}"
               };

               _services.Insert(model);
            }

            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = false;
            formattedJsonStr = TestsHelper.DataAccessStatusInfoToJson(ex);
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
         var model = new SubTipeModel()
         {
            Tipe = new TipeModel { id = 1 },
            nama = "Sub tipe #2",
         };

         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
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
         var model = new SubTipeModel()
         {
            id = 1,
            Tipe = new TipeModel { id = 1 },
            nama = "Sub tipe #1 (Update)",
            keterangan = "Keterangan Sub tipe #1 (Update)"
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _services.Update(model);
            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = false;
            formattedJsonStr = TestsHelper.DataAccessStatusInfoToJson(ex);
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
         var model = new SubTipeModel()
         {
            id = 2,
            Tipe = new TipeModel { id = 1 },
            nama = "Sub tipe #3",
         };

         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
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
         var model = new SubTipeModel()
         {
            id = 12,
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _services.Delete(model);
            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = false;
            formattedJsonStr = TestsHelper.DataAccessStatusInfoToJson(ex);
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
         var listModels = (List<SubTipeModel>)_services.GetAll();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnModelMatchingId()
      {
         SubTipeModel model = null;
         var idToGet = 1;

         try
         {
            model = (SubTipeModel)_services.GetById(idToGet);
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
