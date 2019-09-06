using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
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
   [Trait("Category", "Model Validations")]
   public class PenyesuaianStokServicesValidationTests : IClassFixture<PenyesuaianStokServicesFixture>
   {
      private PenyesuaianStokServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public PenyesuaianStokServicesValidationTests(PenyesuaianStokServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new PenyesuaianStokModel
         {
            id = 1,
            barang_id = 1,
            satuan_id = 1,
            tanggal = DateTime.Now,
            qty = 1,
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
      public void ShouldThrowExceptionForBarangIdEmpty()
      {
         _servicesFixture.Model.barang_id = default(uint);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForSatuanIdEmpty()
      {
         _servicesFixture.Model.satuan_id = default(uint);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
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
      public void ShouldThrowExceptionForQtyEmpty()
      {
         _servicesFixture.Model.qty = default(int);

         var exception = Record.Exception(() => _servicesFixture
                                                .Services.ValidateModel(_servicesFixture.Model));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForKeteranganEmpty()
      {
         _servicesFixture.Model.keterangan = default(string);

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
