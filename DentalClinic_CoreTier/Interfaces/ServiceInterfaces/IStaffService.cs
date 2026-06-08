using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IStaffService : IGRUDService<clsStaff>
    {
        Task<clsStaff> LoginAsync(string username, string Password);
    }
}
