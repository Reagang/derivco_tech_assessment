using Contracts;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.Game;

namespace UnitTests.Repositories
{
    using Contracts;

    using Dapper;

    using Microsoft.AspNetCore.Mvc;

    using Respository;

    using Shared.DataTransferObjects.Game;

    public class GameRepositoryTests
    {
        private GameRepository _gameRepository;
        private Mock<DapperContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _contextMock = new Mock<DapperContext>();
            _gameRepository = new GameRepository(_contextMock.Object);
        }

        [Test]
        public async Task ShowPreviousSpins_ShouldReturnSpinDto()
        {
            // Arrange
            var spinHistory = new PreviousSpinRequestDto
                                  {
                                      PlayerId = "1"
                                  };

            // Mock the behavior of Dapper's QuerySingleOrDefaultAsync method to return a predefined SpinDto
            var expectedSpinDto = new SpinDto
                                      {
                                          amount = 1
                                      };
            _contextMock.Setup(m => m.CreateConnection().QuerySingleOrDefaultAsync<SpinDto>(It.IsAny<string>(), It.IsAny<object>(), null, null, System.Data.CommandType.StoredProcedure))
                .ReturnsAsync(expectedSpinDto);

            // Act
            var result =  _gameRepository.ShowPreviousSpins(spinHistory);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Spin_ShouldReturnPlayerDto()
        {
            // Arrange
            var spinRequest = new SpinRequestDto
                                  {
                                      PlayerId = "1"
                                  };

            // Mock the behavior of Dapper's QuerySingleAsync method to return a predefined PlayerDto
            //var expectedPlayerDto = new PlayerDto
            //                            {
                                            
            //                            };
            //_contextMock.Setup(m => m.CreateConnection().QuerySingleAsync<PlayerDto>(It.IsAny<string>(), It.IsAny<object>(), null, null, System.Data.CommandType.StoredProcedure))
            //    .ReturnsAsync(expectedPlayerDto);

            // Act
            var result =  _gameRepository.Spin(spinRequest);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}