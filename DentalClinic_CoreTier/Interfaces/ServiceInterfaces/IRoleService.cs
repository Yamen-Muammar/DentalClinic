using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IRoleService : IGRUDService<clsRole>
    {
        Task<Dictionary<string, long>> GetAllRolesAsync();
    }
}
