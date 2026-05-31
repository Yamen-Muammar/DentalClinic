using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier
{
    public partial class frmMain : Form
    {
        private IBloodTypeService _bloodTypeService;
        public frmMain(IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                List<clsBloodType> clsBloods = new List<clsBloodType>();
                clsBloods = (List<clsBloodType>)await _bloodTypeService.GetAllAsync();
                dgvBloodTypes.DataSource = clsBloods;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);     
            }
            
        }
    }
}
