using Dapper;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok
{
   internal interface IPenyesuaianStokDetailRepository
   {
      void Insert(IPenyesuaianStokDetailModel model, IDbTransaction transaction);
      IEnumerable<IPenyesuaianStokDetailModel> GetAll(IPenyesuaianStokModel penyesuaianStok);
      uint GetQtyCount(object barangId);
   }

   internal class PenyesuaianStokDetailRepository : IPenyesuaianStokDetailRepository
   {
      private DbContext _context;

      public PenyesuaianStokDetailRepository(DbContext context)
      {
         _context = context;
      }

      public void Insert(IPenyesuaianStokDetailModel model, IDbTransaction transaction)
      {
         var queryStr = "INSERT INTO penyesuaian_stok_detail (penyesuaian_stok_id, barang_id, qty, hpp, keterangan) " +
                        "VALUES (@penyesuaian_stok_id, @barang_id, @qty, @hpp, @keterangan)";

         _context.Conn.Query<int>(queryStr, new
         {
            penyesuaian_stok_id = model.penyesuaian_stok_id,
            barang_id = model.barang_id,
            qty = model.qty,
            hpp = model.hpp,
            keterangan = model.keterangan
         }, transaction);
      }
      
      public IEnumerable<IPenyesuaianStokDetailModel> GetAll(IPenyesuaianStokModel penyesuaianStok)
      {
         var queryStr = "SELECT * FROM penyesuaian_stok_detail WHERE penyesuaian_stok_id=@id";

         var listPembelianDetails = _context.Conn.Query<PenyesuaianStokDetailModel>(queryStr, new { id = penyesuaianStok.id }).ToList();

         if (listPembelianDetails.Count > 0)
         {
            listPembelianDetails = listPembelianDetails.Map(pd => pd.Barang = new BarangRepository().GetById(pd.barang_id)).ToList();
         }

         return listPembelianDetails;
      }

      public uint GetQtyCount(object barangId)
      {
         var queryStr = "SELECT SUM(qty) FROM penyesuaian_stok_detail WHERE barang_id=@barangId GROUP BY barang_id";

         return _context.Conn.ExecuteScalar<uint>(queryStr, new { barangId });
      }
   }
}
