﻿using Equin.ApplicationFramework;
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
      IHutangOperasionalView _view;
      IHutangOperasionalServices _services;
      private List<IHutangOperasionalModel> _listObjs;
      private BindingListView<HutangOperasionalModel> _bindingView;
      private static string _typeName = "Hutang Operasional";

      private ListDataGrid _view_listDataGrid;
      private Label _view_labelTotal;
      private Label _view_labelBelumLunas;
      private Label _view_labelLunas;

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
         _view_listDataGrid = (ListDataGrid)((EventArgs<Dictionary<string, Control>>)e).Value["listDataGrid"];
         _view_labelTotal = (Label)((EventArgs<Dictionary<string, Control>>)e).Value["labelTotal"];
         _view_labelLunas = (Label)((EventArgs<Dictionary<string, Control>>)e).Value["labelLunas"];
         _view_labelBelumLunas = (Label)((EventArgs<Dictionary<string, Control>>)e).Value["labelBelumLunas"];

         if (_view_listDataGrid != null)
         {
            _listObjs = _services.GetAll().ToList();
            _bindingView = new BindingListView<HutangOperasionalModel>(_listObjs);
            _view_listDataGrid.DataSource = _bindingView;
            _bindingView.ListChanged += _bindingView_ListChanged;

            HitungTotal();
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

         _view_labelTotal.Text = total.ToString("N0");
         _view_labelLunas.Text = totalLunas.ToString("N0");
         _view_labelBelumLunas.Text = totalSelisih >= 0 ? totalSelisih.ToString("N0") : "0";
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new HutangOperasionalEntryView();
         view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
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
            listDataGrid = _view_listDataGrid;
         }

         if (listDataGrid != null && listDataGrid.SelectedItem != null)
         {
            var model = _services.GetById(((HutangOperasionalModel)listDataGrid.SelectedItem).id);

            var view = new HutangOperasionalEntryView(false, model);
            view.OnSaveData += HutangOperasionalEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void HutangOperasionalEntryView_OnSaveData(object sender, EventArgs e)
      {
         try
         {
            var model = (HutangOperasionalModel)((EventArgs<IHutangOperasionalModel>)e).Value;
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

      private void _view_OnDeleteData(object sender, EventArgs e)
      {
         if (_view_listDataGrid != null && _view_listDataGrid.SelectedItem != null && Messages.ConfirmDelete(_typeName))
         {
            try
            {
               var model = _services.GetById(((HutangOperasionalModel)_view_listDataGrid.SelectedItem).id);

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
               if (_view_listDataGrid.SelectedItem != null)
               {
                  _view_listDataGrid.SelectedItem = null;
               }
            }
         }
      }

      private void _view_OnRefreshData(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            _listObjs = _services.GetAll().ToList();
            _bindingView.DataSource = _listObjs;
         }
      }

      private void OnDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(sender, e);
      }
   }
}
