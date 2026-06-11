using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.ViewModels
{
    public class clsAppointmentsDetails
    {
        public clsAppointment Appointment { get; set; }
        public int MedicalFileID { get; set; }
        public int PatientID { get; set; }
        public string PatientFullName { get; set; }
        public string PatientPhone { get; set; } = null;
        public string DoctorFullName { get; set; }
    }
}
