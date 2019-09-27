using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views.Pembelian;
using RumahScarlett.Domain.Models.Pembelian;
using Equin.ApplicationFramework;
using RumahScarlett.Services.Services.Pembelian;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian;
using System.Windows.Forms;
using RumahScarlett.CommonComponents;
using Syncfusion.WinForms.DataGrid.Events;
using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Presentation.Presenters.Pembelian
{
   public class PembelianReturnPresenter : IPembelianReturnPresenter
   {
      private bool _successSave = false;
      private IReturnPembelianView _view;
      private BindingListView<PembelianReturnDetailModel> _bindingView;
      private List<PembelianReturnDetailModel> _listPembelianReturnDetails;
      private IPembelianReturnServices _pembelianReturnServices;
      private IPembelianReturnModel _pembelianReturnModel;
      private IPembelianServices _pembelianServices;
      private IPembelianModel _pembelianModel;

      public IReturnPembelianView GetView
      {
         get { return _view; }
      }

      public PembelianReturnPresenter()
      {
         _view = new ReturnPembelianView();
         _pembelianServices = new PembelianServices(new PembelianRepository(), new ModelDataAnnotationCheck());
         _pembelianReturnServices = new PembelianReturnServices(new PembelianReturnRepository(), new ModelDataAnnotationCheck());

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
         _listPembelianReturnDetails = new List<PembelianReturnDetailModel>();
         _bindingView = new BindingListView<PembelianReturnDetailModel>(_listPembelianReturnDetails);
         _view.ListDataGrid.DataSource = _bindingView;
         _bindingView.ListChanged += _bindingView_ListChanged;

         _view.LabelQtyReturn.Text = 0.ToString("N0");
         _view.LabelTotalReturn.Text = 0.ToString("C");
      }


      private void _bindingView_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
      {
         _view.LabelQtyReturn.Text = _bindingView.Cast<IPembelianReturnDetailModel>().Sum(pr => pr.qty).ToString("N0");
         _view.LabelTotalReturn.Text = _bindingView.Cast<IPembelianReturnDetailModel>().Sum(pr => pr.sub_total).ToString("C");
      }
      
      private void _view_OnButtonCariClick(object sender, EventArgs e)
      {
         var noNota = _view.TextBoxCariNoNota.Text;

         if (!string.IsNullOrWhiteSpace(noNota))
         {
            using (new WaitCursorHandler())
            {
               _pembelianModel = _pembelianServices.GetByNoNota(noNota);

               if (_pembelianModel != null)
               {
                  _view.TextBoxCariNoNota.Enabled = false;
                  ((Button)sender).Enabled = false; // buttonCari

                  _view.LabelTanggalPembelian.Text = _pembelianModel.tanggal.ToShortDateString();
                  _view.LabelSupplierPembelian.Text = _pembelianModel.Supplier.nama;
                  _view.LabelSubTotalPembelian.Text = _pembelianModel.sub_total.ToString("C");
                  _view.LabelDiskonPembelian.Text = _pembelianModel.diskon.ToString("C");
                  _view.LabelTotalPembelian.Text = _pembelianModel.grand_total.ToString("C");
               }
               else
               {
                  Messages.Warning($"Data pembelian dengan No Nota '{noNota}' tidak ditemukan.");
                  _view.TextBoxCariNoNota.Focus();
               }
            }
         }
      }

      private void _view_OnButtonTambahClick(object sender, EventArgs e)
      {
         if (!_successSave && _pembelianModel != null && _pembelianModel.id != default(uint))
         {
            var returnPembelianEntryView = new ReturnPembelianEntryView(_pembelianModel.PembelianDetails.Where(pd => pd.qty_return < pd.qty));
            returnPembelianEntryView.OnButtonOkClick += ReturnPembelianEntryView_OnButtonOkClick;
            returnPembelianEntryView.ShowDialog();
         }
      }

      private void ReturnPembelianEntryView_OnButtonOkClick(object sender, ReturnPembelianEventArgs e)
      {
         _listPembelianReturnDetails.Add(new PembelianReturnDetailModel
         {
            Barang = e.Barang,
            qty = e.Qty,
            status = e.Status,
            keterangan = e.Keterangan
         });

         var barangModel = _pembelianModel.PembelianDetails.Where(pd => pd.barang_id == e.Barang.id).FirstOrDefault();

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
            var itemSelected = (PembelianReturnDetailModel)_view.ListDataGrid.SelectedItem;

            var barangModel = _pembelianModel.PembelianDetails.Where(pd => pd.barang_id == itemSelected.Barang.id).FirstOrDefault();

            if (barangModel != null)
            {
               barangModel.qty_return -= itemSelected.qty;
            }

            if (_listPembelianReturnDetails.Remove(itemSelected))
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
               if (_listPembelianReturnDetails.ToList().Count > 0 && Messages.Confirm("Simpan data return pembelian?"))
               {
                  _pembelianReturnModel = new PembelianReturnModel();
                  _pembelianReturnModel.Pembelian = _pembelianModel;
                  _pembelianReturnModel.PembelianReturnDetails = _listPembelianReturnDetails;

                  _pembelianReturnServices.Insert(_pembelianReturnModel);

                  _view.TextBoxNoNotaReturn.Text = _pembelianReturnModel.no_nota;
                  _successSave = true;
                  Messages.Info("Data return pembelian berhasil disimpan.");

                  if (Messages.Confirm("Cetak Nota Return Pembelian?"))
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

         _pembelianModel = null;
         _pembelianReturnModel = null;
         _listPembelianReturnDetails.Clear();
         _bindingView.Refresh();

         _view.TextBoxCariNoNota.Clear();
         _view.TextBoxCariNoNota.Enabled = true;
         _view.ButtonCari.Enabled = true;

         _view.LabelTanggalPembelian.Text = "-";
         _view.LabelSupplierPembelian.Text = "-";
         _view.LabelSubTotalPembelian.Text = "-";
         _view.LabelDiskonPembelian.Text = "-";
         _view.LabelTotalPembelian.Text = "-";

         _view.TextBoxNoNotaReturn.Clear();
      }

      private void _view_OnButtonCetakNotaClick(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            //if (_successSave)
            //{
            //   ReportHelper.ShowNotaReturnPembelian(_pembelianReturnModel);
            //}
         }
      }
   }
}
