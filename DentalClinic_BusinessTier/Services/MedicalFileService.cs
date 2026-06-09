using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class MedicalFileService : IMedicalFileService
    {
        private IMedicalFileRepository _medicalFileRepository;
        public MedicalFileService(IMedicalFileRepository medicalFileRepository)
        {
            _medicalFileRepository = medicalFileRepository;
        }

        public Task<clsMedicalFile> GetByIdAsync(int objId)
        {
            return _medicalFileRepository.GetMedicalFileByIdAsync(objId);
        }

        public Task<int?> InsertAsync(clsMedicalFile obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsMedicalFile obj, int? updatedByID =null)
        {
            throw new NotImplementedException();
        }
    }
}
