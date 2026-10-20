using System;
using System.Windows.Forms;
using DentalClinic_CoreTier.ViewModels;

namespace DentistClinic_PresentationTier.Controls.ModelsControls.PatientControls
{
    public partial class ctrlPatientCard : UserControl
    {
        public ctrlPatientCard()
        {
            InitializeComponent();
        }

        public void LoadPatientData(clsPatientView patientView)
        {
            if (patientView == null) return;

            lblFullName.Text = patientView.FullName;
            lblPhone.Text = string.IsNullOrEmpty(patientView.PhoneNumber) ? "غير متوفر" : patientView.PhoneNumber;
            lblGender.Text = patientView.Gender == "M" || patientView.Gender == "Male" ? "ذكر" : "أنثى";
            lblAge.Text = patientView.Age;
            lblBlood.Text = string.IsNullOrEmpty(patientView.BloodTypeName) ? "غير متوفر" : patientView.BloodTypeName;
        }
    }
}
