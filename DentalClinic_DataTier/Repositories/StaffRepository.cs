using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public StaffRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddStaffAsync(clsStaff staff)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ChangeActiveStatusAsync(int staffId, bool isActive, int updatedById)
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<clsStaff>> GetAllActiveStaffAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<clsStaff> GetStaffByIdAsync(int staffId)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsStaff> GetStaffByUsernameAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateStaffAsync(clsStaff staff)
        {
            throw new System.NotImplementedException();
        }
    }
}
