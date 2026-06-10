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
        int RoleID { get; }
        clsStaff Staff { get; }
        void Set(clsStaff staff);
        void Clear();
    }
}
