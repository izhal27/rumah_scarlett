using System;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public interface IReturnPenjualanView : IView
   {
      event EventHandler OnLoadView;
      event EventHandler OnButtonCariClick;
      event EventHandler OnButtonTambahClick;
      event EventHandler OnButtonHapusClick;
      event EventHandler OnButtonSimpanClick;
      event EventHandler OnButtonBersihkanClick;
      event EventHandler OnButtonCetakClick;

      TextBox TextBoxNoNotaReturn { get; }

      TextBox TextBoxCariNoNota { get; }
      Label LabelTanggalPenjualan { get; }
      Label LabelPelangganPenjualan { get; }
      Label LabelSubTotalPenjualan { get; }
      Label LabelDiskonPenjualan { get; }
      Label LabelTotalPenjualan { get; }
   }
}