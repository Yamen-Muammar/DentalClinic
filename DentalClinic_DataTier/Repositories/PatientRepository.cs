using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PatientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddPatientAsync(clsPatient patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<clsPatient>> GetAllPatientsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<clsPatient> GetPatientByIdAsync(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsPatient> GetPatientByPersonIdAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePatientAsync(clsPatient patient)
        {
            throw new System.NotImplementedException();
        }
    }
}
