using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;
        public RoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> AddRoleAsync(clsRole role)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsRole>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<clsRole> GetRoleByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRoleAsync(clsRole role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRolePermissionsAsync(int roleId, decimal permissionCode)
        {
            throw new NotImplementedException();
        }
    }
}
