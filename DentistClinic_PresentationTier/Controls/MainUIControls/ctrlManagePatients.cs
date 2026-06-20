using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;
using DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls;
using DentistClinic_PresentationTier.Forms.PatientsForms;
using Microsoft.Extensions.DependencyInjection;

namespace DentistClinic_PresentationTier.Controls.MainUIControls
{
    public partial class ctrlManagePatients : UserControl
    {
        private enum enSearchType
        {
            FullName,
            PhoneNumber,
        }

        private enSearchType _searchType = enSearchType.FullName;
        private readonly IPatientService _patientService;
        private IEnumerable<clsPatientView> _allPatients;

        private int selectedPatientID  { get; set;  }
        public ctrlManagePatients(IPatientService patientService)
        {
            _patientService = patientService;
            InitializeComponent();
        }

        private async void ctrlManagePatients_Load(object sender, EventArgs e)
        {
            await _buildDGV();
        }
        private async Task _buildDGV()
        {

            await _getAllPatientsData();
            //clsGenrateMockData._getMockPatients(ref _allPatients);
            _bindPatientsToGrid(_allPatients);
            _hideDGVIndecator();
        }

        //UI Events 
        private async void btnAddPatient_Click(object sender, EventArgs e)
        {
            var AddPatientForm = Program.ServiceProvider.GetRequiredService<frmAddOrEditePatient>();
            AddPatientForm.OnPatientDone += AddPatientForm_OnPatientDone;
            AddPatientForm.ShowDialog();
        }
        private async void AddPatientForm_OnPatientDone(object sender, frmAddOrEditePatient.MyEventArgs e)
        {
            await _buildShourtcutsPanel(e.Patient.PatientID, e.Patient.PersonInfo.FullName, e.Patient.PersonInfo.PhoneNumbers.Find(no => no.IsPrimary).Number);
            await _buildDGV();
            foreach (DataGridViewRow row in dgvPatient.Rows)
            {
                if ((int)row.Cells["ID"].Value == e.Patient.PatientID)
                {
                    row.Selected = true;
                }
            }
        }
        private void btnEditePatient_Click(object sender, EventArgs e)
        {

        }
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {

        }
        private void btnViewMedicalFile_Click(object sender, EventArgs e)
        {

        }

        private void cbSearchFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cbSearchFilters.SelectedItem.ToString();

            _searchType = _mapUserFilterSelection(selectedFilter);
        }
        private async void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int patientId = (int)dgvPatient?.Rows[e.RowIndex].Cells["ID"].Value;
            string pateintFullName = (string)dgvPatient?.Rows[e.RowIndex].Cells["FullName"].Value;
            string pateintPhoneNumber = (string)dgvPatient?.Rows[e.RowIndex].Cells["PhoneNumber"].Value;
            await _buildShourtcutsPanel(patientId, pateintFullName, pateintPhoneNumber);
        }
        private void tbSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (_allPatients == null || !_allPatients.Any()) return;

            var term = tbSearchBox.Text.Trim();

            switch (_searchType)
            {
                case enSearchType.FullName:
                    dgvPatient.DataSource = string.IsNullOrEmpty(term)
                ? _allPatients.ToList()
                : _allPatients.Where(p => p.FullName.Contains(term)).ToList();
                    break;
                case enSearchType.PhoneNumber:
                    dgvPatient.DataSource = string.IsNullOrEmpty(term)
                ? _allPatients.ToList()
                : _allPatients.Where(p => p.PhoneNumber.Contains(term)).ToList();
                    break;
                default:
                    break;
            }
        }
        
        //  Helper Methods
        private async Task _getAllPatientsData()
        {
            try
            {
                _allPatients = await _patientService.GetAllPatientDetailsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات المرضى\n" + ex.Message,
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _bindPatientsToGrid(IEnumerable<clsPatientView> patients)
        {
            if (patients == null) return;
            dgvPatient.DataSource = patients.ToList();
            _renameGridColumns();
        }
        private void _renameGridColumns()
        {
            if (dgvPatient.Columns["ID"]            != null) dgvPatient.Columns["ID"].HeaderText            = "الرقم";
            if (dgvPatient.Columns["FullName"]      != null) dgvPatient.Columns["FullName"].HeaderText      = "الاسم الكامل";
            if (dgvPatient.Columns["Age"]           != null) dgvPatient.Columns["Age"].HeaderText           = "العمر";
            if (dgvPatient.Columns["Gender"]        != null) dgvPatient.Columns["Gender"].HeaderText        = "الجنس";
            if (dgvPatient.Columns["PhoneNumber"]   != null) dgvPatient.Columns["PhoneNumber"].HeaderText   = "رقم الهاتف";
            if (dgvPatient.Columns["BloodTypeName"] != null) dgvPatient.Columns["BloodTypeName"].HeaderText = "فصيلة الدم";
        }
        private enSearchType _mapUserFilterSelection(string filter)
        {
            switch (filter)
            {
                case "الإسم":
                    return enSearchType.FullName;
                case "رقم الهاتف":
                    return enSearchType.PhoneNumber;
                default:
                    break;
            }
            return enSearchType.FullName;
        }
       private void _fillPatientInfoAtUI(clsPatient patient,string fullName ,string phoneNumber)
       {
            lblPatientName.Text = fullName ?? "N/A";
            lblPatientPhoneNumber.Text = phoneNumber ?? "N/A";

            if (patient == null)
            {
                MessageBox.Show("لا يوجد شخص مخزن في قاعدة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblNationalNo.Text = patient.PersonInfo.NationalNo??"N/A";
            lblHealthProblem.Text = patient.HealthProblems??"N/A";
       }
        private async Task<clsPatient> _getPatientInfo(int patientID)
        {
            clsPatient patient = null;
            try
            {
                patient = await _patientService.GetByIdAsync(patientID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return patient;
        }

        private void _hideDGVIndecator()
        {
            dgvIndecatorPanel.Visible = false;
        }

        private async Task _buildShourtcutsPanel(int patientId, string fullName, string phoneNumber)
        {
            selectedPatientID = patientId;
            clsPatient selectedPatientInfo = await _getPatientInfo(selectedPatientID);
            _fillPatientInfoAtUI(selectedPatientInfo, fullName, phoneNumber);
            shourcutsPatientPanel.Visible = true;
        }
    }
}
