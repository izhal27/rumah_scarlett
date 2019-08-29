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

namespace RumahScarlett.Presentation.Views.Supplier
{
   public partial class SupplierView : BaseDataView, ISupplierView
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

      public SupplierView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "DATA SUPPLIER";
         crudcButtons.ButtonCetakVisible = false;

         crudcButtons.OnTambahClick += crudcButtons_OnTambahClick;
         crudcButtons.OnUbahClick += crudcButtons_OnUbahClick;
         crudcButtons.OnHapusClick += crudcButtons_OnHapusClick;
         crudcButtons.OnRefreshClick += crudcButtons_OnRefreshClickEvent;
         crudcButtons.OnTutupClick += crudcButtons_OnTutupClickEvent;
      }

      private void SupplierView_Load(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnLoadData, e);
      }

      private void crudcButtons_OnTambahClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCreateData, null);
      }

      private void crudcButtons_OnUbahClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnUpdateData, null);
      }

      private void crudcButtons_OnHapusClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnDeleteData, null);
      }

      private void crudcButtons_OnRefreshClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnRefreshData, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
