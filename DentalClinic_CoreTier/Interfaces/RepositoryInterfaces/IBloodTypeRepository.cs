using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IBloodTypeRepository
    {
        Task<IEnumerable<clsBloodType>> GetAllBloodTypesAsync();
        Task<clsBloodType> GetBloodTypeByIdAsync(int bloodTypeId);
    }
}
