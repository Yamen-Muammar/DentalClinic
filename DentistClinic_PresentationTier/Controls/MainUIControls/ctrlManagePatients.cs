using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier.Controls.MainUIControls
{
    public partial class ctrlManagePatients : UserControl
    {
        public ctrlManagePatients()
        {
            InitializeComponent();
            
        }

        private async void ctrlManagePatients_Load(object sender, EventArgs e)
        {
            await _loadCtrlPersonInfo(1);

        }

        private async Task _loadCtrlPersonInfo(int personID)
        {
            this.ctrlPersonInformation1 = Program.ServiceProvider.GetRequiredService<ctrlPersonInformation>();
            await this.ctrlPersonInformation1.SetPersonID(personID);
            this.tableLayoutPanel1.Controls.Add(this.ctrlPersonInformation1, 1, 1);
            this.ctrlPersonInformation1.Dock = DockStyle.Top;
        }
    }
}
