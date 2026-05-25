using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;

namespace DentalClinic_BusinessTier.Services
{
    public class PersonService
    {
        private IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
    }
}
