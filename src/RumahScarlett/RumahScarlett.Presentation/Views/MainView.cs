using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Presenters.Barang;
using RumahScarlett.Presentation.Presenters.Pelanggan;
using RumahScarlett.Presentation.Presenters.Satuan;
using RumahScarlett.Presentation.Presenters.Supplier;
using RumahScarlett.Presentation.Presenters.Tipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RumahScarlett.Presentation.Views
{
   public partial class MainView : DockContent, IMainView
   {
      private DockPanel _dockPanel;

      public MainView()
      {
         InitializeComponent();

         _dockPanel = new DockPanel();
         _dockPanel.Parent = this;
         _dockPanel.Dock = DockStyle.Fill;
         _dockPanel.BackgroundImageLayout = ImageLayout.Stretch;
         _dockPanel.BringToFront();
         _dockPanel.DocumentTabStripLocation = DocumentTabStripLocation.Top;
         _dockPanel.AllowEndUserDocking = false;
         _dockPanel.AllowEndUserNestedDocking = false;
         _dockPanel.ShowDocumentIcon = false;
         //_dockPanel.Theme = new VS2015LightTheme();
         _dockPanel.DockBackColor = Color.Transparent;
      }
      
      private void tipeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var view = (DockContent)new TipePresenter().GetView;
         ShowChildForm(view);
      }
      
      private void subTipeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var view = (DockContent)new SubTipePresenter().GetView;
         ShowChildForm(view);
      }

      private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var view = (DockContent)new SupplierPresenter().GetView;
         ShowChildForm(view);
      }
      
      private void supplierToolStripButton_Click(object sender, EventArgs e)
      {
         supplierToolStripMenuItem_Click(sender, e);
      }

      private void barangToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var view = (DockContent)new BarangPresenter().GetView;
         ShowChildForm(view);
      }

      private void satuanToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var view = (DockContent)new SatuanPresenter().GetView;
         ShowChildForm(view);
      }

      private void barangToolStripButton_Click(object sender, EventArgs e)
      {
         barangToolStripMenuItem_Click(sender, e);
      }

      private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var view = (DockContent)new PelangganPresenter().GetView;
         ShowChildForm(view);
      }

      /// <summary>
      /// Method untuk menampilkan Form child
      /// </summary>
      /// <param name="form">Form child</param>
      private void ShowChildForm(DockContent form)
      {
         using (new WaitCursorHandler())
         {
            // List form yang active
            var formList = MdiChildren;

            // Cek jika form belum ada di list, maka buka form baru,
            // sebaliknya aktifkan form jika sudah ada.
            if (!formList.Any(frm => frm.Name == form.Name))
            {
               form.Owner = this;
               form.Show(_dockPanel, DockState.Document);
            }
            else
            {
               var activeForm = formList.Where(frm => frm.Name == form.Name)
                                .FirstOrDefault();
               activeForm.Activate();
            }
         }
      }
   }
}
