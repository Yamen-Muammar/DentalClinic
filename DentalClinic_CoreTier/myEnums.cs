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
            ManageRoles = 32,
            ManageReports = 64,   
            Dashboard = 128,
        }

        public enum enRoles
        {
            Admin=1,
            Doctor=2,            
        }

        public enum enAppointmentStatus
        {
            Scheduled = 1,
            Confirmed = 2,
            Completed = 3,
            Cancelled = 4,
            NoShow= 5
        }

        public enum enGenderTypes
        {
            Male = 1,
            Female = 2
        }

        public enum enProblemStatus
        {
            New, InProgress,Done,Closed
        }
        
    }    
}
