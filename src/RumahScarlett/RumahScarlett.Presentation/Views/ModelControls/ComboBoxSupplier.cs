using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
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
   public partial class ComboBoxSupplier : UserControl
   {
      private ISupplierServices _services;
      private List<ISupplierModel> _listSuppliers;

      public ComboBox ComboBox
      {
        get { return comboBox; }
      }

      public uint GetSelectedID
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? ((ISupplierModel)comboBox.SelectedItem).id : default(uint);
         }
      }

      public ISupplierModel GetModel(object id)
      {
         return comboBox.Items.Cast<ISupplierModel>().Where(s => s.id == (uint)id).FirstOrDefault();
      }

      public ComboBoxSupplier()
      {
         InitializeComponent();

         LoadDataSource();
      }

      private void LoadDataSource()
      {
         _services = new SupplierServices(new SupplierRepository(), new ModelDataAnnotationCheck());
         _listSuppliers = _services.GetAll().ToList();

         if (_listSuppliers != null && _listSuppliers.Count > 0)
         {
            comboBox.Items.AddRange(_listSuppliers.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
