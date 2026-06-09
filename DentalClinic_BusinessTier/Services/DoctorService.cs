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
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Task<clsDoctor> GetByIdAsync(int objId)
        {
            return _doctorRepository.GetDoctorByIdAsync(objId);
        }

        public Task<int?> InsertAsync(clsDoctor obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {

            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(clsDoctor obj,  int? updatedByID =null)
        {            
            if (!_isObjValid(obj))
            {
                return false;
            }

            if (updatedByID == null)
            {
                throw new ArgumentNullException("updatedByID", "you must pass the ID of the updateter");
            }
            obj.UpdatedBy_ID = updatedByID.Value;
            return await _doctorRepository.UpdateDoctorAsync(obj);
        }

        //helper methods 

        private bool _isObjValid(clsDoctor doctor)
        {
            if (doctor == null) throw new ArgumentNullException("Doctor Object is Null", "Can not update a null object");            
            return true;
        }
    }
}
