using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls
{
    public partial class ctrlPersonInformation : UserControl
    {
        private readonly IPersonService _personService;
        public clsPerson PersonInformation { get; set; }

        private int _paasedPersonID;

        public ctrlPersonInformation(IPersonService personService)
        {
            InitializeComponent();
            _personService = personService;
        }

        private async void ctrlPersonInformation_Load(object sender, EventArgs e)
        {
            if (_paasedPersonID <= 0)
            {
                MessageBox.Show("رقم تعريفي للشخص غير صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _handleNoDataPanel(true);
                return;
            }

            await Task.Delay(200);

            if (await _setPersonInformation(_paasedPersonID))
            {
                _buildUI();
                _handleNoDataPanel(false);
            }
            else
            {
                _handleNoDataPanel(true);
            }
            _handleProgressIndicator(false);
        }

        public Task SetPersonID(int personID)
        {
            _paasedPersonID = personID;
            return Task.CompletedTask;
        }

        // Helper Methods
        private async Task<bool> _setPersonInformation(int personID)
        {
            PersonInformation = await _getPersonInformationByPersonIDAsync(personID);
            if (PersonInformation == null)
            {
                MessageBox.Show("الشخص غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private async Task<clsPerson> _getPersonInformationByPersonIDAsync(int personID)
        {
            if (personID <= 0)
            {
                MessageBox.Show("لايوجد رقم تعريفي للشخص للبحث عنه", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try
            {
                return await _personService.GetByIdAsync(personID);
            }
            catch (Exception)
            {
                MessageBox.Show("حدث خطأ أثناء جلب معلومات الشخص", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // UI Building Methods
        private void _buildUI()
        {
            _fillUIwithPersonInformation();
        }

        private void _fillUIwithPersonInformation()
        {
            lblFullName.Text       = PersonInformation.FullName;
            lblDateOfBirth.Text    = PersonInformation.DateOfBirth.HasValue ? PersonInformation.DateOfBirth.Value.ToString("d") : "N/A";
            lblNationalNo.Text     = PersonInformation.NationalNo ?? "N/A";
            lblGender.Text         = clsUtilities.GetPersonGenderText(PersonInformation.Gender);
            lblLastUpdateDate.Text = PersonInformation.UpdatedAt.HasValue ? PersonInformation.UpdatedAt.Value.ToString("d") : "N/A";
            lblCreatedDate.Text    = PersonInformation.CreatedAt.ToString("d");

            flpPhoneNumbers.Controls.Clear();
            var lblPhone = new Label
            {
                Text      = PersonInformation.PhoneNumber ?? "N/A",
                Font      = new Font("Simplified Arabic Fixed", 13F, FontStyle.Bold, GraphicsUnit.Point, 178),
                ForeColor = Color.White,
                AutoSize  = true,
                Padding   = new Padding(10),
            };
            flpPhoneNumbers.Controls.Add(lblPhone);
        }

        private void _mainContentControlerVisabiltyStatus(bool enable)
        {
            MainContainerControl.Visible = enable;
            MainContainerControl.Enabled = enable;
        }

        private void btnEditePatientInfo_Click(object sender, EventArgs e)
        {
            // TODO : CALL Edite Patient Form After You Have Done it.
        }

        private void _handleProgressIndicator(bool enable)
        {
            if (enable)
            {
                guna2WinProgressIndicator1.Start();
            }
            else
            {
                guna2WinProgressIndicator1.Stop();
                indecatorPanel.Visible = enable;
            }
        }

        private void _handleNoDataPanel(bool enable)
        {
            noPersonInfoPanel.Visible = enable;
        }
    }
}
