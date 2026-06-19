using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier;
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
            if (obj == null)
                throw new ArgumentNullException("obj");

            if (obj.PersonInfo != null)
            {
                _validateNewPersonForPatient(obj.PersonInfo);

                obj.PersonInfo.CreatedAt = DateTime.Now;
                if (obj.PersonInfo.PhoneNumbers != null)
                {
                    foreach (var phone in obj.PersonInfo.PhoneNumbers)
                    {
                        phone.CreatedAt = DateTime.Now;
                        phone.IsActive  = true;
                    }
                }
                obj.CreatedAt = DateTime.Now;
                return await _patientRepository.AddPatientWithPersonAsync(obj);
            }
            else
            {
                _validatePatientObj(obj);
                obj.CreatedAt = DateTime.Now;
                return await _patientRepository.AddPatientAsync(obj);
            }
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

        private void _validateNewPersonForPatient(clsPerson person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
                throw new ArgumentException("FirstName cannot be null or empty");

            if (string.IsNullOrWhiteSpace(person.LastName))
                throw new ArgumentException("LastName cannot be null or empty");

            if (!Enum.IsDefined(typeof(myEnums.enGenderTypes), person.Gender))
                throw new ArgumentException("Gender must be M or F");

            if (person.DateOfBirth != null && person.DateOfBirth >= DateTime.Today)
                throw new ArgumentException("DateOfBirth must be in the past");

            if (person.PhoneNumbers != null && person.PhoneNumbers.Count > 0)
            {
                if (person.PhoneNumbers.Any(p => string.IsNullOrWhiteSpace(p.Number)))
                    throw new ArgumentException("All phone numbers must have a value.");

                if (person.PhoneNumbers.Count(p => p.IsPrimary) > 1)
                    throw new ArgumentException("Only one phone number can be marked as primary.");
            }
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
