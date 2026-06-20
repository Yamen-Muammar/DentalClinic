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
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    public partial class frmAddOrEditePatient : Form
    {
        public class MyEventArgs : EventArgs
        {
            public clsPatient Patient { get;private set; }

            public MyEventArgs(clsPatient addedPatient)
            {
                Patient = addedPatient;
            }
        }

        public event EventHandler<MyEventArgs> OnPatientDone;

        protected void TriggerPatientDoneEvent(clsPatient patient)
        {
            OnPatientDone?.Invoke(this, new MyEventArgs(patient));
        } 

        private List<clsPhoneNumber> _phoneNumbersList = new List<clsPhoneNumber>();
        private List<clsBloodType> BloodTypesList { get; set; }

        private DateTime _FirstDateOnPicker;

        private IBloodTypeService _bloodTypeService;
        private IPatientService _patientService;
        public enum enMode
        {
            add = 1,
            Edite = 2,
        }
        private enMode _formMode;
      
        public frmAddOrEditePatient(IBloodTypeService bloodTypeService, IPatientService patientService)
        {
            _bloodTypeService = bloodTypeService;
            _patientService = patientService;
            InitializeComponent();
            _FirstDateOnPicker = Convert.ToDateTime(dtpDateOfBirth.Text);
            _formMode = enMode.add;
        }
        public async Task SetPatientID(int patientID)
        {
            if (patientID <= 0)
            {
                this.Close();
                return;
            }

            try
            {
                clsPatient patient = await _patientService.GetByIdAsync(patientID);
                if (patient == null)
                {
                    this.Close();
                    MessageBox.Show("لايوجد مريض مخزن في قاعدة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO : CREATE THE FILL INDORMATION TO UI
        } 
        private async void frmAddOrEditePatient_Load(object sender, EventArgs e)
        {
            await _buildBloodTypeComboBox();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_formMode == enMode.add)
            {
                clsPatient newPatient = _preparePatientObj();

                if (!_isPatientInfoValid(newPatient.PersonInfo))
                {
                    return;
                }

                try
                {
                    newPatient.PatientID = (int)await _patientService.InsertAsync(newPatient);
                    if (newPatient.PatientID == 0)
                    {
                        MessageBox.Show("لم يتم حفـظ المريض", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        TriggerPatientDoneEvent(newPatient);
                        MessageBox.Show(" تم حفـظ المريض بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                return;
            }

            if (_formMode == enMode.Edite)
            {

            }
        }
        private void btnAddPhoneNumber_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPhoneNumber.Text))
            {
                return;
            }

            if (_isNumberExists(tbPhoneNumber.Text))
            {
                MessageBox.Show("هذا الرقم موجود بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            clsPhoneNumber phoneNumber = new clsPhoneNumber
            {
                Number = tbPhoneNumber.Text,
                IsActive = true,
                IsPrimary = chbIsNumberPrimary.Checked
                ,
                CreatedAt = DateTime.Now
            };

            dgvPhoneNumbers.Rows.Add(phoneNumber.Number, phoneNumber.IsPrimary);

            _phoneNumbersList.Add(phoneNumber);

            tbPhoneNumber.Text = string.Empty;
            chbIsNumberPrimary.Checked = false;
        }
        private void tbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnAddPhoneNumber.Enabled = !string.IsNullOrEmpty(tbPhoneNumber.Text);
        }
        private void dgvPhoneNumbers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dgvPhoneNumbers.Rows.RemoveAt(e.RowIndex);
                _phoneNumbersList.RemoveAt(e.RowIndex);
            }
        }
        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        //Helper Methods
        private clsPatient _preparePatientObj()
        {
            clsPatient patient = new clsPatient();
            patient.HealthProblems = tbHealthProblems.Text;
            patient.BloodType_ID = (cbBloodType.SelectedIndex != 0) ? cbBloodType.SelectedIndex : (int?)null;

            clsPerson newPerson = new clsPerson
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                PhoneNumbers = _phoneNumbersList,
            };
            if (string.IsNullOrEmpty(tbSecondName.Text)) 
            {
                newPerson.SecondName = null;
            }
            else
            {
                newPerson.SecondName = tbSecondName.Text;
            }

            if (string.IsNullOrEmpty(tbNationalNo.Text))
            {
                newPerson.NationalNo = null;
            }
            else
            {
                newPerson.NationalNo = tbNationalNo.Text;
            }

            if (newPerson.DateOfBirth == _FirstDateOnPicker)
            {
                newPerson.DateOfBirth = null;
            }

            if (cbGender.SelectedIndex == 1)
            {
                newPerson.Gender = myEnums.enGenderTypes.M;
            }
            else if (cbGender.SelectedIndex == 2)
            {
                newPerson.Gender = myEnums.enGenderTypes.F;
            }

            patient.PersonInfo = newPerson;

            return patient;
        }
        private async Task _getBloodTypes()
        {
            try
            {
                BloodTypesList = (List<clsBloodType>)(await _bloodTypeService.GetAllAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطـأ في جلب بيانات فصيلة الدم", "خطـأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task _buildBloodTypeComboBox()
        {
            await _getBloodTypes();
            if (BloodTypesList.Count <= 0)
            {
                return;
            }

            cbBloodType.Items.Add("N/A");
            foreach (var item in BloodTypesList)
            {
                cbBloodType.Items.Add(item.BloodTypeName);
            }

            cbBloodType.SelectedIndex = 0;
        }
        private bool _isNumberExists(string newNumber)
        {
            if (_phoneNumbersList.Count <=0)
            {
                return false;
            }
            var  findedNumber = _phoneNumbersList.FirstOrDefault(n => n.Number == newNumber);
            return (findedNumber != null);
        }
        private bool _isPatientInfoValid(clsPerson person)
        {
            if (person == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                tbFirstName.Focus();
                MessageBox.Show("يجب ادخـال الإسم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                tbLastName.Focus();
                MessageBox.Show("يجب إدخال اسم العائلة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!Enum.IsDefined(typeof(myEnums.enGenderTypes), person.Gender))
            {
                cbGender.Focus();
                MessageBox.Show("يجب تحديد جنس المريض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            if (person.DateOfBirth != null && person.DateOfBirth >= DateTime.Today)
            {
                dtpDateOfBirth.Focus();
                MessageBox.Show("تاريخ الميلاد يجب ان يكون في الماضي", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;

            } 

            if (person.PhoneNumbers != null && person.PhoneNumbers.Count == 0)
            {        
                tbPhoneNumber.Focus();
                if (person.PhoneNumbers.Any(p => string.IsNullOrWhiteSpace(p.Number)))
                {
                    MessageBox.Show("يجب ان يكون هناك رقم على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (person.PhoneNumbers.Count(p => p.IsPrimary) > 1)
                {
                    MessageBox.Show("فقط رقم واحد يكون رئيسي", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                MessageBox.Show("يجب ان يكون هناك رقم على الاقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}
