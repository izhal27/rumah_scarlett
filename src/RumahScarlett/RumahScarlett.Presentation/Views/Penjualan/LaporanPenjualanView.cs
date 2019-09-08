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
   public partial class LaporanPenjualanView : BaseDataView, ILaporanView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnDeleteData;
      public event EventHandler OnPrintData;
      public event EventHandler OnDetailClick;
      public event EventHandler OnTampilkanClick;

      public DateTimePickerFilterTransaksi DateTimePickerFilterTransaksi
      {
         get { return dateTimePickerFilterTransaksi; }
      }

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public LaporanPenjualanView()
      {
         InitializeComponent();

         panelUp.LabelInfo = $"LAPORAN {Text.ToUpper()}";
      }
   }
}
