using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Guna.UI2.WinForms;
using Microsoft.SqlServer.Server;

namespace DentistClinic_PresentationTier.Controls.ModelsControls.PersonControls
{
    public partial class ctrlPersonInformation : UserControl
    {
        private IPersonService _personService;
        public clsPerson PersonInformation { get; set; }
        public List<clsPhoneNumber> PersonPhoneNumbers { get; set; }

        private int _paasedPersonID;
        public ctrlPersonInformation(IPersonService personService)
        {
            InitializeComponent();
            this._personService = personService;
        }
        private async void ctrlPersonInformation_Load(object sender, EventArgs e)
        {
            Task.Run(() => _handleProgressIndicator(true));
            await _setPersonInformation(_paasedPersonID);
            _buildUI();
            _handleProgressIndicator(false);
        }
        public async Task SetPersonID(int personID)
        {
            _paasedPersonID =personID;
        }

        //Helper Methods
        private async Task _setPersonInformation(int personID)
        {
            PersonInformation = await _getPersonInformationByPersonIDAsync(personID);
            if (PersonInformation == null)
            {
                MessageBox.Show("الشخص غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mainContentControlerVisabiltyStatus(false);
            }
            PersonPhoneNumbers= await _getPersonPhoneNumbers();
        }
        private async Task<clsPerson> _getPersonInformationByPersonIDAsync(int personID)
        {
            if (personID <= 0)
            {
                MessageBox.Show("لايوجد رقم تعريفي للشخص للبحث عنه","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
            clsPerson returnedPerson = null;
            try
            {
                 returnedPerson = await _personService.GetByIdAsync(personID);

            }
            catch (Exception)
            {

               MessageBox.Show("حدث خطأ أثناء جلب معلومات الشخص", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return returnedPerson;
        }
        private async Task<List<clsPhoneNumber>> _getPersonPhoneNumbers()
        {
            List<clsPhoneNumber> collection = new List<clsPhoneNumber>();
            try
            {
                collection = (List<clsPhoneNumber>)await _personService.GetPhoneNumbersByPersonIdAsync(PersonInformation.PersonID);
                if (collection.Count <= 0)
                {
                    MessageBox.Show("لايوجد أرقام هاتف لهذا الشخص", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("حدث خطأ أثناء جلب أرقام الهاتف لهذا الشخص", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return collection;
        }

        // UI Building Methods
        private void _buildUI()
        {
            _fillUIwithPersonInformation();
            _createPhoneNumbersShadowPanel();
        }
        private void _fillUIwithPersonInformation()
        {
            lblFullName.Text = PersonInformation.FullName;
            lblDateOfBirth.Text = PersonInformation.DateOfBirth.HasValue ? PersonInformation.DateOfBirth.Value.ToString("d"): "N/A";
            lblNationalNo.Text = PersonInformation.NationalNo??"N/A";
            lblGender.Text = clsUtilities.GetPersonGenderText(PersonInformation.Gender);
            lblLastUpdateDate.Text = PersonInformation.UpdatedAt.HasValue ? PersonInformation.UpdatedAt.Value.ToString("d") : "N/A";
            lblCreatedDate.Text = PersonInformation.CreatedAt.ToString("d");
        }       
        private void _createPhoneNumbersShadowPanel()
        {
            foreach (var item in PersonPhoneNumbers)
            {
                Guna2ShadowPanel shadowPanel = new Guna2ShadowPanel();

                shadowPanel.SuspendLayout();
                _buildPhoneNumbersShadowPanel(shadowPanel, item);
                shadowPanel.ResumeLayout(false);
                shadowPanel.PerformLayout();
            }
        }
        private void _buildPhoneNumbersShadowPanel(Guna2ShadowPanel guna2ShadowPanel1,clsPhoneNumber phoneNumber)
        {
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Simplified Arabic Fixed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(348, 34);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(154, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "رقم الهاتف :";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Simplified Arabic Fixed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(177, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 27);
            this.label14.TabIndex = 0;
            this.label14.Text = phoneNumber.Number;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Simplified Arabic Fixed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(300, 70);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(202, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "هل الرقم رئيسي :";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Simplified Arabic Fixed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(228, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 27);
            this.label16.TabIndex = 0;
            this.label16.Text = phoneNumber.IsPrimary? "نعم" : "لا";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            guna2ShadowPanel1.Controls.Add(this.label15);
            guna2ShadowPanel1.Controls.Add(this.label12);
            guna2ShadowPanel1.Controls.Add(this.label16);
            guna2ShadowPanel1.Controls.Add(this.label14);
            guna2ShadowPanel1.FillColor = System.Drawing.Color.SlateGray;
            guna2ShadowPanel1.Location = new System.Drawing.Point(13, 13);
            guna2ShadowPanel1.Margin = new System.Windows.Forms.Padding(13, 13, 0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            guna2ShadowPanel1.ShadowShift = 10;
            guna2ShadowPanel1.Size = new System.Drawing.Size(525, 130);
            guna2ShadowPanel1.TabIndex = 0;


            this.flpPhoneNumbers.Controls.Add(guna2ShadowPanel1);
        }
       
        private void _mainContentControlerVisabiltyStatus(bool enable)
        {
            MainContainerControl.Visible  = enable;
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
                this.guna2WinProgressIndicator1.Start();
            }
            else
            {
                this.guna2WinProgressIndicator1.Stop();
                this.guna2WinProgressIndicator1.Dispose();
                this.Controls.Remove(this.indecatorPanel);
            }
        }
    }
}
