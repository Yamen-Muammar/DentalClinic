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
        public DateTime? HireDate { get; set; } = null;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get;  }
        public DateTime? UpdatedAt { get;} = null;
        public int? UpdatedBy_ID { get; set; } = null;

        public DateTime? DeletedAt { get;} = null;
        public int? DeletedBy_ID { get; set; } = null;
        public bool IsDeleted { get; set; }


    }
}
