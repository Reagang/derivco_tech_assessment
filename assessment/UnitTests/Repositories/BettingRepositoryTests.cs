using Contracts;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.Betting;

namespace UnitTests.Repositories
{
    using Contracts;

    using Dapper;

    using Microsoft.AspNetCore.Mvc;

    using Respository;

    using Shared.DataTransferObjects.Betting;

    public class BettingRepositoryTests
    {
        private BettingRepository _bettingRepository;
        private Mock<DapperContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _contextMock = new Mock<DapperContext>();
            _bettingRepository = new BettingRepository(_contextMock.Object);
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

            // Mock the behavior of Dapper's QuerySingleAsync method to return a predefined PlaceBetDto
            var expectedPlaceBetDto = new PlaceBetDto
                                          {
                                              PlayerId = "1",
                                              BetNumber = 1,
                                              BetAmount = 1,
                                              BetType = "something"
                                          };
            _contextMock.Setup(m => m.CreateConnection().QuerySingleAsync<PlaceBetDto>(It.IsAny<string>(), It.IsAny<object>(), null, null, System.Data.CommandType.StoredProcedure))
                .ReturnsAsync(expectedPlaceBetDto);

            // Act
            var result = await _bettingRepository.PlaceBet(betRequest);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}