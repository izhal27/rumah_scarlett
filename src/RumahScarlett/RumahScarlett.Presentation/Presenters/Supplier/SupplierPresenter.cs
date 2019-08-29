using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Supplier;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Supplier;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Supplier
{
   public class SupplierPresenter : ISupplierPresenter
   {
      private ISupplierView _view;
      private ISupplierServices _services;
      private List<ISupplierModel> _listObj;
      private BindingListView<SupplierModel> _bindingView;
      private static string _typeName = "Supplier";

      public ISupplierView GetView
      {
         get { return _view; }
      }

      public SupplierPresenter()
      {
         _view = new SupplierView();
         _services = new SupplierServices(new SupplierRepository(), new ModelDataAnnotationCheck());

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
         _bindingView = new BindingListView<SupplierModel>(_listObj);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateDataEvent(object sender, EventArgs e)
      {
         var view = new Views.Supplier.SupplierEntryView();
         view.OnSaveData += TipeEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateDataEvent(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null)
         {
            var view = new SupplierEntryView(false, (SupplierModel)_view.ListDataGrid.SelectedItem);
            view.OnSaveData += TipeEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void TipeEntryView_OnSaveData(object sender, ModelEventArgs e)
      {
         try
         {
            var model = (SupplierModel)e.Model;
            var view = ((SupplierEntryView)sender);

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

      private void _view_OnDeleteDataEvent(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            var model = (SupplierModel)_view.ListDataGrid.SelectedItem;

            try
            {
               _services.Delete(model);
               Messages.InfoDelete(_typeName);
               _view_OnRefreshDataEvent(null, null);
            }
            catch (DataAccessException ex)
            {
               Messages.Error(ex);
            }
            finally
            {
               if (_view.ListDataGrid.SelectedItem != null)
               {
                  _view.ListDataGrid.SelectedItem = null;
               }
            }
         }
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
