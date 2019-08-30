using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public class ComboBoxSupplier : ComboBox
   {
      private ISupplierServices _services;
      private List<ISupplierModel> _llistSuppliers;

      protected override void OnCreateControl()
      {
         LoadDataSource();
      }
      
      private void LoadDataSource()
      {
         _services = new SupplierServices(new SupplierRepository(), new ModelDataAnnotationCheck());
         _llistSuppliers = _services.GetAll().ToList();

         if (_llistSuppliers != null && _llistSuppliers.Count > 0)
         {
            var supplierKVP = _llistSuppliers.Select(t => new KeyValuePair<object, string>(t.id, t.nama)).ToList();
            this.SetDataSource(supplierKVP, false);
         }
      }

   }
}
