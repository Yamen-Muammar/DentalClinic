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
        Task<int> AddStaffAsync(clsStaff staff);
        Task<clsStaff> GetStaffByIdAsync(int staffId);
        Task<IEnumerable<clsStaff>> GetAllActiveStaffAsync();
        Task<bool> UpdateStaffAsync(clsStaff staff);
        Task<clsStaff> GetStaffByUsernameAsync(string username);
        Task<bool> ChangeActiveStatusAsync(int staffId, bool isActive, int updatedById);
        Task<bool> SoftDeleteStaff(int deletedById, int staffID);
    }
}
