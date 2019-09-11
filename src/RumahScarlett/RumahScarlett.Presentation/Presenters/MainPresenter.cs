﻿using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Presenters.Barang;
using RumahScarlett.Presentation.Presenters.HutangOperasional;
using RumahScarlett.Presentation.Presenters.KasAwal;
using RumahScarlett.Presentation.Presenters.Laporan;
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

         _view.OnTipeViewClick += _view_OnTipeViewClick;
         _view.OnSubTipeViewClick += _view_OnSubTipeViewClick;
         _view.OnSupplierViewClick += _view_OnSupplierViewClick;
         _view.OnBarangViewClick += _view_OnBarangViewClick;
         _view.OnSatuanViewClick += _view_OnSatuanViewClick;
         _view.OnPelangganViewClick += _view_OnPelangganViewClick;
         _view.OnKasAwalViewClick += _view_OnKasAwalViewClick;
         _view.OnHutangOperasionalViewClick += _view_OnHutangOperasionalViewClick;
         _view.OnPenjualanViewClick += _view_OnPenjualanViewClick;
         _view.OnPembelianViewClick += _view_OnPembelianViewClick;
         _view.OnPengeluaranViewClick += _view_OnPengeluaranViewClick;
         _view.OnPenyesuaianStokViewClick += _view_OnPenyesuaianStokViewClick;
         _view.OnLaporanPenjualanViewClick += _view_OnLaporanPenjualanViewClick;
         _view.OnLaporanPembelianViewClick += _view_OnLaporanPembelianViewClick;
         _view.OnLaporanPengeluaranViewClick += _view_OnLaporanPengeluaranViewClick;
         _view.OnLaporanTransaksiByDateClick += _view_OnLaporanTransaksiByDateClick;
      }

      private void _view_OnTipeViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new TipePresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnSubTipeViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new SubTipePresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnSupplierViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new SupplierPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnBarangViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new BarangPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnSatuanViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new SatuanPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnPelangganViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PelangganPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnKasAwalViewClick(object sender,EventArgs e)
      {
         new KasAwalPresenter().GetView.ShowView();
      }

      private void _view_OnHutangOperasionalViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new HutangOperasionalPresenter().GetView;
         ShowChildForm(view, e);
      }
      
      private void _view_OnPenjualanViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PenjualanPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnPembelianViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PembelianPresenter().GetView;
         ShowChildForm(view, e);
      }
      
      private void _view_OnPengeluaranViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PengeluaranPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnPenyesuaianStokViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new PenyesuaianStokPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnLaporanPenjualanViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new LaporanPenjualanPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnLaporanPembelianViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new LaporanPembelianPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnLaporanPengeluaranViewClick(object sender, MainViewEventArgs e)
      {
         var view = (DockContent)new LaporanPengeluaranPresenter().GetView;
         ShowChildForm(view, e);
      }

      private void _view_OnLaporanTransaksiByDateClick(object sender, EventArgs e)
      {
         var view = (Form)new LaporanTransaksiByDatePresenter().GetView;
         view.ShowDialog();
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
