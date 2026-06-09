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

        public Task<clsPerson> GetByIdAsync(int objId)
        {
            return _personRepository.GetPersonByIdAsync(objId);
        }

        public Task<int?> InsertAsync(clsPerson obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsPerson obj, int? updatedByID =null)
        {
            throw new NotImplementedException();
        }
    }
}
