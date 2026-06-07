using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DentistClinic_PresentationTier.Controls.MainUIControls
{
    public partial class ctrlDashBoard : UserControl
    {
        public ctrlDashBoard()
        {
            InitializeComponent();
        }
        private void pnlTodayPatient_DoubleClick(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            MessageBox.Show(guna2Panel.Name);
        }

        private void pnlNotConfirmedPayments_DoubleClick(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            MessageBox.Show(guna2Panel.Name);
        }

        private void pnlTodayAppointments_DoubleClick(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;
            MessageBox.Show(guna2Panel.Name);
        }

        private void Panle_MouseEnter(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;

        }
        private void Panle_MouseLeave(object sender, EventArgs e)
        {
            Guna2ShadowPanel guna2Panel = sender as Guna2ShadowPanel;

        }
    }
}
