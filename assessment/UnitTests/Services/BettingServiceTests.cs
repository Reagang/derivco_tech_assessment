using Contracts;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.Betting;

namespace UnitTests.Services
{
    using Contracts;
    using Microsoft.AspNetCore.Mvc;

    using Shared.DataTransferObjects.Betting;

    public class BettingRepositoryTests
    {
        private IBettingService _bettingService;
        private Mock<IRepositoryManager> _repositoryManagerMock;
        private Mock<ILoggerManager> _loggerManagerMock;

        [SetUp]
        public void Setup()
        {// Arrange
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _loggerManagerMock = new Mock<ILoggerManager>();
        }

        [Test]
        public async Task PlaceBet_ShouldReturnPlaceBetDto()
        {
            // Arrange
            var betRequest = new PlaceBetRequestDto
                                 {
                                     PlayerId = "1",
                                     BetNumber = 1,
                                     BetAmount = 1,
                                     BetType = "something"
                                 };

            // Mock the behavior of the repository's PlaceBet method to return some PlaceBetDto
            var expectedPlaceBetDto = new PlaceBetDto
                                          {
                                              PlayerId = "1",
                                              BetNumber = 1,
                                              BetAmount = 1,
                                              BetType = "something"
                                          };
            _repositoryManagerMock.Setup(m => m.Betting.PlaceBet(It.IsAny<PlaceBetRequestDto>()))
                .ReturnsAsync(expectedPlaceBetDto);

            // Act
            var result = await _bettingService.PlaceBet(betRequest);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}