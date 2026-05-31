using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString;
        public DoctorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> AddDoctorAsync(clsDoctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsDoctor>> GetAllDoctorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<clsDoctor> GetDoctorByIdAsync(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<clsDoctor> GetDoctorByStaffIdAsync(int staffId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDoctorAsync(clsDoctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
