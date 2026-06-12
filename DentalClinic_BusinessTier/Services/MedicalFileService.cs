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
            _validateMedicalFileObj(obj);
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsMedicalFile obj, int? updatedByID =null)
        {
            _validateMedicalFileObj(obj);
            throw new NotImplementedException();
        }

        private bool _validateMedicalFileObj(clsMedicalFile medicalFile)
        {
            if (medicalFile == null)
                throw new ArgumentNullException("medicalFile");

            if (medicalFile.Patient_ID <= 0)
                throw new ArgumentException("Patient_ID must be a valid ID > 0");

            return true;
        }
    }
}
