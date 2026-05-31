using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PersonRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddPersonAsync(clsPerson person)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> AddPhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ChangeActiveStatusAsync(int phoneNumberId, bool isActive, int updatedById)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsPerson> GetPersonByIdAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsPhoneNumber> GetPhoneNumberByIdAsync(int phoneNumberId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<clsPhoneNumber>> GetPhoneNumbersByPersonIdAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SetAllPersonNumbersNonPrimaryAsync(int personId, int updatedById)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SoftDeletePersonAsync(int personId, int deletedById)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePersonAsync(clsPerson person)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
