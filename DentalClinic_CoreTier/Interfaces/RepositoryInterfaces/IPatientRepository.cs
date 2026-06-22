using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IPatientRepository
    {
        Task<int> AddPatientAsync(clsPatient patient);
        Task<int> AddPatientWithPersonAsync(clsPatient patient);
        Task<clsPatient> GetPatientByIdAsync(int patientId);
        Task<clsPatient> GetPatientByPersonIdAsync(int personId);
        Task<IEnumerable<clsPatient>> GetAllPatientsAsync();
        Task<bool> UpdatePatientAsync(clsPatient patient);
        Task<IEnumerable<clsPatient>> SearchByFullNameAsync(string fullName);
        Task<IEnumerable<clsPatient>> SearchByNationalNoAsync(string nationalNo);
        Task<IEnumerable<clsPatient>> SearchByPhoneNumberAsync(string phoneNumber);
        Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync();
        Task<bool> UpdatePatientWithPersonAsync(clsPatient patient);
    }
}
