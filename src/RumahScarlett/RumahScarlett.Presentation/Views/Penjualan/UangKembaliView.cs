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
   public partial class UangKembaliView : Form
   {
      public UangKembaliView(decimal kembali)
      {
         InitializeComponent();

         panelInfoDigital.LabelInfo.Text = kembali.ToString("N0");
         ActiveControl = buttonOk;
      }
   }
}
