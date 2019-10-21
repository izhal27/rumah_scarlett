using RumahScarlett.Presentation.Views.Grafik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Grafik
{
   public class GrafikBarangTerjualPresenter : IGrafikBarangTerjualPresenter
   {
      private IGrafikBarangTerjualView _view;

      public IGrafikBarangTerjualView GetView
      {
         get { return _view; }
      }

      public GrafikBarangTerjualPresenter()
      {
         _view = new GrafikBarangTerjualView();
      }
   }
}
