using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Tipe
{
   public partial class SubTipeView : BaseDataView, ISubTipeView
   {
      public event EventHandler OnLoadDataEvent;
      public event EventHandler OnCreateDataEvent;
      public event EventHandler OnUpdateDataEvent;
      public event EventHandler OnDeleteDataEvent;
      public event EventHandler OnRefreshDataEvent;
      public event EventHandler OnPrintDataEvent;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public TreeView TreeViewTipe
      {
         get { return treeViewTipe; }
      }

      public SubTipeView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "SUB TIPE";
         buttonsCRUD.ButtonCetakVisible = false;

         buttonsCRUD.OnTambahClick += ButtonsCRUD_OnTambahClickEvent;
         buttonsCRUD.OnUbahClick += ButtonsCRUD_OnUbahClickEvent;
         buttonsCRUD.OnHapusClick += ButtonsCRUD_OnHapusClickEvent;
         buttonsCRUD.OnRefreshClick += ButtonsCRUD_OnRefreshClickEvent;
         buttonsCRUD.OnTutupClick += ButtonsCRUD_OnTutupClickEvent;
      }

      private void SubTipeView_Load(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnLoadDataEvent, e);
      }

      private void ButtonsCRUD_OnTambahClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCreateDataEvent, e);
      }

      private void ButtonsCRUD_OnUbahClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnUpdateDataEvent, e);
      }

      private void ButtonsCRUD_OnHapusClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnDeleteDataEvent, e);
      }

      private void ButtonsCRUD_OnRefreshClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnRefreshDataEvent, e);
      }

      private void ButtonsCRUD_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}