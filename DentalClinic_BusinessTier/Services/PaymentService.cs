using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        private IPaymentTypeRepository _paymentTypeRepository;
        private IPaymentDestinationRepository _paymentDestinationRepository;
        public PaymentService(IPaymentRepository paymentRepository
            , IPaymentTypeRepository paymentTypeRepository
            , IPaymentDestinationRepository paymentDestinationRepository)
        {
            _paymentRepository = paymentRepository;
            _paymentTypeRepository = paymentTypeRepository;
            _paymentDestinationRepository = paymentDestinationRepository;
        }

        public async Task<int> AddPaymentAsync(clsPayment payment)
            => await _paymentRepository.AddPaymentAsync(payment);

        public async Task<clsPayment> GetPaymentByIdAsync(int paymentId)
            => await _paymentRepository.GetPaymentByIdAsync(paymentId);

        public async Task<clsPayment> GetPaymentByAppointmentIdAsync(int appointmentId)
            => await _paymentRepository.GetPaymentByAppointmentIdAsync(appointmentId);

        public async Task<IEnumerable<clsPayment>> GetPaymentsByProblemIdAsync(int problemId)
            => await _paymentRepository.GetPaymentsByProblemIdAsync(problemId);

        public async Task<IEnumerable<clsPayment>> GetNotApprovedPaymentsAsync()
            => await _paymentRepository.GetNotApprovedPaymentsAsync();

        public async Task<IEnumerable<clsPayment>> GetApprovedPaymentsAsync()
            => await _paymentRepository.GetApprovedPaymentsAsync();

        public async Task<int?> GetNotApprovedPaymentsCount()
            => await _paymentRepository.GetNotApprovedPaymentsCount();

        public async Task<int?> GetPaymentsCount()
            => await _paymentRepository.GetPaymentsCount();

        public async Task<int?> GetApprovedPaymentsCount()
            => await _paymentRepository.GetApprovedPaymentsCount();

        public async Task<IEnumerable<clsPayment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
            => await _paymentRepository.GetPaymentsByDateRangeAsync(startDate, endDate);

        public async Task<bool> UpdatePaymentApprovalAsync(int paymentId, bool isApproved, int updatedById)
            => await _paymentRepository.UpdatePaymentApprovalAsync(paymentId, isApproved, updatedById);
    }
}
