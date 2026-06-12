using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IPersonService : IGRUDService<clsPerson>
    {
        Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo);
        //Phone Number 
        Task<int> AddPhoneNumberAsync(clsPhoneNumber phoneNumber);
        Task<clsPhoneNumber> GetPhoneNumberByIdAsync(int phoneNumberId);
        Task<IEnumerable<clsPhoneNumber>> GetPhoneNumbersByPersonIdAsync(int personId);

        Task<bool> UpdatePhoneNumberAsync(clsPhoneNumber phoneNumber);

        // Soft delete/deactivation to preserve record history
        Task<bool> ChangeActiveStatusAsync(int phoneNumberId, bool isActive, int updatedById);

        // Helper to quickly unset old primary numbers when a user marks a new one as primary
        Task<bool> SetAllPersonNumbersNonPrimaryAsync(int personId, int updatedById);
    }
}
