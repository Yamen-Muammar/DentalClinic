using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> AddPaymentAsync(clsPayment payment);
        Task<clsPayment> GetPaymentByIdAsync(int paymentId);
        Task<clsPayment> GetPaymentByAppointmentIdAsync(int appointmentId);
        Task<IEnumerable<clsPayment>> GetPaymentsByProblemIdAsync(int problemId);
        Task<IEnumerable<clsPayment>> GetNotApprovedPaymentsAsync();
        Task<IEnumerable<clsPayment>> GetApprovedPaymentsAsync();
        Task<int?> GetNotApprovedPaymentsCount();
        Task<int?> GetPaymentsCount();
        Task<int?> GetApprovedPaymentsCount();

        // For accounting audits
        Task<IEnumerable<clsPayment>> GetPaymentsByDateRangeAsync(System.DateTime startDate, System.DateTime endDate);

        Task<bool> UpdatePaymentApprovalAsync(int paymentId, bool isApproved, int updatedById);
    }
}
