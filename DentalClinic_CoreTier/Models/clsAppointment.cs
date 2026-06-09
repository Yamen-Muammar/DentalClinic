using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace DentalClinic_CoreTier.Models
{
    public class clsAppointment
    {
        public int AppointmentID { get; set; }
        public int Problem_ID { get; set; }
        public int Doctor_ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public myEnums.enAppointmentStatus Status { get; set; } = myEnums.enAppointmentStatus.Scheduled;
        public string Cause { get; set; } = null;
        public int? Payment_ID { get; set; } = null;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public int? UpdatedBy_ID { get; set; } = null;

    }
}
