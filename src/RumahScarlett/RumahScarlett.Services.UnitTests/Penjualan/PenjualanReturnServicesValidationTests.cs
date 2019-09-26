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
   public class PenjualanReturnServicesValidationTests : IClassFixture<PenjualanReturnServicesFixture>
   {
      private PenjualanReturnServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public PenjualanReturnServicesValidationTests(PenjualanReturnServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new PenjualanReturnModel
         {
            no_nota = "20190823000001",
            tanggal = DateTime.Now,
            Penjualan = new PenjualanModel { id = 1 }
         };

         _servicesFixture.Model.PenjualanReturnDetails = new List<PenjualanReturnDetailModel>
         {
            new PenjualanReturnDetailModel {
               id = 1, penjualan_return_id=1,
               Barang = new BarangModel { id = 2, harga_jual = 1000},
               qty = 2,
               status = 1,
               keterangan =""
            },
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
      public void ShouldThrowExceptionForPenjualanEmpty()
      {
         _servicesFixture.Model.Penjualan = new PenjualanModel();

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
