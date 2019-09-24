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

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public partial class ReturnPenjualanView : BaseDataView, IReturnPenjualanView
   {
      public event EventHandler OnButtonCariClick;
      public event EventHandler OnLoadView;
      public event EventHandler OnButtonTambahClick;
      public event EventHandler OnButtonHapusClick;
      public event EventHandler OnButtonSimpanClick;
      public event EventHandler OnButtonBersihkanClick;
      public event EventHandler OnButtonCetakNotaClick;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public TextBox TextBoxNoNotaReturn
      {
         get { return textBoxNoNotaRetrun; }
      }

      public Label LabelQtyReturn
      {
         get { return labelQtyReturn; }
      }

      public Label LabelTotalReturn
      {
         get { return labelTotalReturn; }
      }

      public TextBox TextBoxCariNoNota
      {
         get { return textBoxCariNoNota; }
      }

      public Label LabelTanggalPenjualan
      {
         get { return labelTanggalPenjualan; }
      }

      public Label LabelPelangganPenjualan
      {
         get { return labelPelangganPenjualan; }
      }

      public Label LabelSubTotalPenjualan
      {
         get { return labelSubTotalPenjualan; }
      }

      public Label LabelDiskonPenjualan
      {
         get { return labelDiskonPenjualan; }
      }

      public Label LabelTotalPenjualan
      {
         get { return labelTotalPenjualan; }
      }

      public ReturnPenjualanView()
      {
         InitializeComponent();

         panelUp.LabelInfo = Text.ToUpper();
      }

      private void ReturnPenjualanView_Load(object sender, EventArgs e)
      {
         labelTanggalReturn.Text = DateTime.Now.ToShortDateString();
         OnLoadView?.Invoke(sender, e);
         ActiveControl = buttonTutup;
      }

      private void buttonCari_Click(object sender, EventArgs e)
      {
         OnButtonCariClick?.Invoke(sender, e);
      }

      private void buttonTambah_Click(object sender, EventArgs e)
      {
         OnButtonTambahClick?.Invoke(sender, e);
      }

      private void buttonHapus_Click(object sender, EventArgs e)
      {
         OnButtonHapusClick?.Invoke(sender, e);
      }

      private void buttonSimpan_Click(object sender, EventArgs e)
      {
         OnButtonSimpanClick?.Invoke(sender, e);
      }

      private void buttonBersihkan_Click(object sender, EventArgs e)
      {
         OnButtonBersihkanClick?.Invoke(sender, e);
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnButtonCetakNotaClick?.Invoke(sender, e);
      }

      private void buttonTutup_Click(object sender, EventArgs e)
      {
         if (!listDataGrid.CurrentCell.IsEditing)
         {
            Close();
         }
      }
   }
}
