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
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<clsPatient> GetByIdAsync(int objId)
        {
            return _patientRepository.GetPatientByIdAsync(objId);
        }

        public Task<int?> InsertAsync(clsPatient obj)
        {
            _validatePatientObj(obj);
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsPatient obj,  int? updatedByID =null)
        {
            _validatePatientObj(obj);
            throw new NotImplementedException();
        }

        private bool _validatePatientObj(clsPatient patient)
        {
            if (patient == null)
                throw new ArgumentNullException("patient");

            if (patient.Person_ID <= 0)
                throw new ArgumentException("Person_ID must be a valid ID > 0");

            if (patient.BloodType_ID != null && patient.BloodType_ID <= 0)
                throw new ArgumentException("BloodType_ID must be > 0 when provided");

            return true;
        }
    }
}
