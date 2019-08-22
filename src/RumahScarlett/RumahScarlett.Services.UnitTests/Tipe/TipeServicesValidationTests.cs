using Newtonsoft.Json.Linq;
using RumahScarlett.Domain.Models.Tipe;
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
   [Trait("Category", "Model Validations")]
   public class TipeServicesValidationTests : IClassFixture<TipeServicesFixture>
   {
      private readonly ITestOutputHelper _testOutputHelper;
      private TipeServicesFixture _servicesFixture;

      public TipeServicesValidationTests(TipeServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new TipeModel
         {
            nama = "Tests",
            keterangan = "Tests"
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

      [Fact]
      public void ShouldThrowExceptionForNamaEmpty()
      {
         _servicesFixture.Model.nama = string.Empty;

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForNamaTooShort()
      {
         _servicesFixture.Model.nama = "A";

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      private void WriteExceptionTestResult(Exception exception)
      {
         TestsHelper.WriteExceptionTestResult(exception, _testOutputHelper, _servicesFixture.Model);
      }
   }
}
