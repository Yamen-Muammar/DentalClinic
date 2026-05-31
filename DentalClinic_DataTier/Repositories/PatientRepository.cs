using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;
        public PatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> AddPatientAsync(clsPatient patient)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsPatient>> GetAllPatientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<clsPatient> GetPatientByIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<clsPatient> GetPatientByPersonIdAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePatientAsync(clsPatient patient)
        {
            throw new NotImplementedException();
        }
    }
}
