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
      private List<ISupplierModel> _listSuppliers;

      protected override void OnCreateControl()
      {
         LoadDataSource();
         DropDownStyle = ComboBoxStyle.DropDownList;
      }
      
      private void LoadDataSource()
      {
         _services = new SupplierServices(new SupplierRepository(), new ModelDataAnnotationCheck());
         _listSuppliers = _services.GetAll().ToList();

         if (_listSuppliers != null && _listSuppliers.Count > 0)
         {
            var supplierKVP = _listSuppliers.Select(s => new KeyValuePair<object, string>(s.id, s.nama)).ToList();
            this.SetDataSource(supplierKVP, false);
         }
      }
   }
}
