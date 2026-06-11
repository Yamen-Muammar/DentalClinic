using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<int> AddAppointmentAsync(clsAppointment appointment);
        Task<clsAppointment> GetAppointmentByIdAsync(int appointmentId);

        Task<IEnumerable<clsAppointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date);
        Task<IEnumerable<clsAppointment>> GetAppointmentsByProblemIdAsync(int problemId);
        Task<IEnumerable<clsAppointmentsDetails>> GetAppointmentsByDateAsync(DateTime fromDate,DateTime toDate);
        Task<bool> UpdateAppointmentAsync(clsAppointment appointment);
        Task<bool> UpdateAppointmentStatusAsync(int appointmentId, myEnums.enAppointmentStatus status, int updatedById);
    }
}
