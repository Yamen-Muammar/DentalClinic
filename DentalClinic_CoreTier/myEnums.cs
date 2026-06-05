using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_CoreTier
{
    public class myEnums
    {
        public enum enPermission : long
        {
            ManagePatients = 1,
            ManageAppointments = 2,
            ManagePayments = 4,
            ViewReports = 8,
            ManageStaff = 16,
            ManageRoles = 32
        }

        public enum enRoles
        {
            Admin=1,
            Doctor=2,            
        }
    }    
}
