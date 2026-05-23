using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsBloodType
    {
        public int BloodTypeID { get; set; }
        public string BloodTypeName { get; set; }

        // Navigation
        //public ICollection<Patient> Patients { get; set; } = [];
    }
}
