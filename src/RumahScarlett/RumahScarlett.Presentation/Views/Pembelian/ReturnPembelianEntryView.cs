using RumahScarlett.Domain.Helper;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pembelian;
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
   public partial class ReturnPembelianEntryView : Form
   {
      public event EventHandler<ReturnPembelianEventArgs> OnButtonOkClick;
      private IEnumerable<IPembelianDetailModel> _pembelianDetails;

      public ReturnPembelianEntryView(IEnumerable<IPembelianDetailModel> pembelianDetails)
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();

         _pembelianDetails = pembelianDetails;
         comboBoxBarang.SetDataSource(_pembelianDetails.Select(pd =>
                                      new KeyValuePair<object, string>(pd.Barang, pd.barang_nama)).ToList(),
                                      false);
         comboBoxStatus.SetDataSource(DataSourceHelper.StatusReturn, false);
      }

      private void ReturnPembelianEntryView_Load(object sender, EventArgs e)
      {
         SetTextBoxQtyMaxValue();
         comboBoxBarang.SelectedIndexChanged += ComboBoxBarang_SelectedIndexChanged;
      }

      private void ComboBoxBarang_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetTextBoxQtyMaxValue();
      }

      private void SetTextBoxQtyMaxValue()
      {
         if (comboBoxBarang.SelectedIndex != -1)
         {
            var barangSelected = (IBarangModel)comboBoxBarang.SelectedValue;
            var pembelianDetailModel = _pembelianDetails.Where(pd => pd.barang_id == barangSelected.id).FirstOrDefault();

            if (pembelianDetailModel != null)
            {
               var maxQty = (pembelianDetailModel.qty - pembelianDetailModel.qty_return);
               textBoxQty.Text = "1";
               textBoxQty.MaxValue = maxQty;
               labelMax.Text = $"Max = {maxQty.ToString("N0")}";
            }
         }
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         var qty = int.Parse(textBoxQty.Text, NumberStyles.Number);

         if (comboBoxBarang.SelectedIndex == -1)
         {
            Messages.Warning("Maaf, Anda belum memilih barang.");
            return;
         }

         if (qty <= 0)
         {
            Messages.Warning("Maaf, Qty harus diisi.");
            return;
         }

         var eventArgs = new ReturnPembelianEventArgs((IBarangModel)comboBoxBarang.SelectedValue, 
                                                      int.Parse(textBoxQty.Text.ToString(), NumberStyles.Number),
                                                     (int)comboBoxStatus.SelectedValue, textBoxKeterangan.Text);
         OnButtonOkClick?.Invoke(sender, eventArgs);
         DialogResult = DialogResult.OK;
      }
   }

   public class ReturnPembelianEventArgs : EventArgs
   {
      public IBarangModel Barang { get; }
      public int Qty { get; }
      public int Status { get; }
      public string Keterangan { get; }

      public ReturnPembelianEventArgs(IBarangModel barang, int qty, int status, string keterangan)
      {
         Barang = barang;
         Qty = qty;
         Status = status;
         Keterangan = keterangan;
      }
   }
}
