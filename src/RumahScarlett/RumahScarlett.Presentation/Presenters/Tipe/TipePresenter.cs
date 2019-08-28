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

namespace RumahScarlett.Presentation.Presenters.Tipe
{
   public class TipePresenter : ITipePresenter
   {
      private ITipeView _view;
      private ITipeServices _services;
      private BindingListView<TipeModel> _bindingViewTipe;

      public ITipeView GetView
      {
         get { return _view; }
      }

      public TipePresenter()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _view = new TipeView();
         _view.LoadDataEvent += _view_LoadDataEvent;
      }

      private void _view_LoadDataEvent(object sender, EventArgs e)
      {
         var listTipeModels = _services.GetAll().ToList();
         _bindingViewTipe = new BindingListView<TipeModel>(listTipeModels);
         _view.ListDataGrid.DataSource = _bindingViewTipe;
      }
   }
}
