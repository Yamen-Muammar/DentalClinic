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
        Task<int> AddPatientWithPersonAndMedicalFileAsync(clsPatient patient,clsMedicalFile medicalFile);
        Task<clsPatient> GetPatientByIdAsync(int patientId);
        Task<clsPatient> GetPatientByPersonIdAsync(int personId);
        Task<IEnumerable<clsPatient>> GetAllPatientsAsync();
        Task<bool> UpdatePatientAsync(clsPatient patient);
        Task<IEnumerable<clsPatientView>> SearchByFullNameAsync(string fullName);
        Task<IEnumerable<clsPatientView>> SearchByNationalNoAsync(string nationalNo);
        Task<IEnumerable<clsPatientView>> SearchByPhoneNumberAsync(string phoneNumber);
        Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync();
        Task<bool> UpdatePatientWithPersonAndMedicalFileAsync(clsPatient patient, clsMedicalFile medicalFile);
        Task<clsPatientView> GetPatientDetailsViewByIDAsync(int patientID);
        Task<IEnumerable<clsPatientView>> GetAllPatientDetailsOnTodaysAppointmentsAsync();
        Task<int>   GetPatientCountAsync();
    }
}
