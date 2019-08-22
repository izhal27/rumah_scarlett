using RumahScarlett.Domain.Models.KasAwal;
using RumahScarlett.Services.UnitTests.CommonTests;
using RumahScarlett.Services.UnitTests.KasAwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.KasAwal
{
   [Trait("Category", "Model Validations")]
   public class KasAwalServicesValidationTests : IClassFixture<KasAwalServicesFixture>
   {
      private KasAwalServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public KasAwalServicesValidationTests(KasAwalServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new KasAwalModel
         {
            total = 5000
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
   }
}
