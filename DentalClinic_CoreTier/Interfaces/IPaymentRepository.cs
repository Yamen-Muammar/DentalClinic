using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    internal interface IPaymentRepository
    {
        Task<int> AddPaymentAsync(clsPayment payment);
        Task<clsPayment> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<clsPayment>> GetPaymentsByAppointmentIdAsync(int appointmentId);

        // For accounting audits
        Task<IEnumerable<clsPayment>> GetPaymentsByDateRangeAsync(System.DateTime startDate, System.DateTime endDate);

        Task<bool> UpdatePaymentApprovalAsync(int paymentId, bool isApproved, int updatedById);
    }
}
