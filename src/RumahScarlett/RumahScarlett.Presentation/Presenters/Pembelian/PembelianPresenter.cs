using Equin.ApplicationFramework;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Pembelian;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
using RumahScarlett.Services.Services.Pembelian;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

         _view.ListDataGrid.EditorSelectionBehavior = EditorSelectionBehavior.SelectAll;
         _view.ListDataGrid.EditMode = EditMode.SingleClick;
         _view.ListDataGrid.AllowEditing = true;
         _view.ListDataGrid.AllowSorting = false;

         _view.OnLoadData += _view_OnLoadData;
         _view.OnCariData += _view_OnCariData;
         _view.OnCellKodeKeyDown += _view_OnCellKodeKeyDown;
         _view.OnCellNamaKeyDown += _view_OnCellNamaKeyDown;
         _view.OnCellQtyKeyDown += _view_OnCellQtyKeyDown;
         _view.OnCellHppKeyDown += _view_OnCellHppKeyDown;
         _view.OnHapusData += _view_OnHapusData;
         _view.OnSimpanData += _view_OnSimpanData;
         _view.OnBersihkanData += _view_OnBersihkanData;

         _view.ListDataGrid.CurrentCellActivated += ListDataGrid_CurrentCellActivated;
         _view.ListDataGrid.CurrentCellEndEdit += ListDataGrid_CurrentCellEndEdit;
         _view.ListDataGrid.PreviewKeyDown += ListDataGrid_PreviewKeyDown;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         ((Form)_view).ActiveControl = _view.ListDataGrid;

         _listsPembelianDetails = new List<PembelianDetailModel>();

         AddDummyPembelianModel(30);

         _bindingView = new BindingListView<PembelianDetailModel>(_listsPembelianDetails);
         _view.ListDataGrid.DataSource = _bindingView;
         _bindingView.ListChanged += _bindingView_ListChanged;

         _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(1, 1));
         _view.ListDataGrid.CurrentCell.BeginEdit();
      }

      private void _bindingView_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
      {
         HitungRingkasan();
      }

      private void _view_OnCariData(object sender, EventArgs e)
      {
         var view = new CariBarangPembelianView(_listsBarangs);
         view.OnSendData += CariBarangPembelianView_OnSendData;
         view.ShowDialog();
      }

      private void CariBarangPembelianView_OnSendData(object sender, EventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;
         var rowIndex = listDataGrid.CurrentCell.RowIndex;

         var view = (CariBarangPembelianView)sender;
         var model = ((EventArgs<BarangModel>)e).Value;

         if (model != null)
         {
            _listsPembelianDetails[(rowIndex - 1)].Barang = model;
            _listsPembelianDetails[(rowIndex - 1)].barang_id = model.id;
            _listsPembelianDetails[(rowIndex - 1)].hpp = model.hpp;
            _listsPembelianDetails[(rowIndex - 1)].qty = 1;

            _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(listDataGrid.CurrentCell.RowIndex, 3));
            _view.ListDataGrid.CurrentCell.BeginEdit();
            view.Close();
         }
      }

      private void _view_OnCellKodeKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (CurrCellValue != null)
         {
            var kode = CurrCellValue.ToString();
            var model = _listsBarangs.Where(b => b.kode.Equals(kode)).FirstOrDefault();

            if (model != null)
            {
               _listsPembelianDetails[(CurrCellRowIndex - 1)].Barang = model;
               _listsPembelianDetails[(CurrCellRowIndex - 1)].hpp = model.hpp;
               _listsPembelianDetails[(CurrCellRowIndex - 1)].qty = 1;

               listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 2)));
               listDataGrid.CurrentCell.BeginEdit();
               e.KeyEventArgs.Handled = true;
            }
            else
            {
               listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 1)));
               listDataGrid.CurrentCell.BeginEdit();
               e.KeyEventArgs.Handled = true;
            }
         }
      }

      private void _view_OnCellNamaKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (CurrCellValue != null)
         {
            var nama = CurrCellValue.ToString();
            var model = _listsBarangs.Where(b => b.nama.ToLower().Equals(nama.ToLower())).FirstOrDefault();

            if (model != null)
            {
               _listsPembelianDetails[(CurrCellRowIndex - 1)].Barang = model;
               _listsPembelianDetails[(CurrCellRowIndex - 1)].hpp = model.hpp;
               _listsPembelianDetails[(CurrCellRowIndex - 1)].qty = 1;

               listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 1)));
               e.KeyEventArgs.Handled = true;
            }
            else
            {
               _view_OnCariData(null, null);
               e.KeyEventArgs.Handled = true;
            }
         }
      }

      private void _view_OnCellQtyKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (CurrCellValue != null)
         {
            if (int.Parse(CurrCellValue.ToString(), NumberStyles.Number) > 0)
            {
               listDataGrid.MoveToCurrentCell(new RowColumnIndex(CurrCellRowIndex, (e.ColumnIndex + 1)));
               listDataGrid.CurrentCell.BeginEdit();
            }
         }

         e.KeyEventArgs.Handled = true;
      }

      private void _view_OnCellHppKeyDown(object sender, CurrentCellKeyEventArgs e)
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
               _listsPembelianDetails.Add(new PembelianDetailModel());
               listDataGrid.MoveToCurrentCell(new RowColumnIndex((CurrCellRowIndex + 1), 1));
               listDataGrid.CurrentCell.BeginEdit();
            }
         }
      }

      private void ListDataGrid_CurrentCellActivated(object sender, CurrentCellActivatedEventArgs e)
      {
         _view.ListDataGrid.CurrentCell.BeginEdit();
      }

      private void ListDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
      {
         HitungRingkasan();
      }

      private void HitungRingkasan()
      {
         _view.LabelTotalQty.Text = _listsPembelianDetails.Where(pd => !string.IsNullOrWhiteSpace(pd.barang_nama)).ToList().Sum(pd => pd.qty).ToString("N0");
         _view.LabelTotalPembelian.Text = _listsPembelianDetails.Where(pd => !string.IsNullOrWhiteSpace(pd.barang_nama)).ToList().Sum(pd => pd.total).ToString("N0");
      }

      private void ListDataGrid_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         var listDataGrid = _view.ListDataGrid;

         if (!listDataGrid.CurrentCell.IsEditing)
         {
            listDataGrid.CurrentCell.BeginEdit();
         }
      }

      public int CurrCellRowIndex
      {
         get { return _view.ListDataGrid.CurrentCell.RowIndex; }
      }

      public object CurrCellValue
      {
         get
         {
            return _view.ListDataGrid.CurrentCell.CellRenderer.GetControlValue();
         }
      }

      private void _view_OnHapusData(object sender, EventArgs e)
      {
         if (CurrCellValue != null)
         {
            if (!string.IsNullOrWhiteSpace(CurrCellValue.ToString()))
            {
               _listsPembelianDetails.RemoveAt((CurrCellRowIndex - 1));
               _listsPembelianDetails.Add(new PembelianDetailModel());
               _bindingView.DataSource = _listsPembelianDetails;
            }
         }
      }

      private void _view_OnSimpanData(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void _view_OnBersihkanData(object sender, EventArgs e)
      {
         _listsPembelianDetails.Clear();
         AddDummyPembelianModel(30);
         _bindingView.DataSource = _listsPembelianDetails;
         _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(1, 1));
      }

      private void AddDummyPembelianModel(int length)
      {
         for (int i = 0; i < length; i++)
         {
            _listsPembelianDetails.Add(new PembelianDetailModel());
         }
      }

   }
}
