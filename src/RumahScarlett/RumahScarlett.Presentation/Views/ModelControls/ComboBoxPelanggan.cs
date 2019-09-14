using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pelanggan;
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

      public uint GetSelectedID
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? ((IPelangganModel)comboBox.SelectedItem).id : default(uint);
         }
      }

      public IPelangganModel GetModel(object id)
      {
         return comboBox.Items.Cast<IPelangganModel>().Where(p => p.id == (uint)id).FirstOrDefault();
      }

      public ComboBoxPelanggan()
      {
         InitializeComponent();

         if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime))
         {
            LoadDataSource();
         }
      }

      private void LoadDataSource()
      {
         _services = new PelangganServices(new PelangganRepository(), new ModelDataAnnotationCheck());
         _listPelanggans = _services.GetAll().ToList();

         if (_listPelanggans != null && _listPelanggans.Count > 0)
         {
            comboBox.Items.AddRange(_listPelanggans.ToArray());
            comboBox.DisplayMember = "nama";
         }
      }
   }
}
