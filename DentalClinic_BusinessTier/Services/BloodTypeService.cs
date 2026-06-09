using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IBloodTypeRepository _bloodTypeRepository;

        public BloodTypeService(IBloodTypeRepository bloodTypeRepository)
        {
            _bloodTypeRepository = bloodTypeRepository;
        }

        public Task<IEnumerable<clsBloodType>> GetAllAsync()
        {
            return _bloodTypeRepository.GetAllBloodTypesAsync();
        }

        public Task<clsBloodType> GetByIdAsync(int objId)
        {
            return _bloodTypeRepository.GetBloodTypeByIdAsync(objId);
        }

        public Task<int?> InsertAsync(clsBloodType obj)
        {
            throw new System.NotSupportedException("BloodType is a reference table and does not support insertions.");
        }

        public Task<bool> UpdateAsync(clsBloodType obj, int? updatedByID =null)
        {
            throw new System.NotSupportedException("BloodType is a reference table and does not support updates.");
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new System.NotSupportedException("BloodType is a reference table and does not support deletions.");
        }
    }
}
