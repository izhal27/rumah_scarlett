using RumahScarlett.Domain.Models.Pembelian;
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

         textBoxTotalItem.Text = listPembelianDetails.Count.ToString("N0");
         textBoxTotalQty.Text = listPembelianDetails.Sum(pd => pd.qty).ToString("N0");
         textBoxGrandTotal.Text = listPembelianDetails.Sum(pd => pd.total).ToString("N0");
      }

      private void SimpanPembelianEntryView_Load(object sender, EventArgs e)
      {
         ActiveControl = buttonSimpan;
      }

      private void buttonSimpan_Click(object sender, EventArgs e)
      {
         if (Messages.Confirm("Simpan data Pembelian?"))
         {
            var supplierId = comboBoxSupplier.ComboBox.SelectedIndex != -1 ?
                             (uint)comboBoxSupplier.ComboBox.SelectedValue : default(uint);
            var eventArgs = new PembelianEventArgs(supplierId);

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
         }
      }
   }

   public class PembelianEventArgs : EventArgs
   {
      public object SupplierId { get; }

      public PembelianEventArgs(object supplierId)
      {
         SupplierId = supplierId;
      }
   }
}
