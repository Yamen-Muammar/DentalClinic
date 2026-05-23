using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsMedicalFile
    {
        public int MedicalFileID { get; set; }
        public int Patient_ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }
        public string GeneralAllergies { get; set; }

        // Navigation
        public clsPatient Patient { get; set; } 
        public clsStaff UpdatedBy { get; set; }
        public ICollection<clsProblem> Problems { get; set; }
    }
}
