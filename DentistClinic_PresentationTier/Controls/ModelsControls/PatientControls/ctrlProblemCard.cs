using System;
using System.Drawing;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls
{
    public partial class ctrlProblemCard : UserControl
    {
        private clsProblem _problem;

        public event EventHandler<clsProblem> OnProblemClicked;

        public ctrlProblemCard()
        {
            InitializeComponent();
            this.Click += CtrlProblemCard_Click;
            // Make all child controls pass click to the card
            foreach (Control c in this.pnlCard.Controls)
            {
                c.Click += (s, e) => CtrlProblemCard_Click(this, e);
                foreach (Control cc in c.Controls)
                    cc.Click += (s, e) => CtrlProblemCard_Click(this, e);
            }
        }

        public void LoadProblemData(clsProblem problem)
        {
            if (problem == null) return;
            _problem = problem;

            lblDiagnosis.Text = string.IsNullOrEmpty(problem.Diagnosis) ? "غير محدد" : problem.Diagnosis;
            lblDate.Text = problem.CreationDate.ToString("yyyy-MM-dd");
            lblCost.Text = problem.TotalCost.HasValue ? problem.TotalCost.Value.ToString("N2") + "$" : "غير محدد";

            string statusText;
            Color statusColor;
            switch (problem.Status)
            {
                case myEnums.enProblemStatus.New:
                    statusText = "جديد";
                    statusColor = Color.FromArgb(0, 123, 255);
                    break;
                case myEnums.enProblemStatus.InProgress:
                    statusText = "قيد العلاج";
                    statusColor = Color.FromArgb(255, 193, 7);
                    break;
                case myEnums.enProblemStatus.Done:
                    statusText = "مكتمل";
                    statusColor = Color.FromArgb(40, 167, 69);
                    break;
                case myEnums.enProblemStatus.Closed:
                    statusText = "مغلق";
                    statusColor = Color.FromArgb(108, 117, 125);
                    break;
                default:
                    statusText = problem.Status.ToString();
                    statusColor = Color.Gray;
                    break;
            }
            lblStatus.Text = statusText;
            lblStatus.ForeColor = statusColor;
        }

        private void CtrlProblemCard_Click(object sender, EventArgs e)
        {
            if (_problem != null)
                OnProblemClicked?.Invoke(this, _problem);
        }
    }
}
