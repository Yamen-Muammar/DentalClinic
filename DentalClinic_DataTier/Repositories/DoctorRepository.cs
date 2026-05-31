using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DoctorRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddDoctorAsync(clsDoctor doctor)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<clsDoctor>> GetAllDoctorsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<clsDoctor> GetDoctorByIdAsync(int doctorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsDoctor> GetDoctorByStaffIdAsync(int staffId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateDoctorAsync(clsDoctor doctor)
        {
            throw new System.NotImplementedException();
        }
    }
}
