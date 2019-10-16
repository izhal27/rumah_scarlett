using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
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

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public partial class CariBarangView : BaseCariBarangView
   {
      public event EventHandler OnSendData;

      private List<IBarangModel> _listsBarang;
      private BindingListView<BarangModel> _bindingView;
      private string _kodeOrNamaValue;

      public CariBarangView()
      {
         InitializeComponent();
      }

      public CariBarangView(List<IBarangModel> listsBarang, TipePencarian tipePencarian, string kodeOrNamaValue = default(string)) : base()
      {

         _listsBarang = listsBarang;
         _bindingView = new BindingListView<BarangModel>(_listsBarang);
         listDataGrid.DataSource = _bindingView;

         listDataGrid.Columns[7].Visible = false; // Penyesuaian stok

         switch (tipePencarian)
         {
            case TipePencarian.Penjualan:

               listDataGrid.Columns[4].Visible = false; // Hpp
               listDataGrid.Columns[6].Visible = false; // Minimal stok

               break;
            case TipePencarian.Pembelian:

               listDataGrid.Columns[5].Visible = false; // Harga jual
               listDataGrid.Columns[6].Visible = false; // Minimal stok

               break;
            case TipePencarian.PenyesuaianStok:

               listDataGrid.Columns[5].Visible = false; // Harga jual

               break;
         }

         _kodeOrNamaValue = kodeOrNamaValue;

         OnEnterKeyDown += CariBarangPembelianView_OnEnterKeyDown;
      }
      
      private void CariBarangView_Load(object sender, EventArgs e)
      {
         if (!string.IsNullOrWhiteSpace(_kodeOrNamaValue))
         {
            textBoxPencarian.Text = _kodeOrNamaValue;
         }
      }

      private void CariBarangPembelianView_OnEnterKeyDown(object sender, EventArgs e)
      {
         if (listDataGrid.SelectedItem != null)
         {
            var model = (BarangModel)listDataGrid.SelectedItem;

            OnSendData?.Invoke(this, new ModelEventArgs<BarangModel>((BarangModel)listDataGrid.SelectedItem));
         }
      }

      protected override void textBoxPencarian_TextChanged(object sender, EventArgs e)
      {
         var textBox = (TextBox)sender;

         if (!string.IsNullOrWhiteSpace(textBox.Text))
         {
            var value = textBox.Text;

            _bindingView.DataSource = _listsBarang.Where(b => b.kode.ToLower().Contains(value.ToLower()) ||
                                                         b.nama.ToLower().Contains(value.ToLower())).ToList();
         }
         else
         {
            _bindingView.DataSource = _listsBarang;
         }
      }
   }

   public enum TipePencarian
   {
      Pembelian,
      Penjualan,
      PenyesuaianStok,
   }
}
