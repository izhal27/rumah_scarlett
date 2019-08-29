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
   public partial class TipeView : BaseDataView, ITipeView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnCreateData;
      public event EventHandler OnUpdateData;
      public event EventHandler OnDeleteData;
      public event EventHandler OnRefreshData;
      public event EventHandler OnPrintData;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public TipeView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "TIPE";
         buttonsCRUD.ButtonCetakVisible = false;

         buttonsCRUD.OnTambahClick += ButtonsCRUD_OnTambahClick;
         buttonsCRUD.OnUbahClick += ButtonsCRUD_OnUbahClick;
         buttonsCRUD.OnHapusClick += ButtonsCRUD_OnHapusClick;
         buttonsCRUD.OnRefreshClick += ButtonsCRUD_OnRefreshClickEvent;
         buttonsCRUD.OnTutupClick += ButtonsCRUD_OnTutupClickEvent;
      }

      private void TipeView_Load(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnLoadData, e);
      }

      private void ButtonsCRUD_OnTambahClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCreateData, null);
      }

      private void ButtonsCRUD_OnUbahClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnUpdateData, null);
      }

      private void ButtonsCRUD_OnHapusClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnDeleteData, null);
      }

      private void ButtonsCRUD_OnRefreshClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnRefreshData, e);
      }

      private void ButtonsCRUD_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
