﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.UnitTests.CommonTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RumahScarlett.Services.UnitTests.Barang
{
   [Trait("Category", "Data Access Validations")]
   public class BarangServicesDataAccessTests
   {
      private IBarangServices _services;
      private ITestOutputHelper _testOutputHelper;

      public BarangServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _services = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());
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
            for (int i = 1; i <= 10; i++)
            {
               var model = new BarangModel
               {
                  tipe_id = (uint)(i % 2 == 0 ? 2 : 1),
                  sub_tipe_id = (uint)(i % 2 == 0 ? 2 : 1),
                  supplier_id = (uint)(i % 2 == 0 ? 2 : 1),
                  satuan_id = (uint)(i % 2 == 0 ? 2 : 1),
                  kode = $"0000{i}",
                  nama = $"Nama Barang #{i}",
                  stok = 0,
                  hpp = 1000,
                  harga_jual = 2000,
                  minimal_stok = 0,
               };

               _services.Insert(model);
            }

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

      [Fact]
      private void ShouldReturnErrorDuplicateKodeInsert()
      {
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new BarangModel()
            {
               id = 1,
               tipe_id = 1,
               sub_tipe_id = 1,
               supplier_id = 1,
               kode = "kode_barang_2",
               nama = "Barang #1"
            };

            _services.Insert(model);
         }
         catch (DataAccessException ex)
         {
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnErrorDuplicateNamaInsert()
      {
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new BarangModel()
            {
               id = 1,
               tipe_id = 1,
               sub_tipe_id = 1,
               supplier_id = 1,
               kode = "kode_barang_1",
               nama = "Barang #2"
            };

            _services.Insert(model);
         }
         catch (DataAccessException ex)
         {
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }
      
      [Fact]
      private void ShouldReturnSuccessForUpdate()
      {
         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new BarangModel
            {
               id = 1,
               tipe_id = 1,
               sub_tipe_id = 1,
               supplier_id = 1,
               kode = "kode_barang_1_Update_",
               nama = "Nama Barang #1 (Update)"
            };

            _services.Update(model);
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
            _testOutputHelper.WriteLine("Data berhasil diubah.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }
      
      [Fact]
      private void ShouldReturnErrorDuplicateUpdate()
      {
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            var model = new BarangModel
            {
               id = 1,
               tipe_id = 1,
               sub_tipe_id = 1,
               supplier_id = 1,
               kode = "kode_barang_2",
               nama = "Nama Barang #2"
            };

            _services.Update(model);
         }
         catch (DataAccessException ex)
         {
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }
      
      [Fact]
      public void ShouldReturnListOfModels()
      {
         var listModels = _services.GetAll().ToList();

         Assert.NotEmpty(listModels);

         TestsHelper.WriteListModels(_testOutputHelper, listModels);
      }

      [Fact]
      public void ShouldReturnModelMatchingId()
      {
         BarangModel model = null;
         var idToGet = 1;

         try
         {
            model = (BarangModel)_services.GetById(idToGet);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(model != null);
         Assert.True(model.id == idToGet);

         if (model != null)
         {
            TestsHelper.WriteModel(_testOutputHelper, model);
         }
      }
   }
}
