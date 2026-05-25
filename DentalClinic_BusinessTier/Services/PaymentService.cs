using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;

namespace DentalClinic_BusinessTier.Services
{
    public class PaymentService
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
    }
}
