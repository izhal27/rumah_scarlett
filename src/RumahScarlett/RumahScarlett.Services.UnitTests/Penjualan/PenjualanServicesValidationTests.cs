using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Penjualan
{
   [Trait("Category", "Model Validations")]
   public class PenjualanServicesValidationTests : IClassFixture<PenjualanServicesFixture>
   {
      private PenjualanServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public PenjualanServicesValidationTests(PenjualanServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new PenjualanModel
         {
            no_nota = "20190823000001",
            tanggal = DateTime.Now,
         };

         _servicesFixture.Model.PenjualanDetails = new List<PenjualanDetailModel>
         {
            new PenjualanDetailModel { id = 1,  Barang = new BarangModel { id = 1, harga_jual = 1000}, qty = 1 },
            new PenjualanDetailModel { id = 1,  Barang = new BarangModel { id = 2, harga_jual = 1000}, qty = 2 },
            new PenjualanDetailModel { id = 1,  Barang = new BarangModel { id = 3, harga_jual = 1000}, qty = 3 }
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
