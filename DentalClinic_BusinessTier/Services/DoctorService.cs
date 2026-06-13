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

        public async Task<clsDoctor> GetByIdAsync(int objId)
        {
            return await _doctorRepository.GetDoctorByIdAsync(objId);
        }

        public async Task<int?> InsertAsync(clsDoctor obj)
        {
            _validateDoctorObj(obj);
            return await _doctorRepository.AddDoctorAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {

            throw new NotImplementedException(); 
        }

        public async Task<bool> UpdateAsync(clsDoctor obj,  int? updatedByID =null)
        {
            if (!_validateDoctorObj(obj))
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

        private bool _validateDoctorObj(clsDoctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException("doctor");

            if (doctor.Staff_ID <= 0)
                throw new ArgumentException("Staff_ID must be a valid ID > 0");

            return true;
        }
    }
}
