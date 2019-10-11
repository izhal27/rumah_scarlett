using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Role;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Role;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Role;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Role
{
   [Trait("Category", "Data Access Validations")]
   public class FormActionServicesDataAccessTests
   {
      private IFormActionServices _services;
      private readonly ITestOutputHelper _testOutputHelper;

      public FormActionServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _testOutputHelper = testOutputHelper;
         _services = new FormActionServices(new FormActionRepository(), new ModelDataAnnotationCheck());
      }

      [Fact]
      private void ShouldReturnSuccessForInsert()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            string[] formNames = new string[]
            {
               "TipeView", "SubTipeView", "BarangView", "SupplierView", "PelangganView"
            };

            foreach (var form in formNames)
            {
               var model = new FormActionModel()
               {
                  form_name = form,
                  form_text = "Tipe",
                  act_1 = "Tambah",
                  act_2 = "Ubah",
                  act_3 = "Hapus",
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
            var model = new FormActionModel()
            {
               form_name = "TipeView",
               form_text = "Tipe",
               act_1 = "Tambah",
               act_2 = "Ubah",
               act_3 = "Hapus",
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
      public void ShouldReturnListOfModels()
      {
         var listModels = _services.GetAll().ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnModelMatchingFormName()
      {
         FormActionModel model = null;
         var formNameToGet = "TipeView";

         try
         {
            model = (FormActionModel)_services.GetByFormName(formNameToGet);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(model != null);
         Assert.True(model.form_name == formNameToGet);

         if (model != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, model);
         }
      }

   }
}
