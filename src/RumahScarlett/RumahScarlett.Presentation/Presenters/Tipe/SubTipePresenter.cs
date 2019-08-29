using Equin.ApplicationFramework;
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

      public ISubTipeView GetView
      {
         get { return _view; }
      }

      public SubTipePresenter()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _view = new SubTipeView();

         _listTipes = _services.GetAll().ToList();
         _listSubTipes = _services.GetAllSubTipe().ToList();

         _view.OnLoadData += _view_LoadDataEvent;
         _view.OnCreateData += _view_OnCreateDataEvent;
         _view.OnUpdateData += _view_OnUpdateDataEvent;
         _view.OnDeleteData += _view_OnDeleteDataEvent;
         _view.OnRefreshData += _view_OnRefreshDataEvent;

         _view.TreeViewTipe.AfterSelect += TreeViewTipe_AfterSelect;
         _view.ListDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
      }

      private void _view_LoadDataEvent(object sender, EventArgs e)
      {
         SetTipeNodes(_listTipes);
         
         _bindingView = new BindingListView<SubTipeModel>(_listSubTipes);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateDataEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnUpdateDataEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnDeleteDataEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnRefreshDataEvent(object sender, EventArgs e)
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
         _view_OnUpdateDataEvent(this, null);
      }
   }
}
