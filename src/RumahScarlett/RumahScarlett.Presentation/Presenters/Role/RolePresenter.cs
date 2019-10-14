using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Role;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Role;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Role;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Role;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Role
{
   public class RolePresenter : IRolePresenter
   {
      private IRoleView _view;
      private IRoleServices _services;
      private List<IRoleModel> _listObjs;
      private BindingListView<RoleModel> _bindingView;
      private static string _typeName = "Role";

      public IRoleView GetView
      {
         get { return _view; }
      }

      public RolePresenter()
      {
         _view = new RoleView();
         _services = new RoleServices(new RoleRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_LoadData;
         _view.OnButtonTambahClick += _view_OnCreateData;
         _view.OnButtonUbahClick += _view_OnUpdateData;
         _view.OnButtonHapusClick += _view_OnDeleteData;
         _view.OnButtonRefreshClick += _view_OnRefreshData;

         _view.OnDataGridCellDoubleClick += OnDataGrid_CellDoubleClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null)
            {
               _listObjs = _services.GetAll().ToList();
               _bindingView = new BindingListView<RoleModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;
            }
         }
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         //var view = new RoleEntryView();
         //view.OnSaveData += RoleEntryView_OnSaveData;
         //view.ShowDialog();
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
               var model = _services.GetById(((RoleModel)listDataGrid.SelectedItem).id);

               if (model != null)
               {
                  //var view = new RoleEntryView(false, model);
                  //view.OnSaveData += RoleEntryView_OnSaveData;
                  //view.ShowDialog();
               }
            }
         }
      }

      private void RoleEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               //var listDataGrid = _view.ListDataGrid;
               //var newModel = ((ModelEventArgs<RoleModel>)e).Value;
               //var view = ((RoleEntryView)sender);

               //if (newModel.id == default(uint))
               //{
               //   _services.Insert(newModel);
               //   view.Controls.ClearControls();
               //   Messages.InfoSave(_typeName);

               //   _listObjs.Add(newModel);
               //   _bindingView.DataSource = _listObjs;

               //   if (listDataGrid.SelectedItem != null)
               //   {
               //      listDataGrid.SelectedItem = null;
               //   }

               //   listDataGrid.SelectedItem = newModel;
               //}
               //else
               //{
               //   _services.Update(newModel);
               //   Messages.InfoUpdate(_typeName);
               //   view.Close();

               //   var model = _bindingView.Where(b => b.id == newModel.id).FirstOrDefault();

               //   if (model != null)
               //   {
               //      model.login_id = newModel.login_id;
               //      model.role_kode = newModel.role_kode;

               //      _bindingView.Refresh();
               //   }
               //}
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
                  var model = _services.GetById(((RoleModel)_view.ListDataGrid.SelectedItem).id);

                  _services.Delete(model);
                  Messages.InfoDelete(_typeName);

                  if (_listObjs.Remove((RoleModel)_view.ListDataGrid.SelectedItem))
                  {
                     _bindingView.DataSource = _listObjs;
                  }
               }
               catch (DataAccessException ex)
               {
                  Messages.Error(ex);
                  _view_OnRefreshData(null, null);
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
