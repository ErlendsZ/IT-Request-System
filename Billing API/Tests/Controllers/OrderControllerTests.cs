using BillingAPI.Controllers;
using BillingAPI.Interfaces;
using BillingAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BillingAPI.Tests.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderLogic> _mockOrderLogic;
        private readonly OrdersController _ordersController;

        public OrderControllerTests()
        {
            _mockOrderLogic = new Mock<IOrderLogic>();
            _ordersController = new OrdersController(_mockOrderLogic.Object);
        }

        [Fact]
        public void CreateOrder_OrderIsValid_ReturnsOkResult()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "Swedbank",
            };

            _mockOrderLogic.Setup(o => o.IsOrderValid(order)).Returns(true);
            _mockOrderLogic.Setup(o => o.CreateOrder(order)).Returns(order);

            // Act
            var result = _ordersController.CreateOrder(order);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(new { message = $"Order with ID {order.OrderId} is created." });
        }

        [Fact]
        public void CreateOrder_OrderIsInvalid_ReturnsBadRequest()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "InvalidPaymentGateway",
            };

            _mockOrderLogic.Setup(o => o.IsOrderValid(order)).Returns(false);

            // Act
            var result = _ordersController.CreateOrder(order);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeEquivalentTo(new { message = $"Failed to create the order {order.OrderId}, order is invalid" });
        }

        [Fact]
        public void GetOrder_OrderIdExists_OrderIsReturned()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "Swedbank",
            };

            _mockOrderLogic.Setup(x => x.GetOrder(order.OrderId)).Returns(order);

            // Act
            var result = _ordersController.GetOrder(order.OrderId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetOrder_OrderIdDoesNotExists_OsrderNotFound()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "Swedbank",
            };

            _mockOrderLogic.Setup(x => x.GetOrder(order.OrderId)).Returns(order);

            // Act
            var result = _ordersController.GetOrder(96);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
