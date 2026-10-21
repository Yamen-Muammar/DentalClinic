using System;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    public partial class frmAddProblem : Form
    {
        private readonly IProblemService _problemService;
        private int _medicalFileId;
        
        public event EventHandler OnProblemAdded;

        public frmAddProblem(IProblemService problemService)
        {
            InitializeComponent();
            _problemService = problemService;
        }

        public void LoadData(int medicalFileId)
        {
            _medicalFileId = medicalFileId;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("الرجاء إدخال التشخيص", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalCost = 0;
            if (!string.IsNullOrWhiteSpace(txtCost.Text) && !decimal.TryParse(txtCost.Text, out totalCost))
            {
                MessageBox.Show("تكلفة غير صالحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var problem = new clsProblem
                {
                    MedicalFile_ID = _medicalFileId,
                    Diagnosis = txtDiagnosis.Text,
                    TotalCost = totalCost,
                    CreationDate = DateTime.Now,
                    Status = myEnums.enProblemStatus.New
                };

                var id = await _problemService.InsertAsync(problem);
                if (id.HasValue && id.Value > 0)
                {
                    MessageBox.Show("تمت الإضافة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnProblemAdded?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشلت عملية الإضافة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("حدث خطأ أثناء عملية الإضافة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
