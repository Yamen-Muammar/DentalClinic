using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IPersonRepository
    {
        Task<int> AddPersonAsync(clsPerson person);
        Task<clsPerson> GetPersonByIdAsync(int personId);
        Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo);
        Task<bool> UpdatePersonAsync(clsPerson person);
        Task<bool> SoftDeletePersonAsync(int personId, int deletedById);
    }
}
