using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IMedicalFileRepository
    {
        Task<int> AddMedicalFileAsync(clsMedicalFile medicalFile);
        Task<clsMedicalFile> GetMedicalFileByIdAsync(int fileId);
        Task<clsMedicalFile> GetMedicalFileByPatientIdAsync(int patientId);
        Task<bool> UpdateMedicalFileAsync(clsMedicalFile medicalFile);
    }
}
