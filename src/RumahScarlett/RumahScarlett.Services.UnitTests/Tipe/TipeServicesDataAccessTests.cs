using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
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
   public class TipeServicesDataAccessTests
   {
      private TipeServices _services;
      private readonly ITestOutputHelper _testOutputHelper;

      public TipeServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _testOutputHelper = testOutputHelper;
          var connString = @"Server=localhost;Database=rumah_scarlett_dev;Uid=root;Pwd=;";
         _services = new TipeServices(new TipeRepository(connString), new ModelDataAnnotationCheck());
      }

      [Fact]
      private void ShouldReturnSuccessForAdd()
      {
         var tipeModel = new TipeModel()
         {
            nama = "Tipe #1",
            keterangan= "Keterangan Tipe #1"
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _services.Create(tipeModel);
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
            _testOutputHelper.WriteLine("Data tipe berhasil ditambahkan.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForUpdate()
      {
         var barangModel = new TipeModel()
         {
            id = 1,
            nama = "Tipe #1 (Update)",
            keterangan = "Keterangan Tipe #1 (Update)"
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _services.Update(barangModel);
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
            _testOutputHelper.WriteLine("Data tipe berhasil diubah.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForDelete()
      {
         var barangModel = new TipeModel()
         {
            id = 5,
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _services.Delete(barangModel);
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
            _testOutputHelper.WriteLine("Data tipe berhasil dihapus.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      public void ShouldReturnListOfTipes()
      {
         var listTipe = (List<TipeModel>)_services.GetAll();

         Assert.NotEmpty(listTipe);

         foreach (var barang in listTipe)
         {
            var strBuilder = new StringBuilder();
            strBuilder.Append($"ID --> {barang.id}").AppendLine();
            strBuilder.Append($"Nama --> {barang.nama}").AppendLine();
            strBuilder.Append($"Keterangan --> {barang.keterangan}").AppendLine();

            _testOutputHelper.WriteLine(strBuilder.ToString());
         }
      }

      [Fact]
      public void ShouldReturnBarangModelMatchingId()
      {
         TipeModel tipeModel = null;
         int idToGet = 1;

         try
         {
            tipeModel = (TipeModel)_services.GetById(idToGet);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(tipeModel != null);
         Assert.True(tipeModel.id == idToGet);

         if (tipeModel != null)
         {
            var barangModelJsonStr = JsonConvert.SerializeObject(tipeModel);
            var formattedJsonStr = JToken.Parse(barangModelJsonStr).ToString();
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

   }
}
