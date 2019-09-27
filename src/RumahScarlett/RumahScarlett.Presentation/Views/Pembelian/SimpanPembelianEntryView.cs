using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Presentation.Helper;
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

namespace RumahScarlett.Presentation.Views.Pembelian
{
   public partial class SimpanPembelianEntryView : Form, IBayarPembelianEntryView
   {
      public event EventHandler<PembelianEventArgs> OnSimpanPembelian;

      public SimpanPembelianEntryView(List<PembelianDetailModel> listPembelianDetails)
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();

         var pembelianDetailsFixed = listPembelianDetails.Where(pd => pd.Barang.id != default(uint)).ToList();

         textBoxTotalItem.Text = pembelianDetailsFixed.Count.ToString("N0");
         textBoxTotalQty.Text = pembelianDetailsFixed.Sum(pd => pd.qty).ToString("N0");

         var subTotal = pembelianDetailsFixed.Sum(pd => pd.total);
         textBoxDiskon.MaxValue = long.Parse(subTotal.ToString(), NumberStyles.Number);

         var strSubTotal = subTotal.ToString("N0");
         textBoxSubTotal.Text = strSubTotal;
         textBoxGrandTotal.Text = strSubTotal;
      }

      private void SimpanPembelianEntryView_Load(object sender, EventArgs e)
      {
         ActiveControl = buttonSimpan;
      }

      private void buttonSimpan_Click(object sender, EventArgs e)
      {
         if (Messages.Confirm("Simpan data Pembelian?"))
         {
            var supplierModel = comboBoxSupplier.SelectedItem;
            var diskon = decimal.Parse(textBoxDiskon.Text, NumberStyles.Number);
            var grandTotal = decimal.Parse(textBoxGrandTotal.Text, NumberStyles.Number);
            var eventArgs = new PembelianEventArgs(supplierModel, diskon, grandTotal);

            OnSimpanPembelian?.Invoke(this, eventArgs);
         }
      }

      private void textBoxDiskon_TextChanged(object sender, EventArgs e)
      {
         var subTotal = decimal.Parse(textBoxSubTotal.Text, NumberStyles.Number);
         var diskon = decimal.Parse(((TextBox)sender).Text, NumberStyles.Number);

         var grandTotal = subTotal - diskon;
         textBoxGrandTotal.Text = grandTotal.ToString("N0");
      }

      private void SimpanPembelianEntryView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2:

               comboBoxSupplier.Focus();

               break;
            case Keys.F3:

               textBoxDiskon.Focus();

               break;
            case Keys.F4:

               buttonSimpan_Click(null, null);

               break;
            case Keys.F12:

               Close();

               break;
            case Keys.Enter:

               if (ActiveControl == comboBoxSupplier)
               {
                  textBoxDiskon.Focus();
               }
               else if (textBoxDiskon.Focused)
               {
                  buttonSimpan.Focus();
               }

               break;
         }
      }
   }

   public class PembelianEventArgs : EventArgs
   {
      public ISupplierModel Supplier { get; }
      public decimal Diskon { get; }
      public decimal GrandTotal { get; }

      public PembelianEventArgs(ISupplierModel supplier, decimal diskon, decimal grandTotal)
      {
         Supplier = supplier;
         Diskon = diskon;
         GrandTotal = grandTotal;
      }
   }
}
