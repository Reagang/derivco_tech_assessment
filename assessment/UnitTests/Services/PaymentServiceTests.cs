using Contracts;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.Payment;

namespace UnitTests.Services
{
    using Contracts;
    using Microsoft.AspNetCore.Mvc;

    using Shared.DataTransferObjects.Payment;

    public class PaymentServiceTests
    {
        private IPaymentService _paymentService;
        private Mock<IRepositoryManager> _repositoryManagerMock;
        private Mock<ILoggerManager> _loggerManagerMock;

        [SetUp]
        public void Setup()
        {// Arrange
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _loggerManagerMock = new Mock<ILoggerManager>();
        }

        [Test]
        public async Task Payout_ShouldCallRepositoryPayout()
        {
            // Arrange
            var payoutRequest = new PayoutRequestDto
                                    {
                                        PlayerId = "1"
                                    };

            // Act
            await _paymentService.Payout(payoutRequest);

            // Assert
            _repositoryManagerMock.Verify(m => m.Payment.Payout(payoutRequest), Times.Once);
        }
    }
}