using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Tipe;
using Equin.ApplicationFramework;
using RumahScarlett.Domain.Models.Tipe;
using Syncfusion.WinForms.DataGrid.Events;
using System.Data;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Presentation.Helper;

namespace RumahScarlett.Presentation.Presenters.Tipe
{
   public class TipePresenter : ITipePresenter
   {
      private ITipeView _view;
      private ITipeServices _services;
      private List<ITipeModel> _listObj;
      private BindingListView<TipeModel> _bindingView;

      public ITipeView GetView
      {
         get { return _view; }
      }

      public TipePresenter()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _view = new TipeView();

         _view.OnLoadDataEvent += _view_LoadDataEvent;

         _view.OnRefreshDataEvent += _view_OnRefreshDataEvent;

         _view.ListDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
      }

      private void _view_LoadDataEvent(object sender, EventArgs e)
      {
         _listObj = _services.GetAll().ToList();
         _bindingView = new BindingListView<TipeModel>(_listObj);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateDataEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnUpdateDataEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnDeleteDataEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnRefreshDataEvent(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _bindingView.DataSource = _services.GetAll().ToList();
         }
      }

      private void ListDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateDataEvent(null, null);
      }
   }
}
