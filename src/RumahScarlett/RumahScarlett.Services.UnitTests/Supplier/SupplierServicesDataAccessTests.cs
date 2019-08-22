using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Supplier;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Supplier
{
   public class SupplierServicesDataAccessTests
   {
      private ISupplierServices _services;
      private ITestOutputHelper _testOutputHelper;

      public SupplierServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _services = new SupplierServices(new SupplierRepository(), new ModelDataAnnotationCheck());
         _testOutputHelper = testOutputHelper;
      }
      
      [Fact]
      private void ShouldReturnSuccessForInsert()
      {
         var model = new SupplierModel()
         {
            nama = "Supplier #6",
            alamat = "Alamat #6",
            telpon = "+62 8123456789",
            fax = "+62 8123456789",
            email = "supplier@tests.com",
            website = "http://www.supplier.com",
            contact_person = "Contact person #6"
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _services.Insert(model);
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
         var model = new SupplierModel()
         {
            nama = "Supplier #2",
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
         var model = new SupplierModel()
         {
            id = 1,
            nama = "Supplier #1 (Update)",
            alamat = "Alamat #1",
            telpon = "+62 8123456789",
            fax = "+62 8123456789",
            email = "supplier@tests.com",
            website = "http://www.supplier.com",
            contact_person = "Contact person #1"
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
         var model = new SupplierModel()
         {
            id = 1,
            nama = "Supplier #2",
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
         var model = new SupplierModel()
         {
            id = 6,
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
         var listModels = (List<SupplierModel>)_services.GetAll();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }
      
      [Fact]
      public void ShouldReturnModelMatchingId()
      {
         SupplierModel model = null;
         var idToGet = 1;

         try
         {
            model = (SupplierModel)_services.GetById(idToGet);
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
