using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier.Interfaces;
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

        private List<clsPatientView> _allPatients { get; set; }
        private clsPatient SelectedPatientInfo { get; set; }
        private int selectedPatientID { get; set; }

        private readonly IPatientService _patientService;
        private readonly IPersonService _personService;
        private ISessionContext _sessionContext;

        public ctrlManagePatients(IPersonService personService,IPatientService patientService,ISessionContext sessionContext)
        {
            _patientService = patientService;
            _personService = personService;
            _sessionContext = sessionContext;
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0 * 02000000;
                return cp;
            }   
        }
        private async void ctrlManagePatients_Load(object sender, EventArgs e)
        {
            await _buildDGV();
        }
        private async Task _buildDGV()
        {
            _handelDGVIndecator(true);
            await _getAllPatientsData();
            _bindPatientsToGrid(_allPatients);
            await Task.Delay(200);
            _handelDGVIndecator(false);
        }
       private async Task _refreshDGV()
        {
            _handelDGVIndecator(true);
            _bindPatientsToGrid(_allPatients);
            await Task.Delay(200);
            _handelDGVIndecator(false);
        }

        //Outer Events 
        private async void AddPatientForm_OnPatientReActived(object sender, frmAddOrEditePatient.MyEventArgs e)
        {
            try
            {
                clsPatientView patientView = await _patientService.GetPatientDetailsViewByIDAsync(e.Patient.PatientID);
                if (patientView != null)
                {
                    if (!_allPatients.Contains(patientView))
                    {
                        _allPatients.Add(patientView);
                    }
                    await _refreshDGV();
                    foreach (DataGridViewRow row in dgvPatient.Rows)
                    {
                        if ((int)row.Cells["ID"].Value == e.Patient.PatientID)
                        {
                            row.Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private async void AddPatientForm_OnPatientDone(object sender, frmAddOrEditePatient.MyEventArgs e)
        {
            try
            {
                await _buildPatientShortcutsPanel(e.Patient.PatientID, e.Patient.PersonInfo.FullName, e.Patient.PersonInfo.PhoneNumber);

                clsPatientView patientView = await _patientService.GetPatientDetailsViewByIDAsync(e.Patient.PatientID);
                if (patientView != null && (_allPatients.Find(p => p.ID == patientView.ID) == null))
                {
                    _allPatients.Add(patientView);
                }

                await _refreshDGV();
                foreach (DataGridViewRow row in dgvPatient.Rows)
                {
                    if ((int)row.Cells["ID"].Value == e.Patient.PatientID)
                    {
                        row.Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //UI Events 
        private async void btnAddPatient_Click(object sender, EventArgs e)
        {
            var AddPatientForm = Program.ServiceProvider.GetRequiredService<frmAddOrEditePatient>();
            AddPatientForm.OnPatientDone += AddPatientForm_OnPatientDone;
            AddPatientForm.OnPatientReActived += AddPatientForm_OnPatientReActived;
            AddPatientForm.ShowDialog();
        }   
        private async void btnEditePatient_Click(object sender, EventArgs e)
        {
            var AddPatientForm = Program.ServiceProvider.GetRequiredService<frmAddOrEditePatient>();
            await AddPatientForm.SetPatientID(selectedPatientID);
            if (AddPatientForm.IsDisposed)
            {
                return;
            }
            AddPatientForm.OnPatientDone += AddPatientForm_OnPatientDone;
            AddPatientForm.ShowDialog();
        }
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {

        }
        private void btnViewMedicalFile_Click(object sender, EventArgs e)
        {

        }
        private async void btnDeletePatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (await _personService.SoftDeleteAsync(SelectedPatientInfo.Person_ID, _sessionContext.StaffID))
                {
                    clsPatientView selectedPatient =  _allPatients.FirstOrDefault(p => p.ID == selectedPatientID);
                    _allPatients.Remove(selectedPatient);
                    _clearPatientShortcutsPanel();
                    await _refreshDGV();
                    MessageBox.Show("تم حذف المريض بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);                                       
                }
                else
                {
                    MessageBox.Show("لم يتم حذف المريض ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void cbSearchFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cbSearchFilters.SelectedItem.ToString();

            _searchType = _mapUserFilterSelection(selectedFilter);
        }
        private async void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            int patientId = (int)dgvPatient?.Rows[e.RowIndex].Cells["ID"].Value;
            string pateintFullName = (string)dgvPatient?.Rows[e.RowIndex].Cells["FullName"].Value;
            string pateintPhoneNumber = (string)dgvPatient?.Rows[e.RowIndex].Cells["PhoneNumber"].Value;
            await _buildPatientShortcutsPanel(patientId, pateintFullName, pateintPhoneNumber);
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
                _allPatients = (List<clsPatientView>)await _patientService.GetAllPatientDetailsAsync();
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
            lblHealthProblem.Text = patient.HealthProblems != string.Empty ? patient.HealthProblems : "N/A";
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
        private void _handelDGVIndecator(bool enable)
        {
            dgvIndecatorPanel.Visible = enable;
        }
        private async Task _buildPatientShortcutsPanel(int patientId, string fullName, string phoneNumber)
        {
            selectedPatientID = patientId;
            SelectedPatientInfo = await _getPatientInfo(selectedPatientID);
            _fillPatientInfoAtUI(SelectedPatientInfo, fullName, phoneNumber);
            shourcutsPatientPanel.Visible = true;
        }
        private void _clearPatientShortcutsPanel()
        {
            selectedPatientID = 0;
            SelectedPatientInfo = null;
            shourcutsPatientPanel.Visible = false;
        }
    }
}
