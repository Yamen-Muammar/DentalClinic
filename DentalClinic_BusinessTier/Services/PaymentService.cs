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
        //Payments
        public Task<clsPayment> GetByIdAsync(int objId)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(clsPayment obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsPayment obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }

        // Payment Types

        // Payment Destination
    }
}
