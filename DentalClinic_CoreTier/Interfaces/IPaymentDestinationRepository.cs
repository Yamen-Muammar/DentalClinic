using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IPaymentDestinationRepository
    {
        Task<IEnumerable<clsPaymentDestination>> GetAllPaymentDestinationsAsync();
        Task<clsPaymentDestination> GetPaymentDestinationByIdAsync(int destinationId);
    }
}
