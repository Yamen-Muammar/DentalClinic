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

        public async Task<clsMedicalFile> GetByIdAsync(int objId)
        {
            return await _medicalFileRepository.GetMedicalFileByIdAsync(objId);
        }

        public async Task<clsMedicalFile> GetMedicalFilesByPatientIDAsync(int patientID)
        {
            return await _medicalFileRepository.GetMedicalFileByPatientIdAsync(patientID);
        }

        public async Task<int?> InsertAsync(clsMedicalFile obj)
        {
            _validateMedicalFileObj(obj);
            return await _medicalFileRepository.AddMedicalFileAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(clsMedicalFile obj, int? updatedByID =null)
        {
            _validateMedicalFileObj(obj);

            if(updatedByID == null)
            {
                throw new ArgumentException("You must pass the staff ID");
            }

            obj.UpdatedBy_ID = updatedByID.Value;
            
            return await _medicalFileRepository.UpdateMedicalFileAsync(obj);
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
