using api.Controllers;
using Moq;
using Service.Contracts;

namespace UnitTests.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Shared.DataTransferObjects.Payment;

    public class PaymentControllerTests
    {
        private PaymentController _paymentController;
        private Mock<IServiceManager> _serviceManagerMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _serviceManagerMock = new Mock<IServiceManager>();
            _paymentController = new PaymentController(_serviceManagerMock.Object);
        }

        [Test]
        public void Payout_WithValidRequest_ShouldReturnOk()
        {
            // Arrange
            var payoutRequest = new PayoutRequestDto
            {
                PlayerId = "1"
            };

            // Mock the behavior of the PaymentService.Payout method
            //_serviceManagerMock.Setup(m => m.PaymentService.Payout(It.IsAny<PayoutRequestDto>()))
            //.Returns(/* Mock the expected result */);

            // Act
            var response = _paymentController.Payout(payoutRequest);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void Payout_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            var payoutRequest = new PayoutRequestDto
            {
                PlayerId = "1"
            };

            // Mock the behavior of the PaymentService.Payout method to throw an exception
            _serviceManagerMock.Setup(m => m.PaymentService.Payout(It.IsAny<PayoutRequestDto>()))
                .Throws(new Exception("Simulated exception"));

            // Act
            var response = _paymentController.Payout(payoutRequest);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(response);
            var statusCodeResult = response as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}