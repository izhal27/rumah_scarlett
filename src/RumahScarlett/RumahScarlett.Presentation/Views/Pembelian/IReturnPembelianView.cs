using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Pembelian
{
   public interface IReturnPembelianView : IView
   {
      event EventHandler OnLoadView;
      event EventHandler OnButtonCariClick;
      event EventHandler OnButtonTambahClick;
      event EventHandler OnButtonHapusClick;
      event EventHandler OnButtonSimpanClick;
      event EventHandler OnButtonBersihkanClick;
      event EventHandler OnButtonCetakNotaClick;

      ListDataGrid ListDataGrid { get; }

      TextBox TextBoxNoNotaReturn { get; }
      Button ButtonCari { get; }
      Label LabelQtyReturn { get; }
      Label LabelTotalReturn { get; }

      TextBox TextBoxCariNoNota { get; }
      Label LabelTanggalPembelian { get; }
      Label LabelPelangganPembelian { get; }
      Label LabelSubTotalPembelian { get; }
      Label LabelDiskonPembelian { get; }
      Label LabelTotalPembelian { get; }
      Label LabelDibayarPembelian { get; }
      Label LabelKembaliPembelian { get; }
   }
}