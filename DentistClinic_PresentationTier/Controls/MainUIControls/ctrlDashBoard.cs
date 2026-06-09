using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
        private async void ctrlDashBoard_Load(object sender, EventArgs e)
        {
            Task.Run(()=> _handleProgressIndicator(true));
            //database delay
            await Task.Run(() => 
            {
                for (int i = 0; i < 1000000000; i++) {
                }
            });
            _handleProgressIndicator(false);
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

        private void _handleProgressIndicator(bool enable)
        {
            if (enable)
            {
                this.guna2WinProgressIndicator.Start();
            }
            else
            {
                this.guna2WinProgressIndicator.Stop();
                this.guna2WinProgressIndicator.Dispose();
                this.Controls.Remove(this.indecatorPanel);
            }
        }
    }
}
