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
      private bool _newModelIsSended = false;

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

         _view.OnLoadData += _view_OnLoadData;
         _view.OnCariData += _view_OnCariData;
         _view.OnCellKodeKeyDown += _view_OnCellKodeKeyDown;
         _view.OnCellNamaKeyDown += _view_OnCellNamaKeyDown;
         _view.OnCellQtyKeyDown += _view_OnCellQtyKeyDown;
         _view.OnCellHppKeyDown += _view_OnCellHppKeyDown;
         _view.OnHapusData += _view_OnHapusData;
         _view.OnSimpanData += _view_OnSimpanData1;
         _view.OnSimpanData += _view_OnSimpanData;
         _view.OnBersihkanData += _view_OnBersihkanData;

         _view.ListDataGrid.CurrentCellEndEdit += ListDataGrid_CurrentCellEndEdit;
         _view.ListDataGrid.PreviewKeyDown += ListDataGrid_PreviewKeyDown;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         _listsPembelianDetails = new List<PembelianDetailModel>();

         for (int i = 0; i < 30; i++)
         {
            _listsPembelianDetails.Add(new PembelianDetailModel());
         }

         _bindingView = new BindingListView<PembelianDetailModel>(_listsPembelianDetails);
         _view.ListDataGrid.DataSource = _bindingView;

         ((Form)_view).ActiveControl = _view.ListDataGrid;
         _view.ListDataGrid.MoveToCurrentCell(new RowColumnIndex(1, 1));
      }

      private void _view_OnCariData(object sender, EventArgs e)
      {
         var view = new CariBarangPembelianView(_listsBarangs);
         view.OnSendData += CariBarangPembelianView_OnSendData;
         view.ShowDialog();
      }

      private void CariBarangPembelianView_OnSendData(object sender, EventArgs e)
      {
         var view = (CariBarangPembelianView)sender;
         var model = ((EventArgs<BarangModel>)e).Value;

         if (model != null)
         {
            _newModelIsSended = true;

            var pembelianDetailNullValue = _listsPembelianDetails.Where(pd => string.IsNullOrEmpty(pd.barang_nama)).FirstOrDefault();

            if (pembelianDetailNullValue != null)
            {
               pembelianDetailNullValue.Barang = model;
               pembelianDetailNullValue.hpp = model.hpp;
               pembelianDetailNullValue.qty = 1;
            }
            else
            {
               _listsPembelianDetails.Add(new PembelianDetailModel
               {
                  Barang = model,
                  barang_id = model.id,
                  hpp = model.hpp,
                  qty = 1
               });
            }

            _bindingView.Refresh();
            view.Close();
         }
         else
         {
            _newModelIsSended = false;
         }
      }

      private void _view_OnCellKodeKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = (ListDataGrid)sender;
         var rowIndex = listDataGrid.CurrentCell.RowIndex;
         var cellValue = listDataGrid.CurrentCell.CellRenderer.GetControlValue();

         if (cellValue != null)
         {
            var kode = cellValue.ToString();
            var model = _listsBarangs.Where(b => b.kode.Equals(kode)).FirstOrDefault();

            if (model != null)
            {
               _listsPembelianDetails[(rowIndex - 1)].Barang = model;
               _listsPembelianDetails[(rowIndex - 1)].hpp = model.hpp;
               _listsPembelianDetails[(rowIndex - 1)].qty = 1;

               listDataGrid.MoveToCurrentCell(new RowColumnIndex(rowIndex, (e.ColumnIndex + 2)));
               e.KeyEventArgs.Handled = true;
            }
            else
            {
               listDataGrid.MoveToCurrentCell(new RowColumnIndex(rowIndex, (e.ColumnIndex + 1)));

               e.KeyEventArgs.Handled = true;
            }
         }
      }

      private void _view_OnCellNamaKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = (ListDataGrid)sender;
         var rowIndex = listDataGrid.CurrentCell.RowIndex;
         var cellValue = listDataGrid.CurrentCell.CellRenderer.GetControlValue();

         if (cellValue != null)
         {
            var nama = cellValue.ToString();
            var model = _listsBarangs.Where(b => b.nama.ToLower().Equals(nama.ToLower())).FirstOrDefault();

            if (model != null)
            {
               _listsPembelianDetails[(rowIndex - 1)].Barang = model;
               _listsPembelianDetails[(rowIndex - 1)].hpp = model.hpp;
               _listsPembelianDetails[(rowIndex - 1)].qty = 1;

               listDataGrid.MoveToCurrentCell(new RowColumnIndex(rowIndex, (e.ColumnIndex + 1)));
               e.KeyEventArgs.Handled = true;
            }
            else
            {
               _view_OnCariData(null, null);

               if (_newModelIsSended)
               {
                  listDataGrid.MoveToCurrentCell(new RowColumnIndex(rowIndex, (e.ColumnIndex + 1)));
               }

               e.KeyEventArgs.Handled = true;
            }
         }
      }

      private void _view_OnCellQtyKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = (ListDataGrid)sender;
         var cellValue = listDataGrid.CurrentCell.CellRenderer.GetControlValue();
         var rowindex = listDataGrid.CurrentCell.RowIndex;

         if (cellValue != null && int.Parse(cellValue.ToString(), NumberStyles.Number) > 0)
         {
            listDataGrid.MoveToCurrentCell(new RowColumnIndex(rowindex, (e.ColumnIndex + 1)));
            e.KeyEventArgs.Handled = true;
         }
      }

      private void _view_OnCellHppKeyDown(object sender, CurrentCellKeyEventArgs e)
      {
         var listDataGrid = (ListDataGrid)sender;
         var cellValue = listDataGrid.CurrentCell.CellRenderer.GetControlValue();
         var rowindex = listDataGrid.CurrentCell.RowIndex;

         if (rowindex != (listDataGrid.RowCount - 1))
         {
            if (cellValue != null && decimal.Parse(cellValue.ToString(), NumberStyles.Number) > 0)
            {
               listDataGrid.MoveToCurrentCell(new RowColumnIndex((rowindex + 1), 1));
               e.KeyEventArgs.Handled = true;
            }
         }
         else
         {
            _listsPembelianDetails.Add(new PembelianDetailModel());
            _bindingView.Refresh();
            listDataGrid.MoveToCurrentCell(new RowColumnIndex((rowindex + 1), 1));
         }
      }

      private void ListDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
      {
         _view.LabelTotalQty.Text = _listsPembelianDetails.Where(pd => !string.IsNullOrWhiteSpace(pd.barang_nama)).ToList().Sum(pd => pd.qty).ToString("N0");
         _view.LabelTotalPembelian.Text = _listsPembelianDetails.Where(pd => !string.IsNullOrWhiteSpace(pd.barang_nama)).ToList().Sum(pd => pd.total).ToString("N0");
      }

      private void ListDataGrid_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         var listDataGrid = (ListDataGrid)sender;

         if (!listDataGrid.CurrentCell.IsEditing)
         {
            listDataGrid.CurrentCell.BeginEdit();
         }
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
