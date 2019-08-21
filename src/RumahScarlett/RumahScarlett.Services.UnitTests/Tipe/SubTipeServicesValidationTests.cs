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
      private SubTipeServicesFixture _subTipeServicesFixture;

      public SubTipeServicesValidationTests(SubTipeServicesFixture tipeServicesFixture, ITestOutputHelper testOutputHelper)
      {
         _subTipeServicesFixture = tipeServicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }
      
      [Fact]
      public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
      {
         var exception = Record.Exception(() =>
         _subTipeServicesFixture.SubTipeServices.ValidateModel(_subTipeServicesFixture.SubTipeModel));

         Assert.Null(exception);

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForTipeIdEmpty()
      {
         _subTipeServicesFixture.SubTipeModel.tipe_id = default(uint);

         var exception = Record.Exception(() =>
         _subTipeServicesFixture.SubTipeServices.ValidateModel(_subTipeServicesFixture.SubTipeModel));

         WriteExceptionTestResult(exception);
      }
      

      [Fact]
      public void ShouldThrowExceptionForNamaEmpty()
      {
         _subTipeServicesFixture.SubTipeModel.nama = string.Empty;

         var exception = Record.Exception(() =>
         _subTipeServicesFixture.SubTipeServices.ValidateModel(_subTipeServicesFixture.SubTipeModel));

         WriteExceptionTestResult(exception);
      }
      
     [Fact]
      public void ShouldThrowExceptionForNamaTooShort()
      {
         _subTipeServicesFixture.SubTipeModel.nama = "A";

         var exception = Record.Exception(() =>
         _subTipeServicesFixture.SubTipeServices.ValidateModel(_subTipeServicesFixture.SubTipeModel));

         WriteExceptionTestResult(exception);
      }

      private void SetValidSampleValues()
      {
         _subTipeServicesFixture.SubTipeModel = new SubTipeModel
         {
            tipe_id = 1,
            nama = "Tests",
            keterangan = "Tests"
         };
      }

      private void WriteExceptionTestResult(Exception exception)
      {
         TestsHelper.WriteExceptionTestResult(exception, _testOutputHelper, _subTipeServicesFixture.SubTipeModel);
      }
   }
}
