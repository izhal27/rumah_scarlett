using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Pembelian
{
   public partial class PembelianView : BaseDataView, IPembelianView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnTambahData;
      public event EventHandler OnHapusData;
      public event EventHandler OnSimpanData;
      public event EventHandler OnBersihkanData;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public ComboBox ComboBoxSupplier
      {
         get { return comboBoxSupplier; }
      }

      public Label LabelTotalQty
      {
         get { return labelTotalQty; }
      }

      public Label LabelTotalPembelian
      {
         get { return labelTotalPembelian; }
      }

      public PembelianView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "TRANSAKSI PEMBELIAN BARANG";
      }

      private void PembelianView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void PembelianView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2: // Tambah

               OnTambahData?.Invoke(sender, e);

               break;
            case Keys.F3: // Hapus

               OnHapusData?.Invoke(sender, e);

               break;
            case Keys.F4: // Simpan

               OnSimpanData?.Invoke(sender, e);

               break;
            case Keys.F5: // Bersihkan

               OnBersihkanData?.Invoke(sender, e);

               break;
            case Keys.F12: // Tutup

               Close();

               break;
         }
      }
   }
}
