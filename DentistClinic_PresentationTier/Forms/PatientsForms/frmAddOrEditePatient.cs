using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier.Forms.PatientsForms
{
    public partial class frmAddOrEditePatient : Form
    {
        public class MyEventArgs : EventArgs
        {
            public clsPatient Patient { get; private set; }
            public MyEventArgs(clsPatient addedPatient)
            {
                Patient = addedPatient;
            }
        }
    
        public event EventHandler<MyEventArgs> OnPatientDone;
        public event EventHandler<MyEventArgs> OnPatientReActived;

        protected void TriggerPatientDoneEvent(clsPatient patient)
        {
            OnPatientDone?.Invoke(this, new MyEventArgs(patient));
        }
        protected void TriggerPatientReActivedEvent(clsPatient patient)
        {
            OnPatientReActived?.Invoke(this, new MyEventArgs(patient));
        }



        private bool _doesRegetInformationAfterSearchAnswered = false;
        private clsPatient PatientInfo { get; set; }
        public clsMedicalFile MedicalFile { get; set; }

        private List<clsBloodType> BloodTypesList { get; set; }

        private DateTime _FirstDateOnPicker = DateTime.Today;

        private readonly IBloodTypeService _bloodTypeService;
        private readonly IPatientService _patientService;
        private readonly ISessionContext _sessionContext;
        private readonly IMedicalFileService _medicalFileService;
        private readonly IPersonService _personService;
        public enum enMode
        {
            add   = 1,
            Edite = 2,
        }
        private enMode _formMode;

        public frmAddOrEditePatient(ISessionContext sessionContext, IBloodTypeService bloodTypeService, IPatientService patientService,IMedicalFileService medicalFileService,IPersonService personService)
        {
            _sessionContext = sessionContext;
            _bloodTypeService = bloodTypeService;
            _patientService   = patientService;            
            _medicalFileService = medicalFileService;
            _personService = personService;
            InitializeComponent();
            _formMode = enMode.add;
        }

        public async Task SetPatientID(int patientID)
        {

            if (patientID <= 0)
            {
                this.Close();
                return;
            }

            _formMode = enMode.Edite;

            try
            {
                await _buildBloodTypeComboBox();
                PatientInfo = await _patientService.GetByIdAsync(patientID);

                if (PatientInfo == null)
                {
                    this.Close();
                    MessageBox.Show("لايوجد مريض مخزن في قاعدة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MedicalFile = await _medicalFileService.GetMedicalFilesByPatientIDAsync(patientID);
               if (MedicalFile == null)
               {
                     this.Close();
                    MessageBox.Show("لايوجد ملف صحي مخزن في قاعدة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
               }

               if (PatientInfo.PersonInfo != null && PatientInfo.PersonInfo.IsDeleted)
               {
                   if (MessageBox.Show("ملف المريض غير نشـط ,هل تريد إعادة تنشيطه؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    == DialogResult.Yes)
                   {
                       PatientInfo.PersonInfo.IsDeleted = false;
                       _personService.UpdateAsync(PatientInfo.PersonInfo,_sessionContext.StaffID);
                       TriggerPatientReActivedEvent(PatientInfo);
                   }
                   else
                   {
                       btnSave.Enabled=false;
                   }                   
               }                
                _doesRegetInformationAfterSearchAnswered = true;
            }
            catch (Exception ex)
            {
                this.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frmAddOrEditePatient_Load(object sender, EventArgs e)
        {
            lblCharactersCount.Text = tbHealthProblems.Text.Length.ToString() + "/" + tbHealthProblems.MaxLength;
            generateYearsComboBox();
            if (_formMode == enMode.Edite)
            {
                gbMainBox.Text = "تعديل بيانات المريض";
                _fillUIWithPatientInformation(PatientInfo);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (tbGeneralAllergies.Text == string.Empty || tbHealthProblems.Text == string.Empty)
            {
                if (MessageBox.Show("هل انت متاكد ان جميع البيانات مدخلة خصوصا المشاكل الصحية و الحساسية؟","تحذير",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            if (_formMode == enMode.add)
            {
                clsPatient newPatient = _preparePatientObj();

                if (!_isPatientInfoValid(newPatient.PersonInfo))
                    return;

                try
                {
                    newPatient.PatientID = (int)await _patientService.InsertAsync(newPatient,tbGeneralAllergies.Text);
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
                PatientInfo = _preparePatientObj(PatientInfo);
                
                if (!_isPatientInfoValid(PatientInfo.PersonInfo))
                    return;


                try
                {
                    if (await _patientService.UpdatePatientWithPersonAndMedicalFileAsync(PatientInfo,MedicalFile, _sessionContext.StaffID))
                    {
                        TriggerPatientDoneEvent(PatientInfo);
                        MessageBox.Show(" تم حفـظ المريض بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("لم يتم حفـظ المريض", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    btnSave.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
            }
        }


        // Helper Methods
        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

     
        private clsPatient _preparePatientObj() //for insertion
        {
            clsPatient patient = new clsPatient();
            patient.HealthProblems = tbHealthProblems.Text.Trim();
            patient.BloodType_ID   = (cbBloodType.SelectedIndex != 0) ? cbBloodType.SelectedIndex : (int?)null;

            clsPerson newPerson = new clsPerson
            {
                FirstName   = tbFirstName.Text.Trim(),
                LastName    = tbLastName.Text.Trim(),
                DateOfBirth = _getDateOfBirth(),
                PhoneNumber = tbPhoneNumber.Text.Trim(),
            };

            newPerson.SecondName = string.IsNullOrEmpty(tbSecondName.Text) ? null : tbSecondName.Text.Trim();
            newPerson.NationalNo = string.IsNullOrEmpty(tbNationalNo.Text) ? null : tbNationalNo.Text.Trim();

            if (newPerson.DateOfBirth == _FirstDateOnPicker)
                newPerson.DateOfBirth = null;

            if (cbGender.SelectedIndex == 1)
                newPerson.Gender = myEnums.enGenderTypes.M;
            else if (cbGender.SelectedIndex == 2)
                newPerson.Gender = myEnums.enGenderTypes.F;

            patient.PersonInfo = newPerson;
            return patient;
        }

  
        private clsPatient _preparePatientObj(clsPatient oldPatientInfo)// for edite
        {
            clsPatient patient  = new clsPatient();
            patient.PatientID   = oldPatientInfo.PatientID;
            patient.Person_ID   = oldPatientInfo.Person_ID;
            patient.HealthProblems = tbHealthProblems.Text.Trim();
            patient.BloodType_ID   = (cbBloodType.SelectedIndex != 0) ? cbBloodType.SelectedIndex : (int?)null;

            clsPerson newPerson = new clsPerson
            {
                PersonID    = oldPatientInfo.PersonInfo.PersonID,
                FirstName   = tbFirstName.Text.Trim(),
                LastName    = tbLastName.Text.Trim(),
                DateOfBirth = _getDateOfBirth(),
                PhoneNumber = tbPhoneNumber.Text.Trim(),
            };

            newPerson.SecondName = string.IsNullOrEmpty(tbSecondName.Text) ? null : tbSecondName.Text.Trim();
            newPerson.NationalNo = string.IsNullOrEmpty(tbNationalNo.Text) ? null : tbNationalNo.Text.Trim();

            if (newPerson.DateOfBirth == _FirstDateOnPicker)
                newPerson.DateOfBirth = null;

            if (cbGender.SelectedIndex == 1)
                newPerson.Gender = myEnums.enGenderTypes.M;
            else if (cbGender.SelectedIndex == 2)
                newPerson.Gender = myEnums.enGenderTypes.F;

            patient.PersonInfo = newPerson;

            MedicalFile.GeneralAllergies = tbGeneralAllergies.Text.Trim();
           
            return patient;
        }
    
        private async Task _getBloodTypes()
        {
            try
            {
                BloodTypesList = (List<clsBloodType>)(await _bloodTypeService.GetAllAsync());
            }
            catch (Exception)
            {
                MessageBox.Show("خطـأ في جلب بيانات فصيلة الدم", "خطـأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task _buildBloodTypeComboBox()
        {
            await _getBloodTypes();
            if (BloodTypesList.Count <= 0)
                return;

            cbBloodType.Items.Add("N/A");
            foreach (var item in BloodTypesList)
                cbBloodType.Items.Add(item.BloodTypeName);

            cbBloodType.SelectedIndex = 0;
        }

 
        private bool _isPatientInfoValid(clsPerson person)
        {
            if (person == null)
                return false;

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
                cbYear.Focus();
                MessageBox.Show("تاريخ الميلاد يجب ان يكون في الماضي", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.PhoneNumber))
            {
                tbPhoneNumber.Focus();
                MessageBox.Show("يجب إدخال رقم الهاتف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

  
        private void _fillUIWithPatientInformation(clsPatient patient)
        {
            tbFirstName.Text = patient.PersonInfo.FirstName;
            if (patient.PersonInfo.SecondName != null)
                tbSecondName.Text = patient.PersonInfo.SecondName;

            tbLastName.Text = patient.PersonInfo.LastName;

            if (patient.PersonInfo.NationalNo != null)
                tbNationalNo.Text = patient.PersonInfo.NationalNo;

            if (patient.PersonInfo.DateOfBirth != null)
                _fillDateOfBirth((DateTime)patient.PersonInfo.DateOfBirth);

            if (patient.PersonInfo.Gender == myEnums.enGenderTypes.M)
                cbGender.SelectedIndex = 1;
            else
                cbGender.SelectedIndex = 2;

            tbPhoneNumber.Text = patient.PersonInfo.PhoneNumber ?? string.Empty;

            if (patient.BloodType_ID != null)
                cbBloodType.SelectedIndex = (int)patient.BloodType_ID;

            tbHealthProblems.Text = patient.HealthProblems;
            tbGeneralAllergies.Text = MedicalFile.GeneralAllergies;
            
           
        }

        private void tbHealthProblems_TextChanged(object sender, EventArgs e)
        {
            lblCharactersCount.Text = tbHealthProblems.Text.Length.ToString() + "/" + tbHealthProblems.MaxLength;
        }

        private async void FullNameCheck(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbLastName.Text))
            {
                return;
            }

            if (_doesRegetInformationAfterSearchAnswered)
            {
                return;
            }

            string fullName = string.Join(" ", tbFirstName.Text.Trim(),tbLastName.Text.Trim());

            List<clsPatient> checkedPatientList = (List<clsPatient>)await _patientService.SearchByFullNameAsync(fullName);

            if (checkedPatientList.Count > 0)
            {
                if(MessageBox.Show("المريض مسجل مسبقاً ,هل تريد جلب البيانات", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    == DialogResult.Yes)
                {
                    await SetPatientID(checkedPatientList[0].PatientID);
                    _fillUIWithPatientInformation(PatientInfo);
                }
                _doesRegetInformationAfterSearchAnswered = true;
            }
        }

        private DateTime _getDateOfBirth()
        {
            if (cbDay.SelectedIndex==0 || cbMonth.SelectedIndex == 0 || cbYear.SelectedIndex == 0)
            {
                return DateTime.Today; // means there is no birth day
            }
            string date = cbDay.SelectedItem.ToString()+"/"+cbMonth.SelectedItem.ToString() + "/" +cbYear.SelectedItem.ToString();
            return Convert.ToDateTime(date);
        }

        private void generateYearsComboBox()
        {
            List<int> years = Enumerable.Range(1920, 116).ToList();
            foreach (var item in years)
            {
                cbYear.Items.Add(item.ToString());
            }
        }

        private void _fillDateOfBirth(DateTime dateOfBirth)
        {
            string year = dateOfBirth.Year.ToString();
            cbYear.SelectedItem =year;

            if (dateOfBirth.Month <= 9)
            {
                string month = "0"+dateOfBirth.Month.ToString();
                cbMonth.SelectedItem = month;
            }
            else
            {
                cbMonth.SelectedItem = dateOfBirth.Month.ToString();
            }

            if (dateOfBirth.Day <= 9)
            {
                string day = "0" + dateOfBirth.Day.ToString();
                cbDay.SelectedItem = day;
            }
            else
            {
                cbDay.SelectedItem = dateOfBirth.Day.ToString();
            }
        }
    }
}
