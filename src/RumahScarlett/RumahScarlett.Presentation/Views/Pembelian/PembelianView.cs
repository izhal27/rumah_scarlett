using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
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
      public event EventHandler OnCariData;
      public event EventHandler<CurrentCellKeyEventArgs> OnCellKodeKeyDown;
      public event EventHandler<CurrentCellKeyEventArgs> OnCellNamaKeyDown;
      public event EventHandler<CurrentCellKeyEventArgs> OnCellQtyKeyDown;
      public event EventHandler<CurrentCellKeyEventArgs> OnCellHppKeyDown;
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

         listDataGrid.CurrentCellKeyDown += ListDataGrid_CurrentCellKeyDown;
      }
      
      private void ListDataGrid_CurrentCellKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         if (e.KeyEventArgs.KeyCode == Keys.Return)
         {
            switch (e.ColumnIndex)
            {
               case 1: // Kode

                  OnCellKodeKeyDown?.Invoke(sender, e);

                  break;

               case 2: // Nama

                  OnCellNamaKeyDown?.Invoke(sender, e);

                  break;
               case 3: // Qty

                  OnCellQtyKeyDown?.Invoke(sender, e);

                  break;
               case 4: // HPP

                  OnCellHppKeyDown?.Invoke(sender, e);

                  break;
            }
         }
      }

      private void PembelianView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void PembelianView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2: // Cari

               OnCariData?.Invoke(sender, e);

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
