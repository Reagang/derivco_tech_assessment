using Contracts;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.Payment;

namespace UnitTests.Repositories
{
    using Contracts;

    using Dapper;

    using Microsoft.AspNetCore.Mvc;

    using Respository;

    using Shared.DataTransferObjects.Payment;

    public class PaymentRepositoryTests
    {
        private PaymentRepository _paymentRepository;
        private Mock<DapperContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _contextMock = new Mock<DapperContext>();
            _paymentRepository = new PaymentRepository(_contextMock.Object);
        }

        [Test]
        public async Task Payout_ShouldExecuteQuery()
        {
            // Arrange
            var payoutRequest = new PayoutRequestDto
                                    {
                                        PlayerId = "1"
                                    };

            // Mock the behavior of Dapper's ExecuteAsync method to return a predefined number of affected rows
            _contextMock.Setup(m => m.CreateConnection().ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, System.Data.CommandType.StoredProcedure))
                .ReturnsAsync(1); // Assuming one row was affected

            // Act
            await _paymentRepository.Payout(payoutRequest);

        }
    }
}