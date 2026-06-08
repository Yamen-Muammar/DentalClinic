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
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<clsPerson> GetByIdAsync(int objId)
        {
            clsPerson person = await _personRepository.GetPersonByIdAsync(objId);
            if (person == null) return null;

            person.PhoneNumbers = await _personRepository.GetPhoneNumbersByPersonIdAsync(person.PersonID);

            return person;
        }

        public Task<int> InsertAsync(clsPerson obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsPerson obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
