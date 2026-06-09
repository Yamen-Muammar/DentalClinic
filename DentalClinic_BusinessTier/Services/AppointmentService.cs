using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Task<clsAppointment> GetByIdAsync(int objId)
        {
            return _appointmentRepository.GetAppointmentByIdAsync(objId);
        }

        public async Task<int?> InsertAsync(clsAppointment obj)
        {
            // TODO : Implemetn the insert logic.
            if (!_validateAppointmentObj(obj))
            {
                return null;
            }
            int? insertedAppointmentID = null;

            return insertedAppointmentID;
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            return await _appointmentRepository.UpdateAppointmentStatusAsync(objId,myEnums.enAppointmentStatus.Cancelled , deletedById);
        }

        public async Task<bool> UpdateAsync(clsAppointment obj, int? updatedByID = null)
        {
            if (!updatedByID.HasValue)
            {
                throw new ArgumentNullException("updatedByID", "UpdatedByID must be provided for updating an appointment.");
            }
            obj.UpdatedBy_ID = updatedByID.Value;
            return await _appointmentRepository.UpdateAppointmentAsync(obj);
        }

        // helper methods 
        private bool _validateAppointmentObj(clsAppointment obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Appointment Object Null", "Appointment object cannot be null.");
            }

            if (DateTime.Compare(obj.AppointmentDate,DateTime.Now) <= 0)
            {
                throw new ArgumentException("Invalid Appointment Date", "Appointment date must be in the future.");
            }

            if (TimeSpan.Compare(obj.StartTime, obj.EndTime) >= 0)
            {
                throw new ArgumentException("Invalid Appointment Time", "Start time must be before end time.");
            }
            if (obj.Status != myEnums.enAppointmentStatus.Scheduled)
            {
                throw new ArgumentException("Invalid Appointment Status", "New appointments must have status 'Scheduled'.");
            }

            if (string.IsNullOrEmpty(obj.Cause))
            {
                throw new ArgumentNullException("Invalid Appointment Cause", "Cause of appointment cannot be null or empty.");
            }
            return true;
        }
    }
}
