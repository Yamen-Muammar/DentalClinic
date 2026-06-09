using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IGRUDService<T>
    {
        Task<int?> InsertAsync(T obj);
        Task<T> GetByIdAsync(int objId);
        Task<bool> UpdateAsync(T obj,int? updatedByID = null);
        Task<bool> SoftDeleteAsync(int objId, int deletedById);
    }
}
