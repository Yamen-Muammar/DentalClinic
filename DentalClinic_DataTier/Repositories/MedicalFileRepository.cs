using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class MedicalFileRepository : IMedicalFileRepository
    {
        private readonly string _connectionString;
        public MedicalFileRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> AddMedicalFileAsync(clsMedicalFile medicalFile)
        {
            throw new NotImplementedException();
        }

        public Task<clsMedicalFile> GetMedicalFileByIdAsync(int fileId)
        {
            throw new NotImplementedException();
        }

        public Task<clsMedicalFile> GetMedicalFileByPatientIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMedicalFileAsync(clsMedicalFile medicalFile)
        {
            throw new NotImplementedException();
        }
    }
}
