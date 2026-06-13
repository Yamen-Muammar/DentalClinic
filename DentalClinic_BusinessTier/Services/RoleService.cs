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

        public async Task<int?> InsertAsync(clsRole obj)
        {
            _validateRoleObj(obj);
            return await _roleRepository.AddRoleAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {            
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(clsRole obj,  int? updatedByID =null)
        {
            _validateRoleObj(obj);
            if(updatedByID == null || updatedByID <= 0)
            {
                throw new ArgumentException("You must pass the staff ID");
            }
            return await _roleRepository.UpdateRoleAsync(obj);
        }

        private bool _validateRoleObj(clsRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            if (string.IsNullOrWhiteSpace(role.RoleName))
                throw new ArgumentException("RoleName cannot be null or empty");

            if (role.RolePermissionCode < 0)
                throw new ArgumentException("RolePermissionCode cannot be negative");

            return true;
        }
    }
}
