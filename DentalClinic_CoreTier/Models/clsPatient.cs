using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsPatient
    {
        public int PatientID { get; set; }
        public int Person_ID { get; set; }
        public int? BloodType_ID { get; set; }
        public string HealthProblems { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }

    }
}
