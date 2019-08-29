using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Tipe
{
   public class TipePresenter : ITipePresenter
   {
      private ITipeView _view;
      private ITipeServices _services;
      private List<ITipeModel> _listObj;
      private BindingListView<TipeModel> _bindingView;
      private static string _typeName = "Tipe";

      public ITipeView GetView
      {
         get { return _view; }
      }

      public TipePresenter()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _view = new TipeView();

         _view.OnLoadData += _view_LoadDataEvent;
         _view.OnCreateData += _view_OnCreateDataEvent;
         _view.OnUpdateData += _view_OnUpdateDataEvent;
         _view.OnDeleteData += _view_OnDeleteDataEvent;
         _view.OnRefreshData += _view_OnRefreshDataEvent;

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
         var view = new TipeEntryView();
         view.OnSaveData += TipeEntryView_OnSaveData;
         view.ShowView();
      }

      private void TipeEntryView_OnSaveData(object sender, ModelEventArgs e)
      {
         try
         {
            var model = (TipeModel)e.Model;
            var view = ((TipeEntryView)sender);

            if (model.id == default(uint))
            {
               _services.ValidateModel(model);
               _services.Insert(model);
               view.Controls.ClearControls();
               Messages.InfoSave(_typeName);
            }
            else
            {
               _services.Update(model);
               Messages.InfoUpdate(_typeName);
               view.CloseView();
            }

            _view_OnRefreshDataEvent(null, null);
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
      }

      private void _view_OnUpdateDataEvent(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null)
         {
            var view = new TipeEntryView(false, (TipeModel)_view.ListDataGrid.SelectedItem);
            view.OnSaveData += TipeEntryView_OnSaveData;
            view.ShowView();
         }
      }

      private void _view_OnDeleteDataEvent(object sender, EventArgs e)
      {
         //finally
         //{
         //   if (_view.ListDataGrid.SelectedItem != null)
         //   {
         //      _view.ListDataGrid.SelectedItem = null;
         //   }
         //}
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
