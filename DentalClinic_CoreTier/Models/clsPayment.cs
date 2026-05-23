using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsPayment
    {
        public int PaymentID { get; set; }
        public int PaymentType_ID { get; set; }
        public int PaymentDestination_ID { get; set; }
        public int? Appointment_ID { get; set; }
        public int CreatedBy_ID { get; set; }
        public bool IsApproved { get; set; }
        public string SenderNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }

        // Navigation
        public clsPaymentType PaymentType { get; set; }
        public clsPaymentDestination PaymentDestination { get; set; }
        public clsAppointment Appointment { get; set; }
        public clsStaff CreatedBy { get; set; }
        public clsStaff UpdatedBy { get; set; }
    }
}
