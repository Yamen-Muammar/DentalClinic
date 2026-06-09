using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsDoctor
    {
        public int DoctorID { get; set; }
        public int Staff_ID { get; set; }
        public string Specialization { get; set; } = null;
        public string LicenseNumber { get; set; } = null;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public int? UpdatedBy_ID { get; set; } = null;

    }
}
