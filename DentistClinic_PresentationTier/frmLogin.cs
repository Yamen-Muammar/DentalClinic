using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier.Interfaces;

namespace DentistClinic_PresentationTier
{
    public partial class frmLogin : Form
    {
        private StaffService _staffService;
        public frmLogin(IStaffRepository staffRepository)
        {
            InitializeComponent();
            _staffService = new StaffService(staffRepository);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.DialogResult = DialogResult.OK;
            }
            
        }
    }
}
