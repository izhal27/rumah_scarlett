using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.KasAwal;
using RumahScarlett.Infrastructure.DataAccess.Repositories.KasAwal;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.KasAwal;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.KasAwal
{
   [Trait("Category", "Data Access Validations")]
   public class KasAwalServicesDataAccessTests
   {
      private IKasAwalServices _services;
      private ITestOutputHelper _testOutputHelper;

      public KasAwalServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _services = new KasAwalServices(new KasAwalRepository(), new ModelDataAnnotationCheck());
         _testOutputHelper = testOutputHelper;
      }
      
      [Fact]
      private void ShouldReturnSuccessForUpdate()
      {
         var model = new KasAwalModel()
         {
            id = 1,
            tanggal = DateTime.Now.Date,
            total = 123456
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
      public void ShouldReturnModelMatchingTanggal()
      {
         KasAwalModel model = null;
         var tanggalToGet = DateTime.Now.Date;

         try
         {
            model = (KasAwalModel)_services.GetByTanggal(tanggalToGet);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(model != null);
         Assert.True(model.tanggal == tanggalToGet);

         if (model != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, model);
         }
      }
   }
}
