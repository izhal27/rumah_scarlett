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
            var penyesuaianStokModel = new PenyesuaianStokModel
            {
               barang_id = 1,
               satuan_id = 1,
               tanggal = DateTime.Now,
               qty = 1,
               hpp = 1000,
               keterangan = "Tester"
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
      private void ShouldReturnSuccessForUpdate()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new PenyesuaianStokModel()
            {
               id = 6,
               barang_id = 1,
               satuan_id = 1,
               tanggal = new DateTime(2019, 9, 6).Date,
               qty = 5,
               hpp = 6000,
               keterangan = "Penyesuaian Stok (Update)"
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
      private void ShouldReturnSuccessForDelete()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new PenyesuaianStokModel()
            {
               id = 8,
               barang_id = 1,
               satuan_id = 1,
               tanggal = new DateTime(2019, 9, 6).Date,
               qty = 5,
               hpp = 6000,
               keterangan = "Penyesuaian Stok (Update)"
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
         var listModels = _services.GetAll().ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }
      
      [Fact]
      public void ShouldReturnModelMatchingId()
      {
         PenyesuaianStokModel model = null;
         var idToGet = 1;

         try
         {
            model = (PenyesuaianStokModel)_services.GetById(idToGet);
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
