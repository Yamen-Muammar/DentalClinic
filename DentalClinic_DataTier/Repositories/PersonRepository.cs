using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;
        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> AddPersonAsync(clsPerson person)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddPhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeActiveStatusAsync(int phoneNumberId, bool isActive, int updatedById)
        {
            throw new NotImplementedException();
        }

        public Task<clsPerson> GetPersonByIdAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo)
        {
            throw new NotImplementedException();
        }

        public Task<clsPhoneNumber> GetPhoneNumberByIdAsync(int phoneNumberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsPhoneNumber>> GetPhoneNumbersByPersonIdAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAllPersonNumbersNonPrimaryAsync(int personId, int updatedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeletePersonAsync(int personId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePersonAsync(clsPerson person)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
