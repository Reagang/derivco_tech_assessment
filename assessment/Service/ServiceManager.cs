using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using AutoMapper;

    using Contracts;

    using global::Contracts;

    using Service.Contracts;

    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBettingService> _bettingService;
        private readonly Lazy<IPaymentService> _paymentService;
        private readonly Lazy<IGameService> _gameService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _bettingService = new Lazy<IBettingService>(() =>
                new BettingService(repositoryManager, logger));
            _paymentService = new Lazy<IPaymentService>(() =>
                new PaymentService(repositoryManager, logger));
            _gameService = new Lazy<IGameService>(() =>
                new GameService(repositoryManager, logger));
        }

        public IBettingService BettingService => _bettingService.Value;
        public IPaymentService PaymentService => _paymentService.Value;
        public IGameService GameService => _gameService.Value;
    }
}
