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
            no_nota = "20190825000001",
            tanggal = DateTime.Now,
         };
		 
         _servicesFixture.Model.PenyesuaianStokDetails = new List<PenyesuaianStokDetailModel>
         {
            new PenyesuaianStokDetailModel { id = 1,  Barang = new BarangModel { id = 1} }
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
      public void ShouldThrowExceptionForTanggalEmpty()
      {
         _servicesFixture.Model.tanggal = default(DateTime);

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
