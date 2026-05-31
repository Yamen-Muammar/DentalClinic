using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IBloodTypeService : IGRUDService<clsBloodType>
    {
        Task<IEnumerable<clsBloodType>> GetAllAsync();
    }
}
