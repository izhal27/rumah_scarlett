using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pelanggan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pelanggan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public partial class ComboBoxPelanggan : UserControl
   {
      private IPelangganServices _services;
      private List<IPelangganModel> _listPelanggans;

      public ComboBox ComboBox
      {
         get { return comboBox; }
      }

      public ComboBoxPelanggan()
      {
         InitializeComponent();

         LoadDataSource();
      }

      private void LoadDataSource()
      {
         _services = new PelangganServices(new PelangganRepository(), new ModelDataAnnotationCheck());
         _listPelanggans = _services.GetAll().ToList();

         if (_listPelanggans != null && _listPelanggans.Count > 0)
         {
            var pelangganKVP = _listPelanggans.Select(s => new KeyValuePair<object, string>(s.id, s.nama)).ToList();
            comboBox.SetDataSource(pelangganKVP);
         }
      }
   }
}
