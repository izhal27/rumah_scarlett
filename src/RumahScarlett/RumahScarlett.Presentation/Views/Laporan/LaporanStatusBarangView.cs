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

namespace RumahScarlett.Presentation.Views.Laporan
{
   public partial class LaporanStatusBarangView : BaseDataView, ILaporanStatusBarangView
   {
      public event EventHandler OnFormLoad;
      public event EventHandler OnButtonCetakClick;
      public event EventHandler<FilterDateEventArgs> OnButtonTampilkanClick;

      public DateTimePickerFilterTransaksi DateTimePickerFilterTransaksi
      {
         get { return dateTimePickerFilterTransaksi; }
      }

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public LaporanStatusBarangView()
      {
         InitializeComponent();
         panelUp.LabelInfo = Text.ToUpper();

         dateTimePickerFilterTransaksi.OnTampilkanClick += DateTimePickerFilterTransaksi_OnTampilkanClick;
      }

      private void LaporanStatusBarangView_Load(object sender, EventArgs e)
      {
         OnFormLoad?.Invoke(sender, e);
         ActiveControl = buttonTutup;
      }

      private void DateTimePickerFilterTransaksi_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         OnButtonTampilkanClick?.Invoke(sender, e);
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnButtonCetakClick?.Invoke(sender, e);
      }

      private void buttonTutup_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
