using Equin.ApplicationFramework;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian;
using RumahScarlett.Presentation.Views.Pembelian;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Pembelian
{
   public class PembelianPresenter : IPembelianPresenter
   {
      private IPembelianView _view;
      private IPembelianServices _pembelianServices;
      private IBarangServices _barangServices;
      private List<PembelianDetailModel> _listsPembelianDetails;
      private List<BarangModel> _listsBarangs;
      private BindingListView<PembelianDetailModel> _bindingView;

      public IPembelianView GetView
      {
         get { return _view; }
      }

      public PembelianPresenter()
      {
         _view = new PembelianView();
         _pembelianServices = new PembelianServices(new PembelianRepository(), new ModelDataAnnotationCheck());
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());
         _listsBarangs = _barangServices.GetAll().Where(b => b.hpp > 0).Cast<BarangModel>().ToList();

         _view.OnLoadData += _view_OnLoadData;
         _view.OnTambahData += _view_OnTambahData;
         _view.OnHapusData += _view_OnHapusData;
         _view.OnSimpanData += _view_OnSimpanData1;
         _view.OnSimpanData += _view_OnSimpanData;
         _view.OnBersihkanData += _view_OnBersihkanData;
      }
      
      private void _view_OnLoadData(object sender, EventArgs e)
      {
         _listsPembelianDetails = new List<PembelianDetailModel>();
         _bindingView = new BindingListView<PembelianDetailModel>(_listsPembelianDetails);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnTambahData(object sender, EventArgs e)
      {
         var view = new CariBarangPembelianView(_listsBarangs);
         view.ShowDialog();
      }

      private void _view_OnHapusData(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnSimpanData1(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnSimpanData(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnBersihkanData(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }
   }
}
