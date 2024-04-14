using AutoMapper;
using Contracts;
using Shared.DataTransferObjects.Game;
using Shared.DataTransferObjects.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Service.Contracts;

    internal sealed class GameService:IGameService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public GameService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task Spin(SpinRequestDto spinRequest)
        {
            //var game = await GetPlayerGameAndCheckIfItExists(spinRequest.PlayerId);

            _repository.Game.Spin(spinRequest);
            //await _repository.SaveAsync();
        }

        public async Task ShowPreviousSpins(PreviousSpinRequestDto previousSpin)
        {
            //var game = await GetPlayerGameAndCheckIfItExists(previousSpin.PlayerId);

            _repository.Game.ShowPreviousSpins(previousSpin);
           // await _repository.SaveAsync();
        }
    }
}
