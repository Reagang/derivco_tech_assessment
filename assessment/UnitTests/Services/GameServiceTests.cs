using Contracts;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.Game;

namespace UnitTests.Services
{
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Shared.DataTransferObjects.Game;

    public class GameServiceTests
    {
        private IGameService _gameService;
        private Mock<IRepositoryManager> _repositoryManagerMock;
        private Mock<ILoggerManager> _loggerManagerMock;

        [SetUp]
        public void Setup()
        {// Arrange
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _loggerManagerMock = new Mock<ILoggerManager>();
        }

        [Test]
        public async Task Spin_ShouldCallRepositorySpin()
        {
            // Arrange
            var spinRequest = new SpinRequestDto
                                  {
                                      PlayerId = "1"
                                  };

            // Act
            await _gameService.Spin(spinRequest);

            // Assert
            _repositoryManagerMock.Verify(m => m.Game.Spin(spinRequest), Times.Once);
        }

        [Test]
        public async Task ShowPreviousSpins_ShouldCallRepositoryShowPreviousSpins()
        {
            // Arrange
            var previousSpinRequest = new PreviousSpinRequestDto
                                          {
                                              PlayerId = "1"
                                          };

            // Act
            await _gameService.ShowPreviousSpins(previousSpinRequest);

            // Assert
            _repositoryManagerMock.Verify(m => m.Game.ShowPreviousSpins(previousSpinRequest), Times.Once);
        }
    }
}