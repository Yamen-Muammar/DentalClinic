using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IPersonService : IGRUDService<clsPerson>
    {
        Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo);
    }
}
