using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.ModelControls;
using RumahScarlett.Presentation.Views.Penjualan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.Penjualan;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Penjualan
{
   public class PenjualanPresenter : IPenjualanPresenter
   {

      private IPenjualanView _view;
      private IPenjualanServices _penjualannServices;
      private IBarangServices _barangServices;
      private List<PenjualanDetailModel> _listPenjualanDetails;
      private List<IBarangModel> _listsBarangs;
      private BindingListView<PenjualanDetailModel> _bindingView;
      private string _kodeOrNamaForSearching = "";

      public IPenjualanView GetView
      {
         get { return _view; }
      }

      private int CurrCellRowIndex
      {
         get { return _view.ListDataGrid.CurrentCell.RowIndex; }
      }

      private object CurrCellValue
      {
         get
         {
            return _view.ListDataGrid.CurrentCell.CellRenderer.GetControlValue();
         }
      }

      public PenjualanPresenter()
      {
         _view = new PenjualanView();
         _penjualannServices = new PenjualanServices(new PenjualanRepository(), new ModelDataAnnotationCheck());
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());
         _listsBarangs = _barangServices.GetAll().Where(b => b.harga_jual > 0).ToList();

         _view.OnLoadData += _view_OnLoadData;
         _view.OnCariData += _view_OnCariData;
         _view.OnHapusData += _view_OnHapusData;
         _view.OnSimpanData += _view_OnBayarPenjualan;
         _view.OnBersihkanData += _view_OnBersihkanData;
         _view.OnListDataGridCurrentCellKeyDown += _view_OnListDataGridCurrentCellKeyDown;
         _view.OnListDataGridCurrentCellActivated += _view_OnListDataGridCurrentCellActivated;
         _view.OnListDataGridCurrentCellEndEdit += _view_OnListDataGridCurrentCellEndEdit;
         _view.OnListDataGridPreviewKeyDown += _view_OnListDataGridPreviewKeyDown;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         ((Form)_view).ActiveControl = _view.ListDataGrid;

         _listPenjualanDetails = new List<PenjualanDetailModel>();
         AddDummyPenjualanModel(30);

         _bindingView = new BindingListView<PenjualanDetailModel>(_listPenjualanDetails);
         _bindingView.ListChanged += _bindingView_ListChanged;

         _view.ListDataGrid.DataSource = _bindingView;
         _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(1, 1));
         _view.ListDataGrid.CurrentCell.BeginEdit();
      }

      private void _bindingView_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
      {
         HitungGrandTotal();
      }

      private void _view_OnCariData(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.Enabled)
         {
            var view = new CariBarangView(_listsBarangs, TipePencarian.Penjualan, _kodeOrNamaForSearching);
            view.OnSendData += CariBarangPenjualanView_OnSendData;
            view.ShowDialog();
         }
      }

      private void CariBarangPenjualanView_OnSendData(object sender, EventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;
         var rowIndex = listDataGrid.CurrentCell.RowIndex;

         var view = (CariBarangView)sender;
         var model = ((ModelEventArgs<BarangModel>)e).Value;

         if (model != null)
         {
            _listPenjualanDetails[(rowIndex - 1)].Barang = model;
            _listPenjualanDetails[(rowIndex - 1)].barang_id = model.id;
            _listPenjualanDetails[(rowIndex - 1)].qty = 1;
            _listPenjualanDetails[(rowIndex - 1)].hpp = model.hpp;
            _listPenjualanDetails[(rowIndex - 1)].harga_jual = model.harga_jual;

            _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(listDataGrid.CurrentCell.RowIndex, 3));
            _view.ListDataGrid.CurrentCell.BeginEdit();
            view.Close();
         }
      }

      private void _view_OnHapusData(object sender, EventArgs e)
      {
         if (_view.ListDataGrid.Enabled && CurrCellValue != null)
         {
            if (!string.IsNullOrWhiteSpace(CurrCellValue.ToString()))
            {
               _listPenjualanDetails.RemoveAt((CurrCellRowIndex - 1));
               _listPenjualanDetails.Add(new PenjualanDetailModel());
               _bindingView.DataSource = _listPenjualanDetails;
            }
         }
      }

      private void _view_OnBayarPenjualan(object sender, EventArgs e)
      {
         var status = _listPenjualanDetails.Any(pd => pd.Barang.id != default(uint));

         try
         {
            if (_view.ListDataGrid.Enabled && status)
            {
               var view = new BayarPenjualanEntryView(_listPenjualanDetails);
               view.OnBayarPenjualan += View_OnBayarPenjualan;
               view.ShowDialog();
            }
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
      }

      private void View_OnBayarPenjualan(object sender, PembayaranEventArgs e)
      {
         try
         {
            var bayarPenjualanEntryView = ((Form)sender);
            var penjualanDetailsFixed = _listPenjualanDetails.Where(pd => pd.Barang.id != default(int)).ToList();

            var model = new PenjualanModel
            {
               Pelanggan = e.Pelanggan,
               status_pembayaran = e.StatusPenjualan,
               diskon = e.Diskon,
               PenjualanDetails = penjualanDetailsFixed
            };

            _penjualannServices.Insert(model);
            Messages.Info("Data Penjualan berhasil disimpan.");
            _view.ListDataGrid.Enabled = false;
            _view.TextBoxNoNota.Text = model.no_nota;

            if (model.diskon > 0)
            {
               _view.LabelGrandTotal.Text = (model.PenjualanDetails.Sum(pd => pd.total) - model.diskon).ToString("N0");
            }

            bayarPenjualanEntryView.Close();
            ((Form)_view).ActiveControl = _view.TextBoxNoNota;
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
      }

      private void _view_OnBersihkanData(object sender, EventArgs e)
      {
         if (!_view.ListDataGrid.Enabled)
         {
            _view.ListDataGrid.Enabled = true;
            _view.TextBoxNoNota.Text = string.Empty;
            _listsBarangs = _barangServices.GetAll().Where(b => b.harga_jual > 0).ToList();
         }

         _kodeOrNamaForSearching = string.Empty;
         _listPenjualanDetails.Clear();
         AddDummyPenjualanModel(30);
         _bindingView.DataSource = _listPenjualanDetails;
         _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(1, 1));
      }

      private void _view_OnListDataGridCurrentCellKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         if (e.KeyEventArgs.KeyCode == Keys.Return)
         {
            switch (e.ColumnIndex)
            {
               case 1: // Kode

                  _view_OnListDataGridCellKodeKeyDown(sender, e);

                  break;

               case 2: // Nama

                  _view_OnListDataGridCellNamaKeyDown(sender, e);

                  break;
               case 3: // Qty

                  _view_OnListDataGridCellQtyKeyDown(sender, e);

                  break;
            }
         }
      }

      private void _view_OnListDataGridCellKodeKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (CurrCellValue != null)
         {
            var kode = CurrCellValue.ToString();
            var model = _listsBarangs.Where(b => b.kode.Equals(kode)).FirstOrDefault();

            if (model != null)
            {
               _listPenjualanDetails[(CurrCellRowIndex - 1)].Barang = model;
               _listPenjualanDetails[(CurrCellRowIndex - 1)].qty = 1;
               _listPenjualanDetails[(CurrCellRowIndex - 1)].harga_jual = model.harga_jual;

               listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 2)));
               listDataGrid.CurrentCell.BeginEdit();
               e.KeyEventArgs.Handled = true;
            }
            else
            {
               if (!string.IsNullOrWhiteSpace(CurrCellValue.ToString()))
               {
                  _kodeOrNamaForSearching = CurrCellValue.ToString();
                  _view_OnCariData(null, null);
               }
               else
               {
                  _kodeOrNamaForSearching = "";
                  listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 1)));
                  listDataGrid.CurrentCell.BeginEdit();
               }

               e.KeyEventArgs.Handled = true;
            }
         }
      }

      private void _view_OnListDataGridCellNamaKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (CurrCellValue != null)
         {
            var nama = CurrCellValue.ToString();
            var model = _listsBarangs.Where(b => b.nama.ToLower().Equals(nama.ToLower())).FirstOrDefault();

            if (model != null)
            {
               _listPenjualanDetails[(CurrCellRowIndex - 1)].Barang = model;
               _listPenjualanDetails[(CurrCellRowIndex - 1)].qty = 1;
               _listPenjualanDetails[(CurrCellRowIndex - 1)].harga_jual = model.hpp;

               listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 1)));
               e.KeyEventArgs.Handled = true;
            }
            else
            {
               if (!string.IsNullOrWhiteSpace(CurrCellValue.ToString()))
               {
                  _kodeOrNamaForSearching = CurrCellValue.ToString();
                  _view_OnCariData(null, null);
               }
               else
               {
                  _kodeOrNamaForSearching = "";
                  _view_OnCariData(null, null);
               }

               e.KeyEventArgs.Handled = true;
            }
         }
      }

      private void _view_OnListDataGridCellQtyKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (CurrCellValue != null)
         {
            if (CurrCellRowIndex != (listDataGrid.RowCount - 1))
            {
               if (decimal.Parse(CurrCellValue.ToString(), NumberStyles.Number) > 0)
               {

                  listDataGrid.MoveToCurrentCell(new RowColumnIndex((CurrCellRowIndex + 1), 1));
                  listDataGrid.CurrentCell.BeginEdit();
               }

               e.KeyEventArgs.Handled = true;
            }
            else
            {
               _listPenjualanDetails.Add(new PenjualanDetailModel());
               listDataGrid.MoveToCurrentCell(new RowColumnIndex((CurrCellRowIndex + 1), 1));
               listDataGrid.CurrentCell.BeginEdit();
            }
         }
      }

      private void _view_OnListDataGridCurrentCellActivated(object sender, CurrentCellActivatedEventArgs e)
      {
         _view.ListDataGrid.CurrentCell.BeginEdit();
      }

      private void _view_OnListDataGridCurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
      {
         HitungGrandTotal();
      }

      private void HitungGrandTotal()
      {
         if (_view.ListDataGrid.Enabled)
         {
            _view.LabelGrandTotal.Text = _bindingView.Cast<IPenjualanDetailModel>().Sum(pd => pd.total).ToString("N0");
         }
      }

      private void _view_OnListDataGridPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (!listDataGrid.CurrentCell.IsEditing)
         {
            listDataGrid.CurrentCell.BeginEdit();
         }
      }

      private void AddDummyPenjualanModel(int length)
      {
         for (int i = 0; i < length; i++)
         {
            _listPenjualanDetails.Add(new PenjualanDetailModel());
         }
      }
   }
}
