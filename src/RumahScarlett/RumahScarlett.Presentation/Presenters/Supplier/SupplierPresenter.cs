using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
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
      private List<ISupplierModel> _listObjs;
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

         _view.OnDataGridCellDoubleClick += OnDataGrid_CellDoubleClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null)
            {
               _listObjs = _services.GetAll().ToList();
               _bindingView = new BindingListView<SupplierModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;
            }
         }
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new SupplierEntryView();
         view.OnSaveData += SupplierEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            ListDataGrid listDataGrid = null;

            if (sender is ListDataGrid)
            {
               listDataGrid = (ListDataGrid)sender;
            }
            else
            {
               listDataGrid = _view.ListDataGrid;
            }

            if (listDataGrid != null && listDataGrid.SelectedItem != null)
            {
               var model = _services.GetById(((SupplierModel)listDataGrid.SelectedItem).id);

               if (model != null)
               {
                  var view = new SupplierEntryView(false, model);
                  view.OnSaveData += SupplierEntryView_OnSaveData;
                  view.ShowDialog();
               }
            }
         }
      }

      private void SupplierEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var listDataGrid = _view.ListDataGrid;
               var newModel = ((ModelEventArgs<SupplierModel>)e).Value;
               var view = ((SupplierEntryView)sender);

               if (newModel.id == default(uint))
               {
                  _services.Insert(newModel);
                  view.Controls.ClearControls();
                  Messages.InfoSave(_typeName);

                  _listObjs.Add(newModel);
                  _bindingView.DataSource = _listObjs;

                  if (listDataGrid.SelectedItem != null)
                  {
                     listDataGrid.SelectedItem = null;
                  }

                  listDataGrid.SelectedItem = newModel;
               }
               else
               {
                  _services.Update(newModel);
                  Messages.InfoUpdate(_typeName);
                  view.Close();

                  var model = _bindingView.Where(b => b.id == newModel.id).FirstOrDefault();

                  if (model != null)
                  {
                     model.nama = newModel.nama;
                     model.alamat = newModel.alamat;
                     model.telpon = newModel.telpon;
                     model.fax = newModel.fax;
                     model.email = newModel.email;
                     model.website = newModel.website;
                     model.contact_person = newModel.contact_person;

                     _bindingView.Refresh();
                  }
               }
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
      }

      private void _view_OnDeleteData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null && _view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
            {
               try
               {
                  var model = _services.GetById(((SupplierModel)_view.ListDataGrid.SelectedItem).id);

                  _services.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listObjs.Remove((SupplierModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listObjs;
                  }
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
      }

      private void _view_OnRefreshData(object sender, EventArgs e)
      {
         _listObjs = _services.GetAll().ToList();
         _bindingView.DataSource = _listObjs;
      }

      private void OnDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }
   }
}
