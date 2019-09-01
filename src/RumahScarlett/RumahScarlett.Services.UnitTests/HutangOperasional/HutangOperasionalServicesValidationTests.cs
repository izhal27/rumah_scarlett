using RumahScarlett.Domain.Models.HutangOperasional;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.HutangOperasional
{
   [Trait("Category", "Model Validations")]
   public class HutangOperasionalServicesValidationTests : IClassFixture<HutangOperasionalServicesFixture>
   {
      private HutangOperasionalServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public HutangOperasionalServicesValidationTests(HutangOperasionalServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new HutangOperasionalModel
         {
            id = 1,
            tanggal = DateTime.Now.Date,
            jumlah = 1000000,
            keterangan = "Belum ada",
            status_hutang = false
         };
      }

      [Fact]
      public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
      {
         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         Assert.Null(exception);

         WriteExceptionTestResult(exception);
      }

      private void WriteExceptionTestResult(Exception exception)
      {
         TestsHelper.WriteExceptionTestResult(exception, _testOutputHelper, _servicesFixture.Model);
      }

      [Fact]
      public void ShouldThrowExceptionForTanggalEmpty()
      {
         _servicesFixture.Model.tanggal = default(DateTime);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionJumlahEmpty()
      {
         _servicesFixture.Model.jumlah = default(decimal);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }
   }
}
