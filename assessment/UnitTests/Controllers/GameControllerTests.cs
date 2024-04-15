using api.Controllers;
using Moq;
using Service.Contracts;

namespace UnitTests.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shared.DataTransferObjects.Game;

    public class GameControllerTests
    {
        private GameController _gameController;
        private Mock<IServiceManager> _serviceManagerMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _serviceManagerMock = new Mock<IServiceManager>();
            _gameController = new GameController(_serviceManagerMock.Object);
        }

        [Test]
        public void Spin_WithValidRequest_ShouldReturnOk()
        {
            // Arrange
            var requestDto = new SpinRequestDto
            {
                // Initialize properties of request for testing
            };

            // Mock the behavior of the GameService.Spin method
            // _serviceManagerMock.Setup(m => m.GameService.Spin(It.IsAny<SpinRequestDto>()))
            //.Returns(/* Mock the expected result */);

            // Act
            var response = _gameController.Spin(requestDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void Spin_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            var requestDto = new SpinRequestDto
            {
                PlayerId = "1"
            };

            // Mock the behavior of the GameService.Spin method to throw an exception
            _serviceManagerMock.Setup(m => m.GameService.Spin(It.IsAny<SpinRequestDto>()))
                               .Throws(new Exception("Simulated exception"));

            // Act
            var response = _gameController.Spin(requestDto);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(response);
            var statusCodeResult = response as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }

        [Test]
        public void ShowPreviousSpins_WithValidRequest_ShouldReturnOk()
        {
            // Arrange
            var requestDto = new PreviousSpinRequestDto
            {
                PlayerId = "1"
            };

            // Mock the behavior of the GameService.ShowPreviousSpins method
            // _serviceManagerMock.Setup(m => m.GameService.ShowPreviousSpins(It.IsAny<PreviousSpinRequestDto>()))
            // .Returns(/* Mock the expected result */);

            // Act
            var response = _gameController.ShowPreviousSpins(requestDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void ShowPreviousSpins_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            var requestDto = new PreviousSpinRequestDto
            {
                PlayerId = "1"
            };

            // Mock the behavior of the GameService.ShowPreviousSpins method to throw an exception
            _serviceManagerMock.Setup(m => m.GameService.ShowPreviousSpins(It.IsAny<PreviousSpinRequestDto>()))
                               .Throws(new Exception("Simulated exception"));

            // Act
            var response = _gameController.ShowPreviousSpins(requestDto);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(response);
            var statusCodeResult = response as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}