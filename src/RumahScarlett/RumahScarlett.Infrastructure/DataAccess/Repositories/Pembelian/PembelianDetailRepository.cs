using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian
{
   internal interface IPembelianDetailRepository
   {
      void Insert(IPembelianDetailModel model, IDbTransaction transaction);
      IEnumerable<IPembelianDetailModel> GetAll(IPembelianModel pembelian);
   }

   internal class PembelianDetailRepository : IPembelianDetailRepository
   {
      private DbContext _context;

      public PembelianDetailRepository(DbContext context)
      {
         _context = context;
      }

      public void Insert(IPembelianDetailModel model, IDbTransaction transaction)
      {
         var queryStr = "INSERT INTO pembelian_detail (pembelian_id, barang_id, qty, hpp) " +
                        "VALUES (@pembelian_id, @barang_id, @qty, @hpp)";

         _context.Conn.Query<int>(queryStr, new
         {
            pembelian_id = model.pembelian_id,
            barang_id = model.barang_id,
            qty = model.qty,
            hpp = model.hpp > 0 ? model.hpp : model.Barang.hpp,
         }, transaction);
      }

      public IEnumerable<IPembelianDetailModel> GetAll(IPembelianModel pembelian)
      {
         var queryStr = "SELECT * FROM pembelian_detail WHERE pembelian_id=@id";

         var listPembelianDetails = _context.Conn.Query<PembelianDetailModel>(queryStr, new { id = pembelian.id }).ToList();

         if (listPembelianDetails.Count > 0)
         {
            listPembelianDetails = listPembelianDetails.Map(pd => pd.Barang = new BarangRepository().GetById(pd.barang_id)).ToList();
         }

         return listPembelianDetails;
      }
   }
}
