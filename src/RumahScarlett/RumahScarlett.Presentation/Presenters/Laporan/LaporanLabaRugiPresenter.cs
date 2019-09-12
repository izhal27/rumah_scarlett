using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Laporan;
using System.Windows.Forms;
using System.Globalization;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanLabaRugiPresenter : ILaporanLabaRugiPresenter
   {
      private ILaporanLabaRugiView _view;

      public ILaporanLabaRugiView GetView
      {
         get { return _view; }
      }

      public LaporanLabaRugiPresenter()
      {
         _view = new LaporanLabaRugiView();

         _view.OnComboBoxBulanSelectedIndexChanged += _view_OnComboBoxBulanSelectedIndexChanged;
         _view.OnButtonCetakClick += _view_OnButtonCetakClick;
      }

      private void _view_OnComboBoxBulanSelectedIndexChanged(object sender, EventArgs e)
      {

      }

      private void _view_OnButtonCetakClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }
   }
}
