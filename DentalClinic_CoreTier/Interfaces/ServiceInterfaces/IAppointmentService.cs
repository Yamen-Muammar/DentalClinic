using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IAppointmentService : IGRUDService<clsAppointment>
    {
        Task<IEnumerable<clsAppointmentsDetails>> GetAppointmentsByDateAsync(DateTime fromDate, DateTime toDate);
    }
}
