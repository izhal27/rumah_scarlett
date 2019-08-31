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

         _view.OnLoadData += _view_LoadData;
         _view.OnCreateData += _view_OnCreateData;
         _view.OnUpdateData += _view_OnUpdateData;
         _view.OnDeleteData += _view_OnDeleteData;
         _view.OnRefreshData += _view_OnRefreshData;

         _view.ListDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         _listObj = _services.GetAll().ToList();
         _bindingView = new BindingListView<SupplierModel>(_listObj);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new SupplierEntryView();
         view.OnSaveData += SupplierEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null)
         {
            var model = _services.GetById(((SupplierModel)_view.ListDataGrid.SelectedItem).id);

            var view = new SupplierEntryView(false, model);
            view.OnSaveData += SupplierEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void SupplierEntryView_OnSaveData(object sender, EventArgs<ISupplierModel> e)
      {
         try
         {
            var model = (SupplierModel)e.Value;
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
         if (_view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            try
            {
               var model = _services.GetById(((SupplierModel)_view.ListDataGrid.SelectedItem).id);

               _services.Delete(model);
               Messages.InfoDelete(_typeName);
               _view_OnRefreshData(null, null);
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

      private void _view_OnRefreshData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _bindingView.DataSource = _services.GetAll().ToList();
         }
      }

      private void ListDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(null, null);
      }
   }
}
