using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Penjualan;
using RumahScarlett.Domain.Models.Penjualan;
using Equin.ApplicationFramework;

namespace RumahScarlett.Presentation.Presenters.Penjualan
{
   public class PenjualanReturnPresenter : IPenjualanReturnPresenter
   {
      private IReturnPenjualanView _view;
      private BindingListView<PenjualanReturnModel> _bindingView;
      private List<PenjualanReturnModel> _listObjs;
      public IReturnPenjualanView GetView
      {
         get { return _view; }
      }

      public PenjualanReturnPresenter()
      {
         _view = new ReturnPenjualanView();

         _view.OnLoadView += _view_OnLoadView;
      }

      private void _view_OnLoadView(object sender, EventArgs e)
      {
         _listObjs = new List<PenjualanReturnModel>();
         _bindingView = new BindingListView<PenjualanReturnModel>(_listObjs);
         _view.ListDataGrid.DataSource = _bindingView;
         _view.ListDataGrid.Columns[5].AllowEditing = true;
      }
   }
}
