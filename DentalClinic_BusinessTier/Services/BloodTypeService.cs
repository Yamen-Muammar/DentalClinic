using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;

namespace DentalClinic_BusinessTier.Services
{
    public class BloodTypeService
    {
        private IBloodTypeRepository _bloodTypeRepository;
        public BloodTypeService(IBloodTypeRepository bloodTypeRepository)
        {
            _bloodTypeRepository = bloodTypeRepository;
        }
    }
}
