using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    public partial class frmAddOrEditePatientInformation : Form
    {
        private int patientID;

        private enum enMode
        {
            add,edite
        }

        private enMode mode;
        public frmAddOrEditePatientInformation()
        {
            ctrlAddOrEditePatientInformation1 = Program.ServiceProvider.GetRequiredService<ctrlAddOrEditePatientInformation>();
            this.Controls.Add(this.ctrlAddOrEditePatientInformation1);
            InitializeComponent();
            mode  = enMode.add;
        }

        public async Task SetPatientID(int patientID)
        {
            this.patientID = patientID;
            mode = enMode.edite;            
            await ctrlAddOrEditePatientInformation1.SetPatientID(this.patientID);
        }

        private async void frmTestCtrlAddOrEdite_Load(object sender, EventArgs e)
        {
            this.ctrlAddOrEditePatientInformation1.OnClose += CtrlAddOrEditePatientInformation_OnClose;
        }

        private void CtrlAddOrEditePatientInformation_OnClose()
        {
            this.Close();
        }
    }
}
