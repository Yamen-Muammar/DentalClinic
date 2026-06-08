using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface ISessionContext
    {
        int StaffID { get; }
        string UserName { get; }
        clsPerson Person { get; }
        long PermissionCode { get; }
        clsRole Role { get; }
        int RoleID { get; }
        void Set(clsStaff staff, clsRole role,clsPerson person);
        void Clear();
    }
}
