using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Penjualan;
using RumahScarlett.Domain.Models.Penjualan;
using Equin.ApplicationFramework;
using RumahScarlett.Services.Services.Penjualan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan;
using System.Windows.Forms;
using RumahScarlett.CommonComponents;
using Syncfusion.WinForms.DataGrid.Events;
using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Presentation.Presenters.Penjualan
{
   public class PenjualanReturnPresenter : IPenjualanReturnPresenter
   {
      private bool _successSave = false;
      private IReturnPenjualanView _view;
      private BindingListView<PenjualanReturnDetailModel> _bindingView;
      private List<PenjualanReturnDetailModel> _listPenjualanReturnDetails;
      private IPenjualanReturnServices _penjualanReturnServices;
      private IPenjualanReturnModel _penjualanReturnModel;
      private IPenjualanServices _penjualanServices;
      private IPenjualanModel _penjualanModel;

      public IReturnPenjualanView GetView
      {
         get { return _view; }
      }

      public PenjualanReturnPresenter()
      {
         _view = new ReturnPenjualanView();
         _penjualanServices = new PenjualanServices(new PenjualanRepository(), new ModelDataAnnotationCheck());
         _penjualanReturnServices = new PenjualanReturnServices(new PenjualanReturnRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadView += _view_OnLoadView;
         _view.OnButtonCariClick += _view_OnButtonCariClick;
         _view.OnButtonTambahClick += _view_OnButtonTambahClick;
         _view.OnButtonHapusClick += _view_OnButtonHapusClick;
         _view.OnButtonSimpanClick += _view_OnButtonSimpanClick;
         _view.OnButtonBersihkanClick += _view_OnButtonBersihkanClick;
         _view.OnButtonCetakNotaClick += _view_OnButtonCetakNotaClick;
      }

      private void _view_OnLoadView(object sender, EventArgs e)
      {
         _listPenjualanReturnDetails = new List<PenjualanReturnDetailModel>();
         _bindingView = new BindingListView<PenjualanReturnDetailModel>(_listPenjualanReturnDetails);
         _view.ListDataGrid.DataSource = _bindingView;
         _bindingView.ListChanged += _bindingView_ListChanged;

         _view.LabelQtyReturn.Text = 0.ToString("N0");
         _view.LabelTotalReturn.Text = 0.ToString("C");
      }


      private void _bindingView_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
      {
         _view.LabelQtyReturn.Text = _bindingView.Cast<IPenjualanReturnDetailModel>().Sum(pr => pr.qty).ToString("N0");
         _view.LabelTotalReturn.Text = _bindingView.Cast<IPenjualanReturnDetailModel>().Sum(pr => pr.sub_total).ToString("C");
      }
      
      private void _view_OnButtonCariClick(object sender, EventArgs e)
      {
         var noNota = _view.TextBoxCariNoNota.Text;

         if (!string.IsNullOrWhiteSpace(noNota))
         {
            using (new WaitCursorHandler())
            {
               _penjualanModel = _penjualanServices.GetByNoNota(noNota);

               if (_penjualanModel != null)
               {
                  _view.TextBoxCariNoNota.Enabled = false;
                  ((Button)sender).Enabled = false; // buttonCari

                  _view.LabelTanggalPenjualan.Text = _penjualanModel.tanggal.ToShortDateString();
                  _view.LabelPelangganPenjualan.Text = !string.IsNullOrWhiteSpace(_penjualanModel.pelanggan_nama) ?
                                                       _penjualanModel.pelanggan_nama : "-";
                  _view.LabelSubTotalPenjualan.Text = _penjualanModel.sub_total.ToString("C");
                  _view.LabelDiskonPenjualan.Text = _penjualanModel.diskon.ToString("C");
                  _view.LabelTotalPenjualan.Text = _penjualanModel.grand_total.ToString("C");
                  _view.LabelDibayarPenjualan.Text = _penjualanModel.jumlah_bayar.ToString("C");
                  _view.LabelKembaliPenjualan.Text = _penjualanModel.kembali.ToString("C");
               }
               else
               {
                  Messages.Warning($"Data penjualan dengan No Nota '{noNota}' tidak ditemukan.");
                  _view.TextBoxCariNoNota.Focus();
               }
            }
         }
      }

      private void _view_OnButtonTambahClick(object sender, EventArgs e)
      {
         if (!_successSave && _penjualanModel != null && _penjualanModel.id != default(uint))
         {
            var returnPenjualanEntryView = new ReturnPenjualanEntryView(_penjualanModel.PenjualanDetails.Where(pd => pd.qty_return < pd.qty));
            returnPenjualanEntryView.OnButtonOkClick += ReturnPenjualanEntryView_OnButtonOkClick;
            returnPenjualanEntryView.ShowDialog();
         }
      }

      private void ReturnPenjualanEntryView_OnButtonOkClick(object sender, ReturnPenjualanEventArgs e)
      {
         _listPenjualanReturnDetails.Add(new PenjualanReturnDetailModel
         {
            Barang = e.Barang,
            qty = e.Qty,
            status = e.Status,
            keterangan = e.Keterangan
         });

         var barangModel = _penjualanModel.PenjualanDetails.Where(pd => pd.barang_id == e.Barang.id).FirstOrDefault();

         if (barangModel != null)
         {
            barangModel.qty_return += e.Qty;
         }

         _bindingView.Refresh();
      }

      private void _view_OnButtonHapusClick(object sender, EventArgs e)
      {
         if (!_successSave && _view.ListDataGrid.SelectedItem != null)
         {
            var itemSelected = (PenjualanReturnDetailModel)_view.ListDataGrid.SelectedItem;

            var barangModel = _penjualanModel.PenjualanDetails.Where(pd => pd.barang_id == itemSelected.Barang.id).FirstOrDefault();

            if (barangModel != null)
            {
               barangModel.qty_return -= itemSelected.qty;
            }

            if (_listPenjualanReturnDetails.Remove(itemSelected))
            {
               _bindingView.Refresh();
               _view.ListDataGrid.SelectedItem = null;
            }
         }
      }

      private void _view_OnButtonSimpanClick(object sender, EventArgs e)
      {
         try
         {
            using (new WaitCursorHandler())
            {
               if (_listPenjualanReturnDetails.ToList().Count > 0 && Messages.Confirm("Simpan data return penjualan?"))
               {
                  _penjualanReturnModel = new PenjualanReturnModel();
                  _penjualanReturnModel.Penjualan = _penjualanModel;
                  _penjualanReturnModel.PenjualanReturnDetails = _listPenjualanReturnDetails;

                  _penjualanReturnServices.Insert(_penjualanReturnModel);

                  _view.TextBoxNoNotaReturn.Text = _penjualanReturnModel.no_nota;
                  _successSave = true;
                  Messages.Info("Data return penjualan berhasil disimpan.");

                  if (Messages.Confirm("Cetak Nota Return Penjualan?"))
                  {
                     _view_OnButtonCetakNotaClick(null, null);
                  }
               }
            }
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
      }

      private void _view_OnButtonBersihkanClick(object sender, EventArgs e)
      {
         _successSave = false;

         _penjualanModel = null;
         _penjualanReturnModel = null;
         _listPenjualanReturnDetails.Clear();
         _bindingView.Refresh();

         _view.TextBoxCariNoNota.Clear();
         _view.TextBoxCariNoNota.Enabled = true;
         _view.ButtonCari.Enabled = true;

         _view.LabelTanggalPenjualan.Text = "-";
         _view.LabelPelangganPenjualan.Text = "-";
         _view.LabelSubTotalPenjualan.Text = "-";
         _view.LabelDiskonPenjualan.Text = "-";
         _view.LabelTotalPenjualan.Text = "-";
         _view.LabelDibayarPenjualan.Text = "-";
         _view.LabelKembaliPenjualan.Text = "-";

         _view.TextBoxNoNotaReturn.Clear();
      }

      private void _view_OnButtonCetakNotaClick(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_successSave)
            {
               ReportHelper.ShowNotaReturnPenjualan(_penjualanReturnModel);
            }
         }
      }
   }
}
