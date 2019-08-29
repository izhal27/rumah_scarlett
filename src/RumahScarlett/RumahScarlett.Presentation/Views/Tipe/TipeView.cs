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

      public TipeView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "TIPE";
         buttonsCRUD.ButtonCetakVisible = false;

         buttonsCRUD.OnTutupClickEvent += ButtonsCRUD_OnTutupClickEvent;

         buttonsCRUD.OnRefreshClickEvent += ButtonsCRUD_OnRefreshClickEvent;
      }

      private void TipeView_Load(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnLoadDataEvent, e);
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
