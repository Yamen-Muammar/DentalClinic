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
        private IPersonService _personService;
        public PatientService(IPatientRepository patientRepository, IPersonService personService)
        {
            _patientRepository = patientRepository;
            _personService = personService;
        }

        public async Task<clsPatient> GetByIdAsync(int objId)
        {
            clsPatient patient = await _patientRepository.GetPatientByIdAsync(objId);
            if (patient == null) return null;

            patient.Person = await _personService.GetByIdAsync(patient.Person_ID);

            return patient;
        }

        public Task<int> InsertAsync(clsPatient obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsPatient obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
