using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RoleRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddRoleAsync(clsRole role)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<clsRole>> GetAllRolesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<clsRole> GetRoleByIdAsync(int roleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateRoleAsync(clsRole role)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateRolePermissionsAsync(int roleId, decimal permissionCode)
        {
            throw new System.NotImplementedException();
        }
    }
}
