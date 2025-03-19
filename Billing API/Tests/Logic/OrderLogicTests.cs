using BillingAPI.Logic;
using BillingAPI.Models;
using FluentAssertions;
using Xunit;

namespace BillingAPI.Tests.Logic
{
    public class OrderLogicTests
    {
        private readonly OrderLogic _orderLogic;

        public OrderLogicTests()
        {
            _orderLogic = new OrderLogic();
        }

        [Fact]
        public void IsOrderValid_OrderIsNull_ReturnsFalse()
        {
            // Arrange
            Order? order = null;

            // Act
            bool result = _orderLogic.IsOrderValid(order);

            // Assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData("SwedbankPayment", true)]
        [InlineData("FailingGateway", false)]
        public void IsOrderValid_MultipOrders_ReturnsExpectedResult(string paymentGateway, bool expectedResult)
        {
            // Arrange
            var order = new Order 
            {
                OrderId = 1,
                PaymentGateway = paymentGateway
            };

            // Act
            bool result = _orderLogic.IsOrderValid(order);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
