using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.HutangOperasional;
using RumahScarlett.Infrastructure.DataAccess.Repositories.HutangOperasional;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.HutangOperasional;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.HutangOperasional;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.HutangOperasional
{
   public class HutangOperasionalPresenter : IHutangOperasionalPresenter
   {
      private IHutangOperasionalView _view;
      private IHutangOperasionalServices _services;
      private List<IHutangOperasionalModel> _listObjs;
      private BindingListView<HutangOperasionalModel> _bindingView;
      private static string _typeName = "Hutang Operasional";

      public IHutangOperasionalView GetView
      {
         get { return _view; }
      }

      public HutangOperasionalPresenter()
      {
         _view = new HutangOperasionalView();
         _services = new HutangOperasionalServices(new HutangOperasionalRepository(), new ModelDataAnnotationCheck());

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
               _bindingView = new BindingListView<HutangOperasionalModel>(_listObjs);
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
         var total = _listObjs.Sum(h => h.jumlah);
         var totalLunas = _listObjs.Where(h => h.status_hutang == true).Sum(h => h.jumlah);
         var totalSelisih = total - totalLunas;

         _view.LabelTotal.Text = total.ToString("N0");
         _view.LabelLunas.Text = totalLunas.ToString("N0");
         _view.LabelBelumLunas.Text = totalSelisih >= 0 ? totalSelisih.ToString("N0") : "0";
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new HutangOperasionalEntryView();
         view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
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
               var model = _services.GetById(((HutangOperasionalModel)listDataGrid.SelectedItem).id);

               var view = new HutangOperasionalEntryView(false, model);
               view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
               view.ShowDialog();
            }
         }
      }

      private void HutangOperasionalEntryView_OnSaveData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            try
            {
               var model = ((ModelEventArgs<HutangOperasionalModel>)e).Value;
               var view = ((HutangOperasionalEntryView)sender);

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
                  var model = _services.GetById(((HutangOperasionalModel)_view.ListDataGrid.SelectedItem).id);

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
