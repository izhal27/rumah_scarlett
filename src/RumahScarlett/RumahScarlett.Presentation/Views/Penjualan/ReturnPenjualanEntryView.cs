using RumahScarlett.Domain.Helper;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Penjualan;
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

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public partial class ReturnPenjualanEntryView : Form
   {
      public event EventHandler<ReturnPenjualanEventArgs> OnButtonOkClick;
      private IEnumerable<IPenjualanDetailModel> _penjualanDetails;

      public ReturnPenjualanEntryView(IEnumerable<IPenjualanDetailModel> penjualanDetails)
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();

         _penjualanDetails = penjualanDetails;
         comboBoxBarang.SetDataSource(_penjualanDetails.Select(pd =>
                                      new KeyValuePair<object, string>(pd.Barang, pd.barang_nama)).ToList(),
                                      false);
         comboBoxStatus.SetDataSource(DataSourceHelper.StatusReturn, false);
      }

      private void ReturnPenjualanEntryView_Load(object sender, EventArgs e)
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
            var penjualanDetailModel = _penjualanDetails.Where(pd => pd.barang_id == barangSelected.id).FirstOrDefault();

            if (penjualanDetailModel != null)
            {
               var maxQty = (penjualanDetailModel.qty - penjualanDetailModel.qty_return);
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

         var eventArgs = new ReturnPenjualanEventArgs((IBarangModel)comboBoxBarang.SelectedValue, 
                                                      int.Parse(textBoxQty.Text.ToString(), NumberStyles.Number),
                                                     (int)comboBoxStatus.SelectedValue, textBoxKeterangan.Text);
         OnButtonOkClick?.Invoke(sender, eventArgs);
         DialogResult = DialogResult.OK;
      }
   }

   public class ReturnPenjualanEventArgs : EventArgs
   {
      public IBarangModel Barang { get; }
      public int Qty { get; }
      public int Status { get; }
      public string Keterangan { get; }

      public ReturnPenjualanEventArgs(IBarangModel barang, int qty, int status, string keterangan)
      {
         Barang = barang;
         Qty = qty;
         Status = status;
         Keterangan = keterangan;
      }
   }
}
