using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public long RolePermissionCode { get; set; }

        // Navigation
        //public ICollection<Staff> Staff { get; set; } = [];
    }
}
