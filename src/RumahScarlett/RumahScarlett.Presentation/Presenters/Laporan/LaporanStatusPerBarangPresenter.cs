using RumahScarlett.Presentation.Views.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanStatusPerBarangPresenter : ILaporanStatusPerBarangPresenter
   {
      private ILaporanStatusPerBarangView _view;

      public ILaporanStatusPerBarangView GetView
      {
         get { return _view; }
      }

      public LaporanStatusPerBarangPresenter()
      {
         _view = new LaporanStatusPerBarangView();
      }
   }
}
