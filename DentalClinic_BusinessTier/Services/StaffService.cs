using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class StaffService
    {
        private IStaffRepository  _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;            
        }
    }
}
