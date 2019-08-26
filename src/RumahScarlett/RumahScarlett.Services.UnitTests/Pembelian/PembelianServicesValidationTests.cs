using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Pembelian
{
   [Trait("Category", "Model Validations")]
   public class PembelianServicesValidationTests : IClassFixture<PembelianServicesFixture>
   {
      private PembelianServicesFixture _servicesFixture;
      private ITestOutputHelper _testOutputHelper;

      public PembelianServicesValidationTests(PembelianServicesFixture servicesFixture, ITestOutputHelper testOutputHelper)
      {
         _servicesFixture = servicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }

      private void SetValidSampleValues()
      {
         _servicesFixture.Model = new PembelianModel
         {
            no_nota = "20190823000001",
            tanggal = DateTime.Now,
         };

         _servicesFixture.Model.Supplier = new SupplierModel { id = 1, nama = "Supplier #1" };
         _servicesFixture.Model.PembelianDetails = new List<PembelianDetailModel>
         {
            new PembelianDetailModel { id = 1,  Barang = new BarangModel { id = 1}, qty = 5, hpp = 0 }
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
      public void ShouldThrowExceptionForSupplierIdEmpty()
      {
         _servicesFixture.Model.Supplier.id = default(uint);

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

      private void WriteExceptionTestResult(Exception exception)
      {
         TestsHelper.WriteExceptionTestResult(exception, _testOutputHelper, _servicesFixture.Model);
      }
   }
}
