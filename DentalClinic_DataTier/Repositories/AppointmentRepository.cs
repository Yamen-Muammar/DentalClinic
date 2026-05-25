using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public Task<int> AddAppointmentAsync(clsAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<clsAppointment> GetAppointmentByIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsAppointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsAppointment>> GetAppointmentsByProblemIdAsync(int problemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAppointmentAsync(clsAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAppointmentStatusAsync(int appointmentId, string status, int updatedById)
        {
            throw new NotImplementedException();
        }
    }
}
