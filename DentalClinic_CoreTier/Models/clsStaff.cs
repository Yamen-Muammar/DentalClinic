using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsStaff
    {
        public int StaffID { get; set; }
        public int Person_ID { get; set; }
        public int Role_ID { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }

        // Navigation
        //public Person Person { get; set; } = null!;
        //public Role Role { get; set; } = null!;
        //public Staff? UpdatedBy { get; set; }
        //public Doctor? Doctor { get; set; }

        //// Reverse nav — records this staff member has touched
        //public ICollection<Payment> PaymentsCreated { get; set; } = [];
        //public ICollection<Payment> PaymentsUpdated { get; set; } = [];
    }
}
