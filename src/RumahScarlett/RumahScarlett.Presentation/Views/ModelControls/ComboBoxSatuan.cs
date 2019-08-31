using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Satuan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Satuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public class ComboBoxSatuan : ComboBox
   {
      private ISatuanServices _services;
      private List<ISatuanModel> _llistSatuans;

      protected override void OnCreateControl()
      {
         LoadDataSource();
      }

      private void LoadDataSource()
      {
         _services = new SatuanServices(new SatuanRepository(), new ModelDataAnnotationCheck());
         _llistSatuans = _services.GetAll().ToList();

         if (_llistSatuans != null && _llistSatuans.Count > 0)
         {
            var supplierKVP = _llistSatuans.Select(s => new KeyValuePair<object, string>(s.id, s.nama)).ToList();
            this.SetDataSource(supplierKVP, false);
         }
      }
   }
}
