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
        public clsPerson Person { get; private set; }
        public long PermissionCode { get; private set; }
        public int RoleID { get; private set; }

        public clsRole Role { get; private set; }

        public void Set(clsStaff staff, clsRole role,clsPerson person)
        {
            StaffID = staff.StaffID;
            UserName = staff.UserName;
            PermissionCode = role.RolePermissionCode;
            RoleID = role.RoleID;
            Role = role;
            Person = person;

        }

        public void Clear()
        {
            StaffID = 0;
            UserName = null;
            Person = null;
            PermissionCode = 0;
            RoleID = 0;
            Role = null;
        }
    }
}
