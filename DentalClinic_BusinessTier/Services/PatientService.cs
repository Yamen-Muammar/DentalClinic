using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_BusinessTier.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        private IPersonService _personService;

        public PatientService(IPatientRepository patientRepository,IPersonService personService)
        {
            _patientRepository = patientRepository;
            _personService = personService;
        }

        public async Task<clsPatient> GetByIdAsync(int objId)
        {
            clsPatient patient = await _patientRepository.GetPatientByIdAsync(objId);
            if (patient == null)            
            {
                return null;
            }
            patient.PersonInfo = await _personService.GetByIdAsync(patient.Person_ID);
            return patient;
        }

        public async Task<int?> InsertAsync(clsPatient obj)
        {
            _validatePatientObj(obj);

            return await _patientRepository.AddPatientAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            return await _personService.SoftDeleteAsync(objId, deletedById);;
        }

        public async Task<bool> UpdateAsync(clsPatient obj,  int? updatedByID =null)
        {
            _validatePatientObj(obj);

             if(updatedByID == null)
            {
                throw new ArgumentException("You must pass the staff ID");
            }

            obj.UpdatedBy_ID = updatedByID.Value;
            return await _patientRepository.UpdatePatientAsync(obj);
        }

        public async Task<IEnumerable<clsPatient>> SearchByFullNameAsync(string fullName)
            => await _patientRepository.SearchByFullNameAsync(fullName);

        public async Task<IEnumerable<clsPatient>> SearchByNationalNoAsync(string nationalNo)
            => await _patientRepository.SearchByNationalNoAsync(nationalNo);

        public async Task<IEnumerable<clsPatient>> SearchByPhoneNumberAsync(string phoneNumber)
            => await _patientRepository.SearchByPhoneNumberAsync(phoneNumber);

        public Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync()
            => _patientRepository.GetAllPatientDetailsAsync();

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
