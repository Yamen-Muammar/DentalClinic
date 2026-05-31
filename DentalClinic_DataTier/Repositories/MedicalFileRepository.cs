using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class MedicalFileRepository : IMedicalFileRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MedicalFileRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddMedicalFileAsync(clsMedicalFile medicalFile)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsMedicalFile> GetMedicalFileByIdAsync(int fileId)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsMedicalFile> GetMedicalFileByPatientIdAsync(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateMedicalFileAsync(clsMedicalFile medicalFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
