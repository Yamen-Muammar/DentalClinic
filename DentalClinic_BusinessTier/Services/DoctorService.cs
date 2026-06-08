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
        private IStaffService _staffService;
        public DoctorService(IDoctorRepository doctorRepository, IStaffService staffService)
        {
            _doctorRepository = doctorRepository;
            _staffService = staffService;
        }

        public async Task<clsDoctor> GetByIdAsync(int objId)
        {
            clsDoctor doctor = await _doctorRepository.GetDoctorByIdAsync(objId);
            if (doctor == null) return null;

            doctor.Staff = await _staffService.GetByIdAsync(doctor.Staff_ID);

            return doctor;
        }

        public Task<int> InsertAsync(clsDoctor obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsDoctor obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
