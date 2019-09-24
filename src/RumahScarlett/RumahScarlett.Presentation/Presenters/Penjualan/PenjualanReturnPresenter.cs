using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Penjualan;

namespace RumahScarlett.Presentation.Presenters.Penjualan
{
   public class PenjualanReturnPresenter : IPenjualanReturnPresenter
   {
      private IReturnPenjualanView _view;

      public IReturnPenjualanView GetView
      {
         get { return _view; }
      }

      public PenjualanReturnPresenter()
      {
         _view = new ReturnPenjualanView();
      }
   }
}
