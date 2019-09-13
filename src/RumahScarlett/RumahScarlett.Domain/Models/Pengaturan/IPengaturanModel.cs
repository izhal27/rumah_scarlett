using System.ComponentModel;
using System.Drawing;

namespace RumahScarlett.Domain.Models.Pengaturan
{
   public interface IPengaturanModel
   {
      string nama { get; set; }
      string alamat_1 { get; set; }
      string alamat_2 { get; set; }
      string telpon { get; set; }
      string kota { get; set; }
      Color warna_backgroud_strip { get; set; }
      Color warna_teks_strip { get; set; }
      Color warna_baris_genap { get; set; }
      Color warna_baris_ganjil { get; set; }
      string path_background { get; set; }
   }
}