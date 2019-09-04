using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Pembelian
{
   public interface IPembelianView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnTambahData;
      event EventHandler OnHapusData;
      event EventHandler OnSimpanData;
      event EventHandler OnBersihkanData;

      ListDataGrid ListDataGrid { get; }
      ComboBox ComboBoxSupplier { get; }
      Label LabelTotalQty { get; }
      Label LabelTotalPembelian { get; }
   }
}
