using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.PenyesuaianStok;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.PenyesuaianStok;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.PenyesuaianStok
{
   public class PenyesuaianStokPresenter : IPenyesuaianStokPresenter
   {
      private IPenyesuaianStokView _view;
      private IPenyesuaianStokServices _services;
      private List<IPenyesuaianStokModel> _listObjs;
      private BindingListView<PenyesuaianStokModel> _bindingView;
      private static string _typeName = "Penyesuaian Stok";

      public IPenyesuaianStokView GetView
      {
         get { return _view; }
      }

      public PenyesuaianStokPresenter()
      {
         _view = new PenyesuaianStokView();
         _services = new PenyesuaianStokServices(new PenyesuaianStokRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_LoadData;
         _view.OnCreateData += _view_OnCreateData;
         _view.OnUpdateData += _view_OnUpdateData;
         _view.OnDeleteData += _view_OnDeleteData;
         _view.OnRefreshData += _view_OnRefreshData;

         _view.OnDataGridCellDoubleClick += OnDataGrid_CellDoubleClick;
         _view.OnTampilkanClick += _view_OnTampilkanClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.ListDataGrid != null)
            {
               _listObjs = _services.GetAll().ToList();
               _bindingView = new BindingListView<PenyesuaianStokModel>(_listObjs);
               _view.ListDataGrid.DataSource = _bindingView;
               _bindingView.ListChanged += _bindingView_ListChanged;

               HitungTotal();
            }
         }
      }

      private void _bindingView_ListChanged(object sender, ListChangedEventArgs e)
      {
         HitungTotal();
      }

      private void HitungTotal()
      {
         var totalQty = _bindingView.DataSource.Cast<IPenyesuaianStokModel>().Sum(h => h.qty);
         var totalHpp = _bindingView.DataSource.Cast<IPenyesuaianStokModel>().Sum(h => h.hpp);

         _view.LabelTotalQty.Text = totalQty.ToString("N0");
         _view.LabelTotalHpp.Text = totalHpp.ToString("N0");
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         //var view = new HutangOperasionalEntryView();
         //view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
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
               //var model = _services.GetById(((PenyesuaianStokModel)listDataGrid.SelectedItem).id);

               //var view = new HutangOperasionalEntryView(false, model);
               //view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
               //view.ShowDialog();
            }
         }
      }

      private void HutangOperasionalEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               //var model = (PenyesuaianStokModel)((EventArgs<IPenyesuaianStokModel>)e).Value;
               //var view = ((PenyesuaianStokEntryView)sender);

               //if (model.id == default(uint))
               //{
               //   _services.Insert(model);
               //   view.Controls.ClearControls();
               //   Messages.InfoSave(_typeName);
               //}
               //else
               //{
               //   _services.Update(model);
               //   Messages.InfoUpdate(_typeName);
               //   view.Close();
               //}

               //_view_OnRefreshData(null, null);
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
                  var model = _services.GetById(((PenyesuaianStokModel)_view.ListDataGrid.SelectedItem).id);

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

      private void _view_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         switch (e.TampilkanStatus)
         {
            case TampilkanStatus.Tanggal:

               _bindingView.DataSource = _listObjs.Where(ps => ps.tanggal == e.Tanggal.Date).ToList();

               break;
            case TampilkanStatus.Periode:

               _bindingView.DataSource = _listObjs.Where(ps => ps.tanggal >=e.TanggalAwal.Date &&
                                                         ps.tanggal <= e.TanggalAkhir.Date).ToList();

               break;
            default:

               _bindingView.DataSource = _listObjs;

               break;
         }
      }
   }
}
