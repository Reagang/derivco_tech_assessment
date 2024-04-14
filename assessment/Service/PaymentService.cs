using AutoMapper;
using Contracts;
using Shared.DataTransferObjects.Game;
using Shared.DataTransferObjects.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Service.Contracts;

    internal sealed class PaymentService:IPaymentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public PaymentService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task Payout(PayoutRequestDto payoutRequest)
        {
            //var paymentInfo = await GetPlayerPaymentInfomationAndCheckIfItExists(payoutRequest.PlayerId);

            _repository.Payment.Payout(payoutRequest);
            //await _repository.SaveAsync();
        }
    }
}
