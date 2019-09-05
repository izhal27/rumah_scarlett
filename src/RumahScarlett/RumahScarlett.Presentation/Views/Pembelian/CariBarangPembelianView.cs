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

namespace RumahScarlett.Presentation.Views.Pembelian
{
   public partial class CariBarangPembelianView : BaseCariBarangView
   {
      public event EventHandler OnSendData;

      private List<BarangModel> _listsBarang;
      private BindingListView<BarangModel> _bindingView;

      public CariBarangPembelianView(List<BarangModel> listsBarang)
      {
         InitializeComponent();

         _listsBarang = listsBarang;
         _bindingView = new BindingListView<BarangModel>(_listsBarang);
         listDataGrid.DataSource = _bindingView;

         for (int i = 2; i <= 7; i++)
         {
            if (i == 4) // HPP
            {
               continue;
            }

            listDataGrid.Columns[i].Visible = false;
         }
         
         OnEnterKeyDown += CariBarangPembelianView_OnEnterKeyDown;
      }

      private void CariBarangPembelianView_OnEnterKeyDown(object sender, EventArgs e)
      {
         if (listDataGrid.SelectedItem != null)
         {
            var model = (BarangModel)listDataGrid.SelectedItem;

            OnSendData?.Invoke(this, new EventArgs<BarangModel>((BarangModel)listDataGrid.SelectedItem));
         }
      }

      protected override void textBoxPencarian_TextChanged(object sender, EventArgs e)
      {
         var textBox = (TextBox)sender;

         if (!string.IsNullOrWhiteSpace(textBox.Text))
         {
            var value = textBox.Text;

            _bindingView.DataSource = _listsBarang.Where(b => b.kode.Contains(value) || b.nama.Contains(value)).ToList();
         }
         else
         {
            _bindingView.DataSource = _listsBarang;
         }
      }
   }
}
