using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentistClinic_PresentationTier
{
    public class WinFormsSessionContext : ISessionContext
    {
        public int StaffID { get; private set; }
        public string UserName { get; private set; }
        public long PermissionCode { get; private set; }
        public int RoleID { get; private set; }
        public clsStaff Staff { get; private set; }

        public void Set(clsStaff staff)
        {
            StaffID = staff.StaffID;
            UserName = staff.UserName;
            PermissionCode = staff.Role.RolePermissionCode;
            RoleID = staff.Role_ID;
            Staff = staff;
        }

        public void Clear()
        {
            StaffID = 0;
            UserName = null;
            Staff = null;
            PermissionCode = 0;
            RoleID = 0;
        }
    }
}
