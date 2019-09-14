﻿using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pengaturan;
using RumahScarlett.Services.Services.Pengaturan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pengaturan
{
   public class PengaturanRepository : IPengaturanRepository
   {
      public IPengaturanModel GetModel
      {
         get
         {
            var model = new PengaturanModel();

            model.nama = ConfigHelper.GetConfig("Nama") ?? "";
            model.alamat_1 = ConfigHelper.GetConfig("Alamat_1") ?? "";
            model.alamat_2 = ConfigHelper.GetConfig("Alamat_2") ?? "";
            model.telpon = ConfigHelper.GetConfig("Telpon") ?? "";
            model.kota = ConfigHelper.GetConfig("Kota") ?? "";
            model.warna_backgroud_strip = ConfigHelper.GetColorFromConfig("Warna_Background_Strip", Color.FromArgb(67, 78, 84));
            model.warna_teks_strip = ConfigHelper.GetColorFromConfig("Warna_Teks_Strip", Color.FromArgb(255, 255, 255));
            model.warna_baris_genap = ConfigHelper.GetColorFromConfig("Warna_Baris_Genap", Color.FromArgb(240, 248, 255));
            model.warna_baris_ganjil = ConfigHelper.GetColorFromConfig("Warna_Baris_Ganjil", Color.FromArgb(255, 255, 255));
            model.path_background = ConfigHelper.GetConfig("Path_Backround") ?? "";

            return model;
         }
      }

      public void Save(IPengaturanModel model)
      {
         ConfigHelper.SaveConfig("Nama", model.nama);
         ConfigHelper.SaveConfig("Alamat_1", model.alamat_1);
         ConfigHelper.SaveConfig("Alamat_2", model.alamat_2);
         ConfigHelper.SaveConfig("Telpon", model.telpon);
         ConfigHelper.SaveConfig("Kota", model.kota);
         ConfigHelper.SaveConfig("Warna_Background_Strip", model.warna_backgroud_strip.ToStringRgb());
         ConfigHelper.SaveConfig("Warna_Teks_Strip", model.warna_teks_strip.ToStringRgb());
         ConfigHelper.SaveConfig("Warna_Baris_Genap", model.warna_baris_genap.ToStringRgb());
         ConfigHelper.SaveConfig("Warna_Baris_Ganjil", model.warna_baris_ganjil.ToStringRgb());
         ConfigHelper.SaveConfig("Path_Backround", model.path_background);
      }
   }
}