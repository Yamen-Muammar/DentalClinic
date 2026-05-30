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
    public class StaffService : IStaffService
    {
        private IStaffRepository  _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;            
        }

        public Task<clsStaff> GetByIdAsync(int objId)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(clsStaff obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsStaff obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
