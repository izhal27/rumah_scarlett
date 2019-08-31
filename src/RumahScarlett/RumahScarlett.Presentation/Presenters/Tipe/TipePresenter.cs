using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
         _view = new TipeView();
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_LoadData;
         _view.OnCreateData += _view_OnCreateData;
         _view.OnUpdateData += _view_OnUpdateData;
         _view.OnDeleteData += _view_OnDeleteData;
         _view.OnRefreshData += _view_OnRefreshData;

         _view.OnDataGridCellDoubleClick += OnDataGrid_CellDoubleClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         _listObj = _services.GetAll().ToList();
         _bindingView = new BindingListView<TipeModel>(_listObj);
         ((EventArgs<ListDataGrid>)e).Value.DataSource = _bindingView;
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new TipeEntryView();
         view.OnSaveData += TipeEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         ListDataGrid listDataGrid = null;

         if (sender is ListDataGrid)
         {
            listDataGrid = (ListDataGrid)sender;
         }
         else
         {
            listDataGrid = ((EventArgs<ListDataGrid>)e).Value;
         }

         if (listDataGrid != null && listDataGrid.SelectedItem != null)
         {
            var model = _services.GetById(((TipeModel)listDataGrid.SelectedItem).id);

            var view = new TipeEntryView(false, model);
            view.OnSaveData += TipeEntryView_OnSaveData;
            view.ShowDialog();
         }
      }
      private void TipeEntryView_OnSaveData(object sender, EventArgs e)
      {
         try
         {
            var model = (TipeModel)((EventArgs<ITipeModel>)e).Value;
            var view = ((TipeEntryView)sender);

            if (model.id == default(uint))
            {
               _services.Insert(model);
               view.Controls.ClearControls();
               Messages.InfoSave(_typeName);
            }
            else
            {
               _services.Update(model);
               Messages.InfoUpdate(_typeName);
               view.Close();
            }

            _view_OnRefreshData(null, null);
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

      private void _view_OnDeleteData(object sender, EventArgs e)
      {
         var listDataGrid = ((EventArgs<ListDataGrid>)e).Value;

         if (listDataGrid != null && listDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            try
            {
               var model = _services.GetById(((TipeModel)listDataGrid.SelectedItem).id);

               _services.Delete(model);
               Messages.InfoDelete(_typeName);
               _view_OnRefreshData(null, null);
            }
            catch (DataAccessException ex)
            {
               Messages.Error(ex);
               _view_OnRefreshData(null, null);
            }
            finally
            {
               if (listDataGrid.SelectedItem != null)
               {
                  listDataGrid.SelectedItem = null;
               }
            }
         }
      }

      private void _view_OnRefreshData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _bindingView.DataSource = _services.GetAll().ToList();
         }
      }

      private void OnDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }
   }
}
