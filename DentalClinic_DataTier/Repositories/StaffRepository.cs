using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private string _connectionString;
        public StaffRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Task<int> AddStaffAsync(clsStaff staff)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeActiveStatusAsync(int staffId, bool isActive, int updatedById)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsStaff>> GetAllActiveStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<clsStaff> GetStaffByIdAsync(int staffId)
        {
            throw new NotImplementedException();
        }

        public Task<clsStaff> GetStaffByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStaffAsync(clsStaff staff)
        {
            throw new NotImplementedException();
        }
    }
}
