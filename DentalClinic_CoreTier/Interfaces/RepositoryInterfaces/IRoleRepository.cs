using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IRoleRepository
    {
        Task<int> AddRoleAsync(clsRole role);
        Task<clsRole> GetRoleByIdAsync(int roleId);
        Task<IEnumerable<clsRole>> GetAllRolesAsync();
        Task<bool> UpdateRoleAsync(clsRole role);

        // Specific method to easily modify bitwise authorization masks from a management UI
        Task<bool> UpdateRolePermissionsAsync(int roleId, decimal permissionCode);
    }
}
