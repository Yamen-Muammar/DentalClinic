using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IPatientService
    {
        Task<clsPatient>GetByIdAsync(int  id);
        Task<int?> InsertAsync(clsPatient obj, string generalAllergies);
        Task<IEnumerable<clsPatient>> SearchByFullNameAsync(string fullName);
        Task<IEnumerable<clsPatient>> SearchByNationalNoAsync(string nationalNo);
        Task<IEnumerable<clsPatient>> SearchByPhoneNumberAsync(string phoneNumber);
        Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync();
        Task<bool> UpdatePatientWithPersonAndMedicalFileAsync(clsPatient patient,clsMedicalFile medicalFile,int updatedByID);
        Task<clsPatientView> GetPatientDetailsViewByIDAsync(int patientID);
        Task<int> GetPatientCountAsync();
    }
}
