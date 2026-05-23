using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsAppointment
    {
        public int AppointmentID { get; set; }
        public int Problem_ID { get; set; }
        public int Doctor_ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } // Scheduled | Confirmed | Completed | Cancelled | NoShow
        public string Cause { get; set; }
        public int? Payment_ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }

        //// Navigation
        //public Problem Problem { get; set; }
        //public Doctor Doctor { get; set; }
        //public Payment Payment { get; set; }
        //public Staff UpdatedBy { get; set; }
    }
}
