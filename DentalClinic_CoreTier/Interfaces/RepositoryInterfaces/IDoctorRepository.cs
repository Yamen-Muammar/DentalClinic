using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IDoctorRepository
    {
        Task<int> AddDoctorAsync(clsDoctor doctor);
        Task<clsDoctor> GetDoctorByIdAsync(int doctorId);
        Task<clsDoctor> GetDoctorByStaffIdAsync(int staffId);
        Task<IEnumerable<clsDoctor>> GetAllDoctorsAsync();
        Task<bool> UpdateDoctorAsync(clsDoctor doctor);
        Task<IEnumerable<clsDoctorListInformation>> GetAllDoctorsListInformationAsync();
    }
}
