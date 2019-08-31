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
   public class SubTipeServicesValidationTests : IClassFixture<SubTipeServicesFixture>
   {
      private readonly ITestOutputHelper _testOutputHelper;
      private SubTipeServicesFixture _servicesFixture;

      public SubTipeServicesValidationTests(SubTipeServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new SubTipeModel
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

         var exception = Record.Exception(() =>
         _servicesFixture.Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      private void WriteExceptionTestResult(Exception exception)
      {
         TestsHelper.WriteExceptionTestResult(exception, _testOutputHelper, _servicesFixture.Model);
      }
   }
}
