using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<int?> InsertAsync(clsPerson obj)
        {
            _validatePersonObj(obj);
            obj.CreatedAt = DateTime.Now;
            return await _personRepository.AddPersonAsync(obj);
        }

        public Task<clsPerson> GetByIdAsync(int objId)
            => _personRepository.GetPersonByIdAsync(objId);

        public async Task<bool> UpdateAsync(clsPerson obj, int? updatedByID = null)
        {
            if (updatedByID == null)
                throw new ArgumentNullException("updatedByID");
                
            _validatePersonObj(obj);
            obj.UpdatedBy_ID = updatedByID;
            obj.UpdatedAt    = DateTime.Now;
            return await _personRepository.UpdatePersonAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
            => await _personRepository.SoftDeletePersonAsync(objId, deletedById);

        public async Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo)
            => await _personRepository.GetPersonByNationalNoAsync(nationalNo);

        public async Task<int> AddPhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            phoneNumber.CreatedAt = DateTime.Now;
            return await _personRepository.AddPhoneNumberAsync(phoneNumber);
        }

        public async Task<clsPhoneNumber> GetPhoneNumberByIdAsync(int phoneNumberId)
            => await _personRepository.GetPhoneNumberByIdAsync(phoneNumberId);

        public async Task<IEnumerable<clsPhoneNumber>> GetPhoneNumbersByPersonIdAsync(int personId)
            => await _personRepository.GetPhoneNumbersByPersonIdAsync(personId);

        public async Task<bool> UpdatePhoneNumberAsync(clsPhoneNumber phoneNumber)
            => await _personRepository.UpdatePhoneNumberAsync(phoneNumber);

        public async Task<bool> ChangeActiveStatusAsync(int phoneNumberId, bool isActive, int updatedById)
            => await _personRepository.ChangeActiveStatusAsync(phoneNumberId, isActive, updatedById);

        public async Task<bool> SetAllPersonNumbersNonPrimaryAsync(int personId, int updatedById)
            => await _personRepository.SetAllPersonNumbersNonPrimaryAsync(personId, updatedById);

        private bool _validatePersonObj(clsPerson person)
        {
            if (person == null)
                throw new ArgumentNullException("person");

            if (string.IsNullOrWhiteSpace(person.FirstName))
                throw new ArgumentException("FirstName cannot be null or empty");

            if (string.IsNullOrWhiteSpace(person.LastName))
                throw new ArgumentException("LastName cannot be null or empty");

            if (!Enum.IsDefined(typeof(myEnums.enGenderTypes), person.Gender))
                throw new ArgumentException("Gender must be M or F");

            if (person.DateOfBirth != null && person.DateOfBirth >= DateTime.Today)
                throw new ArgumentException("DateOfBirth must be in the past");

            return true;
        }
    }
}
