using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public partial class BayarPenjualanEntryView : Form
   {
      public event EventHandler<PembayaranEventArgs> OnBayarPenjualan;

      decimal _uangKembali;

      public BayarPenjualanEntryView(List<PenjualanDetailModel> listPenjualanDetails)
      {
         InitializeComponent();

         panelUp.LabelInfo = "BAYAR PENJUALAN";
         
         var penjualanDetailsFixed = listPenjualanDetails.Where(pd => pd.Barang.id != default(int)).ToList();

         textBoxTotalItem.Text = penjualanDetailsFixed.Count.ToString("N0");
         textBoxTotalQty.Text = penjualanDetailsFixed.Sum(pd => pd.qty).ToString("N0");

         var subTotal = penjualanDetailsFixed.Sum(pd => pd.total);
         textBoxDiskon.MaxValue = long.Parse(subTotal.ToString(), NumberStyles.Number);

         var strSubTotal = subTotal.ToString("N0");
         textBoxSubTotal.Text = strSubTotal;
         textBoxGrandTotal.Text = strSubTotal;
         textBoxBayar.Text = strSubTotal;
      }

      private void BayarPenjualanEntryView_Load(object sender, EventArgs e)
      {
         ActiveControl = textBoxBayar;
      }

      private void buttonnBayar_Click(object sender, EventArgs e)
      {
         if (_uangKembali >= 0 && Messages.Confirm("Lanjutkan pembayaran?"))
         {
            var pelangganId = comboBoxPelanggan.ComboBox.SelectedIndex != -1 ?
                              comboBoxPelanggan.ComboBox.SelectedValue : default(uint);
            var statusPenjualan = comboBoxStatusPenjualan.SelectedIndex == 1;
            var diskon = decimal.Parse(textBoxDiskon.Text, NumberStyles.Number);

            var eventArgs = new PembayaranEventArgs(pelangganId, statusPenjualan, diskon);

            OnBayarPenjualan?.Invoke(this, eventArgs);
         }
      }

      private void textBoxDiskon_TextChanged(object sender, EventArgs e)
      {
         var subTotal = decimal.Parse(textBoxSubTotal.Text, NumberStyles.Number);
         var diskon = decimal.Parse(((TextBox)sender).Text, NumberStyles.Number);

         var grandTotal = subTotal - diskon;
         textBoxGrandTotal.Text = grandTotal.ToString("N0");
         textBoxBayar.Text = grandTotal.ToString("N0");
      }

      private void textBoxBayar_TextChanged(object sender, EventArgs e)
      {
         var grandTotal = decimal.Parse(textBoxGrandTotal.Text, NumberStyles.Number);
         var bayar = decimal.Parse(((TextBox)sender).Text, NumberStyles.Number);

         _uangKembali = bayar - grandTotal;
         textBoxKembali.Text = _uangKembali > 0 ? _uangKembali.ToString("N0") : "0";
      }

      private void BayarPenjualanEntryView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2:

               comboBoxPelanggan.Focus();

               break;
            case Keys.F3:

               comboBoxStatusPenjualan.Focus();

               break;
            case Keys.F4:

               textBoxDiskon.Focus();

               break;
            case Keys.F5:

               textBoxBayar.Focus();

               break;

            case Keys.F6:

               buttonnBayar_Click(null, null);

               break;
            case Keys.F12:

               Close();

               break;
         }
      }
   }

   public class PembayaranEventArgs : EventArgs
   {
      public object PelangganId { get; }
      public bool StatusPenjualan { get; }
      public decimal Diskon { get; }

      public PembayaranEventArgs(object pelangganId, bool statusPenjualan, decimal diskon)
      {
         PelangganId = pelangganId;
         StatusPenjualan = statusPenjualan;
         Diskon = diskon;
      }
   }
}
