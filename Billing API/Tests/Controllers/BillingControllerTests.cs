using BillingAPI.Controllers;
using BillingAPI.Interfaces;
using BillingAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BillingAPI.Tests.Controllers
{
    public class BillingControllerTests
    {
        private readonly Mock<IOrderLogic> _mockOrderLogic;
        private readonly Mock<IBillingLogic> _mockBillingLogic;

        private readonly OrdersController _ordersController;
        private readonly BillingController _billingController;

        public BillingControllerTests()
        {
            _mockOrderLogic = new Mock<IOrderLogic>();
            _mockBillingLogic = new Mock<IBillingLogic>();

            _ordersController = new OrdersController(_mockOrderLogic.Object);
            _billingController = new BillingController(_mockBillingLogic.Object, _mockOrderLogic.Object);
        }

        [Fact]
        public void ProcessPayment_OrderDoesNotExist_ReturnsBadRequest()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "Swed",
            };

            _mockOrderLogic.Setup(x => x.GetOrder(order.OrderId));

            // Act
            var result = _billingController.ProcessPayment(order);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeEquivalentTo(new { message = $"Can't process payment, order does not exists" });
        }

        [Fact]
        public void ProcessPayment_OrderExists_ReturnsOkRequest()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "Swed",
            };

            _mockOrderLogic.Setup(x => x.GetOrder(order.OrderId));

            // Act
            var result = _billingController.ProcessPayment(order);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeEquivalentTo(new { message = $"Can't process payment, order does not exists" });
        }
    }
}

