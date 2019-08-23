using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.Pembelian;
using RumahScarlett.Services.Services.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Pembelian
{
   [Trait("Category", "Data Access Validations")]
   public class PembelianServicesDataAccessTests
   {
      private IModelDataAnnotationCheck _modelDAC;
      private IPembelianServices _services;
      private ITestOutputHelper _testOutputHelper;

      public PembelianServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _modelDAC = new ModelDataAnnotationCheck();
         _services = new PembelianServices(new PembelianRepository(), _modelDAC);
         _testOutputHelper = testOutputHelper;
      }


      [Fact]
      private void ShouldReturnSuccessForInsert()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var supplierModel = new SupplierServices(new SupplierRepository(), _modelDAC).GetById(1);
            var barang1 = new BarangServices(new BarangRepository(), _modelDAC).GetById(1);
            var barang2 = new BarangServices(new BarangRepository(), _modelDAC).GetById(2);
            var barang3 = new BarangServices(new BarangRepository(), _modelDAC).GetById(3);
            var listPembelianDetail = new List<PembelianDetailModel>
            {
               new PembelianDetailModel
               {
                  Barang = barang1,
                  qty = 5,
                  hpp = 6500                  
               },
               new PembelianDetailModel
               {
                  Barang = barang2,
                  qty = 10,
                  hpp = 8000                  
               },
               new PembelianDetailModel
               {
                  Barang = barang3,
                  qty = 15,
                  hpp = 10000                  
               }
            };

            var pembelianModel = new PembelianModel
            {
               Supplier = supplierModel,
               tanggal = DateTime.Now,
               PembelianDetails = listPembelianDetail
            };

            _services.Insert(pembelianModel);
            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = ex.DataAccessStatusInfo.OperationSucceeded;
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }

         try
         {
            Assert.True(operationSecceded);
            _testOutputHelper.WriteLine("Data berhasil ditambahkan.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

   }
}
