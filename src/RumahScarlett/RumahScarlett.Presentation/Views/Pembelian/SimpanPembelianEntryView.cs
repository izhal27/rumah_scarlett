using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Presentation.Helper;
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
   public partial class SimpanPembelianEntryView : Form, IBayarPembelianEntryView
   {
      public event EventHandler<PembelianEventArgs> OnSimpanPembelian;

      public SimpanPembelianEntryView(List<PembelianDetailModel> listPembelianDetails)
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();

         var listPembelianFixed = listPembelianDetails.Where(pd => pd.Barang.id != default(uint)).ToList();

         textBoxTotalItem.Text = listPembelianFixed.Count.ToString("N0");
         textBoxTotalQty.Text = listPembelianFixed.Sum(pd => pd.qty).ToString("N0");
         textBoxGrandTotal.Text = listPembelianFixed.Sum(pd => pd.total).ToString("N0");
      }

      private void SimpanPembelianEntryView_Load(object sender, EventArgs e)
      {
         ActiveControl = buttonSimpan;
      }

      private void buttonSimpan_Click(object sender, EventArgs e)
      {
         if (Messages.Confirm("Simpan data Pembelian?"))
         {
            var supplierModel = (SupplierModel)comboBoxSupplier.ComboBox.SelectedItem;
            var eventArgs = new PembelianEventArgs(supplierModel);

            OnSimpanPembelian?.Invoke(this, eventArgs);
         }
      }

      private void SimpanPembelianEntryView_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F2:

               comboBoxSupplier.Focus();

               break;
            case Keys.F3:

               buttonSimpan_Click(null, null);

               break;
            case Keys.F12:

               Close();

               break;
         }
      }
   }

   public class PembelianEventArgs : EventArgs
   {
      public ISupplierModel Supplier { get; }

      public PembelianEventArgs(ISupplierModel supplier)
      {
         Supplier = supplier;
      }
   }
}
