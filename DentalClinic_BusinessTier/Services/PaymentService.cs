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

        private bool _validatePaymentObj(clsPayment payment)
        {
            if (payment == null)
                throw new ArgumentNullException("payment");

            if (payment.PaymentType_ID <= 0)
                throw new ArgumentException("PaymentType_ID must be a valid ID > 0");

            if (payment.PaymentDestination_ID <= 0)
                throw new ArgumentException("PaymentDestination_ID must be a valid ID > 0");

            if (payment.Appointment_ID != null && payment.Appointment_ID <= 0)
                throw new ArgumentException("Appointment_ID must be > 0 when provided");

            if (payment.CreatedBy_ID <= 0)
                throw new ArgumentException("CreatedBy_ID must be a valid staff ID > 0");

            if (payment.TotalAmount <= 0)
                throw new ArgumentException("TotalAmount must be greater than zero");

            if (payment.ActualPaid < 0)
                throw new ArgumentException("ActualPaid cannot be negative");

            if (payment.ActualPaid > payment.TotalAmount)
                throw new ArgumentException("ActualPaid cannot exceed TotalAmount");
            if (payment.UpdatedBy_ID <= 0)
                throw new ArgumentException("UpdatedBy_ID must be a valid staff ID > 0");

            return true;
        }

        public async Task<int> AddPaymentAsync(clsPayment payment)
        {
            _validatePaymentObj(payment);
            return await _paymentRepository.AddPaymentAsync(payment);
        }

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

        public Task<bool> UpdatePaymentAsync(clsPayment payment , int UpdateByID)
        {
            _validatePaymentObj(payment);
             if(UpdateByID <= 0)
            {
                throw new ArgumentException("You must pass the staff ID");
            }

            payment.UpdatedBy_ID = UpdateByID;
            return _paymentRepository.UpdatePaymentAsync(payment);
        }
    }
}
