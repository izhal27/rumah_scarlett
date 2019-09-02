using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pelanggan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Pelanggan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pelanggan;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Pelanggan
{
   public class PelangganPresenter : IPelangganPresenter
   {
      private IPelangganView _view;
      private IPelangganServices _services;
      private List<IPelangganModel> _listObjs;
      private BindingListView<PelangganModel> _bindingView;
      private static string _typeName = "Pelanggan";

      public IPelangganView GetView
      {
         get { return _view; }
      }

      public PelangganPresenter()
      {
         _view = new PelangganView();
         _services = new PelangganServices(new PelangganRepository(), new ModelDataAnnotationCheck());

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
               _bindingView = new BindingListView<PelangganModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;
            }
         }
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new PelangganEntryView();
         view.OnSaveData += PelangganEntryView_OnSaveData;
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
            var model = _services.GetById(((PelangganModel)listDataGrid.SelectedItem).id);

            var view = new PelangganEntryView(false, model);
            view.OnSaveData += PelangganEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void PelangganEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var model = (PelangganModel)((EventArgs<IPelangganModel>)e).Value;
               var view = ((PelangganEntryView)sender);

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
      }

      private void _view_OnDeleteData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null && _view.ListDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
            {
               try
               {
                  var model = _services.GetById(((PelangganModel)_view.ListDataGrid.SelectedItem).id);

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
