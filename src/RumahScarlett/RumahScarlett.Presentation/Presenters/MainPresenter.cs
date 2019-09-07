using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Presenters.Barang;
using RumahScarlett.Presentation.Presenters.HutangOperasional;
using RumahScarlett.Presentation.Presenters.KasAwal;
using RumahScarlett.Presentation.Presenters.Pelanggan;
using RumahScarlett.Presentation.Presenters.Pembelian;
using RumahScarlett.Presentation.Presenters.Pengeluaran;
using RumahScarlett.Presentation.Presenters.Penjualan;
using RumahScarlett.Presentation.Presenters.PenyesuaianStok;
using RumahScarlett.Presentation.Presenters.Satuan;
using RumahScarlett.Presentation.Presenters.Supplier;
using RumahScarlett.Presentation.Presenters.Tipe;
using RumahScarlett.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RumahScarlett.Presentation.Presenters
{
   public class MainPresenter : IMainPresenter
   {
      private IMainView _view;

      public IMainView GetView
      {
         get { return _view; }
      }

      public MainPresenter()
      {
         _view = new MainView();

         _view.OnTipeViewOpen += _view_OnTipeViewOpen;
         _view.OnSubTipeViewOpen += _view_OnSubTipeViewOpen;
         _view.OnSupplierViewOpen += _view_OnSupplierViewOpen;
         _view.OnBarangViewOpen += _view_OnBarangViewOpen;
         _view.OnSatuanViewOpen += _view_OnSatuanViewOpen;
         _view.OnPelangganViewOpen += _view_OnPelangganViewOpen;
         _view.OnKasAwalViewOpen += _view_OnKasAwalViewOpen;
         _view.OnHutangOperasionalViewOpen += _view_OnHutangOperasionalViewOpen;

         _view.OnPenjualanViewOpen += _view_OnPenjualanViewOpen;
         _view.OnPembelianViewOpen += _view_OnPembelianViewOpen;
         _view.OnPengeluaranViewOpen += _view_OnPengeluaranViewOpen;
         _view.OnPenyesuaianStokViewOpen += _view_OnPenyesuaianStokViewOpen;
      }

      private void _view_OnTipeViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new TipePresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnSubTipeViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new SubTipePresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnSupplierViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new SupplierPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnBarangViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new BarangPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnSatuanViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new SatuanPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnPelangganViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PelangganPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnKasAwalViewOpen(object sender,EventArgs e)
      {
         new KasAwalPresenter().GetView.ShowView();
      }

      private void _view_OnHutangOperasionalViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new HutangOperasionalPresenter().GetView;
         ShowChildForm(view, e);
      }








      private void _view_OnPenjualanViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PenjualanPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnPembelianViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PembelianPresenter().GetView;
         ShowChildForm(view, e);
      }
      
      private void _view_OnPengeluaranViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PengeluaranPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnPenyesuaianStokViewOpen(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PenyesuaianStokPresenter().GetView;
         ShowChildForm(view, e);
      }






      /// <summary>
      /// Method untuk menampilkan Form child
      /// </summary>
      /// <param name="form">Form child</param>
      private void ShowChildForm(DockContent form, MainViewEventArgs e)
      {
         using (new WaitCursorHandler())
         {
            // List form yang active
            var formList = ((Form)_view).MdiChildren;

            // Cek jika form belum ada di list, maka buka form baru,
            // sebaliknya aktifkan form jika sudah ada.
            if (!formList.Any(frm => frm.Name == form.Name))
            {
               form.Owner = ((Form)_view);
               form.Show(e.DockPanel, DockState.Document);
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
