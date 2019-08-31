using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Tipe;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Tipe
{
   public class SubTipePresenter : ISubTipePresenter
   {
      private ISubTipeView _view;
      private ITipeServices _services;
      private List<ITipeModel> _listTipes;
      private List<ISubTipeModel> _listSubTipes;
      private BindingListView<SubTipeModel> _bindingView;
      private static string _typeName = "Sub Tipe";

      public ISubTipeView GetView
      {
         get { return _view; }
      }

      public SubTipePresenter()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _view = new SubTipeView();

         _view.OnLoadData += _view_LoadData;
         _view.OnCreateData += _view_OnCreateData;
         _view.OnUpdateData += _view_OnUpdateData;
         _view.OnDeleteData += _view_OnDeleteData;
         _view.OnRefreshData += _view_OnRefreshData;

         _view.TreeViewTipe.AfterSelect += TreeViewTipe_AfterSelect;
         _view.ListDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
      }

      private void _view_LoadData(object sender, EventArgs e)
      {
         _listTipes = _services.GetAll().ToList();
         _listSubTipes = _services.GetAllSubTipe().ToList();

         SetTipeNodes(_listTipes);

         _bindingView = new BindingListView<SubTipeModel>(_listSubTipes);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new SubTipeEntryView(_listTipes);
         view.OnSaveData += SubTipeEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null)
         {
            var model = _services.GetSubTipeById(((SubTipeModel)_view.ListDataGrid.SelectedItem).id);

            var view = new SubTipeEntryView(_listTipes, false, model);
            view.OnSaveData += SubTipeEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void SubTipeEntryView_OnSaveData(object sender, EventArgs<ISubTipeModel> e)
      {
         try
         {
            var model = (SubTipeModel)e.Value;
            var view = ((SubTipeEntryView)sender);

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
               var model = _services.GetSubTipeById(((SubTipeModel)_view.ListDataGrid.SelectedItem).id);

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
            _listTipes = _services.GetAll().ToList();
            _listSubTipes = _services.GetAllSubTipe().ToList();

            SetTipeNodes(_listTipes);
            _bindingView.DataSource = _listSubTipes;
         }
      }

      private void TreeViewTipe_AfterSelect(object sender, TreeViewEventArgs e)
      {
         if (((TreeView)sender).SelectedNode != null)
         {
            if (e.Node.Name.ToLower() != "root")
            {
               _bindingView.DataSource = _listTipes.Where(t => t.id == uint.Parse(e.Node.Name))
                                         .FirstOrDefault().SubTipes.ToList();
            }
            else
            {
               _bindingView.DataSource = _listSubTipes;
            }
         }
      }

      private void SetTipeNodes(List<ITipeModel> listTipes)
      {
         if (listTipes != null && listTipes.Count > 0)
         {
            if (_view.TreeViewTipe.Nodes.Count == 0)
            {
               _view.TreeViewTipe.Nodes.Add("root", "TIPE");
            }

            if (_view.TreeViewTipe.Nodes["root"].Nodes.Count > 0)
            {
               _view.TreeViewTipe.Nodes["root"].Nodes.Clear();
            }

            var kvpTipe = listTipes.Select(t => new KeyValuePair<uint, string>(t.id, t.nama));

            foreach (var tipe in kvpTipe)
            {
               // Key = Key
               // Text = Value
               _view.TreeViewTipe.Nodes["root"].Nodes.Add(tipe.Key.ToString(), tipe.Value);
            }

            if (!_view.TreeViewTipe.Nodes["root"].IsExpanded)
            {
               _view.TreeViewTipe.Nodes["root"].Toggle();
            }
         }
      }

      private void ListDataGrid_CellDoubleClick(object sender, EventArgs e)
      {
         _view_OnUpdateData(this, null);
      }
   }
}
