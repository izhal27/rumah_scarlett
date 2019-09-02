using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pengeluaran;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pengeluaran;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Pengeluaran;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pengeluaran;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Pengeluaran
{
   public class PengeluaranPresenter : IPengeluaranPresenter
   {
      IPengeluaranView _view;
      IPengeluaranServices _services;
      private List<IPengeluaranModel> _listObjs;
      private BindingListView<PengeluaranModel> _bindingView;
      private static string _typeName = "Pengeluaran";

      public IPengeluaranView GetView
      {
         get { return _view; }
      }

      public PengeluaranPresenter()
      {
         _view = new PengeluaranView();
         _services = new PengeluaranServices(new PengeluaranRepository(), new ModelDataAnnotationCheck());

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
            if (_view.ListDataGrid != null && _view.DateTimePickerTanggal != null)
            {
               _listObjs = _services.GetByDate(_view.DateTimePickerTanggal.Value.Date).ToList();
               _bindingView = new BindingListView<PengeluaranModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;
               _view.LabelTotal.Text = _listObjs.Sum(p => p.jumlah).ToString("N0");
            }
         }
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         if (_view.DateTimePickerTanggal != null)
         {
            var view = new PengeluaranEntryView(_view.DateTimePickerTanggal);
            view.OnSaveData += PengeluaranEntryView_OnSaveData;
            view.ShowDialog();
         }
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
               var model = _services.GetById(((PengeluaranModel)listDataGrid.SelectedItem).id);

               var view = new PengeluaranEntryView(_view.DateTimePickerTanggal, false, model);
               view.OnSaveData += PengeluaranEntryView_OnSaveData;
               view.ShowDialog();
            }
         }
      }

      private void PengeluaranEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var model = (PengeluaranModel)((EventArgs<IPengeluaranModel>)e).Value;
               var view = ((PengeluaranEntryView)sender);

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
                  var model = _services.GetById(((PengeluaranModel)_view.ListDataGrid.SelectedItem).id);

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
         _listObjs = _services.GetByDate(_view.DateTimePickerTanggal.Value.Date).ToList();
         _bindingView.DataSource = _listObjs;
         _view.LabelTotal.Text = _listObjs.Sum(p => p.jumlah).ToString("N0");
      }

      private void OnDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }
   }
}
