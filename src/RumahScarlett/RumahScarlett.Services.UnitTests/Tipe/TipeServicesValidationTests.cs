using Newtonsoft.Json.Linq;
using RumahScarlett.Domain.Models.Tipe;
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
      private TipeServicesFixture _tipeServicesFixture;

      public TipeServicesValidationTests(TipeServicesFixture tipeServicesFixture, ITestOutputHelper testOutputHelper)
      {
         _tipeServicesFixture = tipeServicesFixture;
         _testOutputHelper = testOutputHelper;
         SetValidSampleValues();
      }
      
      [Fact]
      public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
      {
         var exception = Record.Exception(() =>
         _tipeServicesFixture.TipeServices.ValidateModel(_tipeServicesFixture.TipeModel));

         Assert.Null(exception);

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForNamaEmpty()
      {
         _tipeServicesFixture.TipeModel.nama = string.Empty;

         var exception = Record.Exception(() =>
         _tipeServicesFixture.TipeServices.ValidateModel(_tipeServicesFixture.TipeModel));

         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForNamaTooShort()
      {
         _tipeServicesFixture.TipeModel.nama = "A";

         var exception = Record.Exception(() =>
         _tipeServicesFixture.TipeServices.ValidateModel(_tipeServicesFixture.TipeModel));

         WriteExceptionTestResult(exception);
      }

      private void SetValidSampleValues()
      {
         _tipeServicesFixture.TipeModel = new TipeModel
         {
            nama = "Tests",
            keterangan = "Tests"
         };
      }

      private void WriteExceptionTestResult(Exception exception)
      {
         if (exception != null)
         {
            _testOutputHelper.WriteLine(exception.Message);
         }
         else
         {
            StringBuilder strBuilder = new StringBuilder();
            JObject json = JObject.FromObject(_tipeServicesFixture.TipeModel);
            strBuilder.Append("********** Tidak ada exception yang terjadi *********").AppendLine();

            foreach (var jProperty in json.Properties())
            {
               strBuilder.Append(jProperty.Name).Append(" ---> ").Append(jProperty.Value).AppendLine();
            }

            _testOutputHelper.WriteLine(strBuilder.ToString());
         }
      }
   }
}
