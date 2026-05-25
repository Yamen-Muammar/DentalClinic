using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IStaffRepository
    {
        // Core CRUD Operations
        Task<int> AddStaffAsync(clsStaff staff);
        Task<clsStaff> GetStaffByIdAsync(int staffId);
        Task<IEnumerable<clsStaff>> GetAllActiveStaffAsync();
        Task<bool> UpdateStaffAsync(clsStaff staff);

        // Security & Authentication Queries
        Task<clsStaff> GetStaffByUsernameAsync(string username);

        // We don't delete staff (audit trail safety). We deactivate them.
        Task<bool> ChangeActiveStatusAsync(int staffId, bool isActive, int updatedById);
    }
}
