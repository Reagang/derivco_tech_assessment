using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects.Betting;
using Shared.DataTransferObjects.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Service.Contracts;

    internal sealed class BettingService:IBettingService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public BettingService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PlaceBetDto> PlaceBet(PlaceBetRequestDto bet)
        {
            var result = await _repository.Betting.PlaceBet(bet);

            return null;
        }
    }
}
