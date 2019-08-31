using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Pelanggan
{
   [Trait("Category", "Model Validations")]
   public class PelangganServicesValidationTests : IClassFixture<PelangganServicesFixture>
   {
      private PelangganServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public PelangganServicesValidationTests(PelangganServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new PelangganModel
         {
            id = 1,
            nama = "Tests",
            alamat = "Tests",
            telpon = "Tests",
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

      [Fact]
      public void ShouldThrowExceptionForLengthOfNama()
      {
         _servicesFixture.Model.nama = StringHelper.GetStringByLength(101);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForLengthOfAlamat()
      {
         _servicesFixture.Model.alamat = StringHelper.GetStringByLength(201);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForLengthOfTelpon()
      {
         _servicesFixture.Model.telpon = StringHelper.GetStringByLength(31);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForLengthOfKeterangan()
      {
         _servicesFixture.Model.keterangan = StringHelper.GetStringByLength(256);

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
