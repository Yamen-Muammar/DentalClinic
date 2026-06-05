using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<Dictionary<string, long>> GetAllRolesAsync()
        {
            return _roleRepository.GetAllRolesAsync();
        }

        public Task<clsRole> GetByIdAsync(int objId)
        {
            return _roleRepository.GetRoleByIdAsync(objId);
        }

        public Task<int> InsertAsync(clsRole obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsRole obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
