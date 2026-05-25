using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;

namespace DentalClinic_BusinessTier.Services
{
    public class AppointmentService
    {
        private IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository= appointmentRepository;
        }

    }
}
