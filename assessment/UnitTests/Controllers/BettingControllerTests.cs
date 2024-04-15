using api.Controllers;
using Moq;
using Service.Contracts;

namespace UnitTests.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Shared.DataTransferObjects.Betting;

    public class BettingControllerTests
    {
        private BettingController _bettingController;
        private Mock<IServiceManager> _serviceManagerMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _serviceManagerMock = new Mock<IServiceManager>();
            _bettingController = new BettingController(_serviceManagerMock.Object);
        }

        [Test]
        public void PlaceBet_WithValidRequest_ShouldReturnOk()
        {
            // Arrange
            var request = new PlaceBetRequestDto
            {
                PlayerId = "1",
                BetAmount = 5,
                BetNumber = 11,
                BetType = "Something"
            };

            // Mock the behavior of the BettingService.PlaceBet method
            //_serviceManagerMock.Setup(m => m.BettingService.PlaceBet(It.IsAny<PlaceBetRequestDto>()))
            //    .Returns(/* the expected result should be added here*/);

            // Act
            var response = _bettingController.PlaceBet(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void PlaceBet_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            var request = new PlaceBetRequestDto
            {
                PlayerId = "1",
                BetAmount = 5,
                BetNumber = 11,
                BetType = "Something"
            };

            // Mock the behavior of the BettingService.PlaceBet method to throw an exception
            _serviceManagerMock.Setup(m => m.BettingService.PlaceBet(It.IsAny<PlaceBetRequestDto>()))
                .Throws(new Exception("Simulated exception"));

            // Act
            var response = _bettingController.PlaceBet(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(response);
            var statusCodeResult = response as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}