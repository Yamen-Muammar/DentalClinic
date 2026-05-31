using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PaymentRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddPaymentAsync(clsPayment payment)
        {
            throw new NotImplementedException();
        }

        public Task<clsPayment> GetPaymentByIdAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsPayment>> GetPaymentsByAppointmentIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsPayment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePaymentApprovalAsync(int paymentId, bool isApproved, int updatedById)
        {
            throw new NotImplementedException();
        }
    }
}
