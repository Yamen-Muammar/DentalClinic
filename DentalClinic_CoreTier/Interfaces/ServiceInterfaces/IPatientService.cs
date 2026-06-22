using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IPatientService : IGRUDService<clsPatient>
    {
        Task<IEnumerable<clsPatient>> SearchByFullNameAsync(string fullName);
        Task<IEnumerable<clsPatient>> SearchByNationalNoAsync(string nationalNo);
        Task<IEnumerable<clsPatient>> SearchByPhoneNumberAsync(string phoneNumber);
        Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync();
        Task<bool> UpdatePatientWithPersonAsync(clsPatient patient,int updatedByID);
    }
}
