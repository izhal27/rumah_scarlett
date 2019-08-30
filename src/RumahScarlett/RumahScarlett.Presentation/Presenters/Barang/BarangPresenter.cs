using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Barang;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.Tipe;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Barang
{
   class BarangPresenter : IBarangPresenter
   {
      private IBarangView _view;
      private IBarangServices _barangServices;
      private ITipeServices _tipeServices;
      private List<IBarangModel> _listBarangs;
      private List<ITipeModel> _listTipes;
      private BindingListView<BarangModel> _bindingView;
      private static string _typeName = "Barang";

      public IBarangView GetView
      {
         get { return _view; }
      }

      public BarangPresenter()
      {
         _view = new BarangView();
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());
         _tipeServices = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());

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
         _listBarangs = _barangServices.GetAll().ToList();
         _listTipes = _tipeServices.GetAll().ToList();

         SetTipeNodes(_listTipes);

         _bindingView = new BindingListView<BarangModel>(_listBarangs);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnCreateData(object sender, EventArgs e)
      {
         var view = new BarangEntryView(_tipeServices);
         view.OnSaveData += BarangEntryView_OnSaveData;
         view.ShowDialog();
      }

      private void _view_OnUpdateData(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.SelectedItem != null)
         {
            var model = _barangServices.GetById(((BarangModel)_view.ListDataGrid.SelectedItem).id);

            var view = new BarangEntryView(_tipeServices, false, model);
            view.OnSaveData += BarangEntryView_OnSaveData;
            view.ShowDialog();
         }
      }

      private void BarangEntryView_OnSaveData(object sender, ModelEventArgs e)
      {
         try
         {
            var model = (BarangModel)e.Model;
            var view = ((BarangEntryView)sender);

            if (model.id == default(uint))
            {
               _barangServices.Insert(model);
               view.Controls.ClearControls();
               Messages.InfoSave(_typeName);
            }
            else
            {
               _barangServices.Update(model);
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
               var model = _barangServices.GetById(((BarangModel)_view.ListDataGrid.SelectedItem).id);

               _barangServices.Delete(model);
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
            _listTipes = _tipeServices.GetAll().ToList();
            SetTipeNodes(_listTipes);

            _listBarangs = _barangServices.GetAll().ToList();
            _bindingView.DataSource = _listBarangs;
         }
      }

      private void TreeViewTipe_AfterSelect(object sender, TreeViewEventArgs e)
      {
         var treeView = ((TreeView)sender);

         if (treeView.SelectedNode != null)
         {
            var selectedNode = treeView.SelectedNode;

            if (selectedNode.Name.ToLower() != "root")
            {
               List<IBarangModel> listBarang = new List<IBarangModel>();

               if (selectedNode.Parent.Name == "root") // Tipe
               {
                  listBarang = _listBarangs.Where(b => b.tipe_id == uint.Parse(selectedNode.Name)).ToList();
               }
               else
               {
                  listBarang = _listBarangs.Where(b => b.sub_tipe_id == uint.Parse(selectedNode.Name)).ToList();
               }

               _bindingView.DataSource = listBarang;
            }
            else
            {
               _bindingView.DataSource = _listBarangs;
            }
         }
      }

      private void SetTipeNodes(List<ITipeModel> listTipes)
      {
         if (listTipes != null && listTipes.Count > 0)
         {
            if (_view.TreeViewTipe.Nodes.Count == 0)
            {
               _view.TreeViewTipe.Nodes.Add("root", "SEMUA BARANG");
            }

            if (_view.TreeViewTipe.Nodes["root"].Nodes.Count > 0)
            {
               _view.TreeViewTipe.Nodes["root"].Nodes.Clear();
            }

            foreach (var tipe in _listTipes)
            {
               var tipeNode = new TreeNode { Name = tipe.id.ToString(), Text = tipe.nama };

               foreach (var subTipe in tipe.SubTipes)
               {
                  var subTipeNode = new TreeNode { Name = subTipe.id.ToString(), Text = subTipe.nama };

                  tipeNode.Nodes.Add(subTipeNode);
               }

               _view.TreeViewTipe.Nodes["root"].Nodes.Add(tipeNode);
            }

            if (!_view.TreeViewTipe.Nodes["root"].IsExpanded)
            {
               _view.TreeViewTipe.Nodes["root"].ExpandAll();
            }
            else
            {
               _view.TreeViewTipe.Nodes["root"].ExpandAll();
            }
         }
      }

      private void ListDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         _view_OnUpdateData(null, null);
      }
   }
}
