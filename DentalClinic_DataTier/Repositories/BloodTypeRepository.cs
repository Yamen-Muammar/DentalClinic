using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly string _connectionString;
        public BloodTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<IEnumerable<clsBloodType>> GetAllBloodTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<clsBloodType> GetBloodTypeByIdAsync(int bloodTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
