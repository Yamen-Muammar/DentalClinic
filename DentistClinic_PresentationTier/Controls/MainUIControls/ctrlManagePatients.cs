using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_BusinessTier.Services;
using DentalClinic_CoreTier;
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
        private IBloodTypeService _bloodTypeService;

        private readonly System.Windows.Forms.Timer _searchTimer;
        public ctrlManagePatients(IPersonService personService,IPatientService patientService,ISessionContext sessionContext,IBloodTypeService bloodTypeService)
        {
            _patientService = patientService;
            _personService = personService;
            _sessionContext = sessionContext;
            _bloodTypeService = bloodTypeService;
            InitializeComponent();
            dgvPatient.CellPainting += dgvPatient_CellPainting;
            this.DoubleBuffered = true;
            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += _searchTimer_Tick;
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
                        await _updateGridRow(row,e.Patient);
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
            AddPatientForm.OnPatientReActived += AddPatientForm_OnPatientReActived;
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
        private async void tbSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (_allPatients == null || !_allPatients.Any()) return;

            string searchTarget = tbSearchBox.Text.Trim();

            if (dgvPatient.Rows.Count == 0)
            {
                _searchTimer.Stop();                
                _searchTimer.Start();
            }
            else
            {
                switch (_searchType)
                {
                    case enSearchType.FullName:
                        dgvPatient.DataSource = string.IsNullOrEmpty(searchTarget) ? _allPatients
                            : _allPatients.Where(p => p.FullName.Contains(searchTarget)).ToList();
                        break;
                    case enSearchType.PhoneNumber:
                        dgvPatient.DataSource = string.IsNullOrEmpty(searchTarget)
                    ? _allPatients
                    : _allPatients.Where(p => p.PhoneNumber.Contains(searchTarget)).ToList();
                        break;
                    default:
                        break;
                }
            }
        }
        private async void _searchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();

            string searchTarget = tbSearchBox.Text.Trim();

            if (string.IsNullOrEmpty(searchTarget))
            {
                _bindPatientsToGrid(_allPatients);
                return;
            }

            _handelDGVIndecator(true);
            try
            {
                List<clsPatientView> results = new List<clsPatientView>();
                switch (_searchType)
                {
                    case enSearchType.FullName:
                        results = (List<clsPatientView>) await _patientService.SearchByFullNameAsync(searchTarget);
                        break;
                    case enSearchType.PhoneNumber:
                        results = (List < clsPatientView >) await _patientService.SearchByPhoneNumberAsync(searchTarget);
                        break;
                    default:
                        results = _allPatients;
                        break;
                }
                _bindPatientsToGrid(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _handelDGVIndecator(false);
            }
        }

        //  Helper Methods
        private async Task _getAllPatientsData()
        {
            //TODO : After create Appointments see how it works  
            try
            {
                _allPatients = (List<clsPatientView>)await _patientService.GetAllPatientDetailsOnTodaysAppointmentsAsync();
                if (_allPatients.Count < 10)
                {
                    List<clsPatientView> moreDataList = new List<clsPatientView>();
                    moreDataList = (List<clsPatientView>)await _patientService.GetAllPatientDetailsAsync();
                    _allPatients.AddRange(moreDataList);
                }
                _allPatients = (List<clsPatientView>)await _patientService.GetAllPatientDetailsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات المرضى\n" + ex.Message,
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _bindPatientsToGrid(List<clsPatientView> patients)
        {
            if (patients == null) return;
            dgvPatient.DataSource = null;
            dgvPatient.DataSource = patients;
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
            if (dgvPatient.Columns["IsDeleted"] != null) dgvPatient.Columns["IsDeleted"].HeaderText = "الحـالة";
        }
        private async Task _updateGridRow(DataGridViewRow row, clsPatient Patient)
        {
            row.Cells["FullName"].Value = Patient.PersonInfo.FullName;

            if (Patient.PersonInfo.DateOfBirth != null)
            {
                row.Cells["Age"].Value = clsUtilities.CalculateAge((DateTime)Patient.PersonInfo.DateOfBirth).ToString();
            }

            if (Patient.PersonInfo.Gender == DentalClinic_CoreTier.myEnums.enGenderTypes.M)
            {
                row.Cells["Gender"].Value = "Male";
            }
            else
            {
                row.Cells["Gender"].Value = "Female";
            }

            if (Patient.PersonInfo.PhoneNumber != null)
            {
                row.Cells["PhoneNumber"].Value = Patient.PersonInfo.PhoneNumber;
            }
            else
            {
                row.Cells["PhoneNumber"].Value = "N/A";
            }

            if (Patient.BloodType_ID != null)
            {
                clsBloodType bloodType = await _bloodTypeService.GetByIdAsync((int) Patient.BloodType_ID);
                row.Cells["BloodTypeName"].Value = bloodType.BloodTypeName;
            }
            else
            {
                row.Cells["BloodTypeName"].Value = "N/A";
            }
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

        private void dgvPatient_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvPatient.Columns[e.ColumnIndex].Name != "IsDeleted") return;

            e.PaintBackground(e.ClipBounds, true);

            bool isDeleted = (bool)(e.Value ?? false);
            string text = isDeleted ? "محذوف" : "نشط";
            Color fill = isDeleted ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);

            int badgeW = 80, badgeH = 26;
            Rectangle badge = new Rectangle(
                e.CellBounds.X + (e.CellBounds.Width - badgeW) / 2,
                e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2,
                badgeW, badgeH);

            using (var brush = new SolidBrush(fill))
            using (var path = _getRoundedRect(badge, 12))
                e.Graphics.FillPath(brush, path);

            using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString(text, font, Brushes.White, badge, sf);

            e.Handled = true;
        }

        private System.Drawing.Drawing2D.GraphicsPath _getRoundedRect(Rectangle r, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
