using BillingAPI.Interfaces;
using BillingAPI.Logic;
using BillingAPI.Models;
using FluentAssertions;
using Xunit;

namespace BillingAPI.Tests.Logic
{
    public class BillingLogicTests
    {
        private readonly BillingLogic _billingLogic;

        public BillingLogicTests()
        {
            _billingLogic = new BillingLogic();
        }

        // TODO: Update tests and add fail scenario when payment gateway processing implemented
        [Fact]
        public void ProcessPayment_ProcessedSuccessfully_ReturnsTrue()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                PaymentGateway = "ApplePay",
            };

            // Act
            bool result = _billingLogic.ProcessPayment(order);

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void CreateReceipt_CreatedReceiptFromOrderSuccessfuly_ReturnsCreatedReceipt()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 123456,
                PaymentGateway = "ApplePay",
                PayableAmount = 111.11m,
            };

            // Act
            Receipt result = _billingLogic.CreateReceipt(order);

            // Assert
            result.Should().NotBeNull();
            result.ReceiptId.Should().NotBe(null);
            result.OrderId.Should().Be(order.OrderId);
            result.PaidAmmount.Should().Be(order.PayableAmount);
            result.TransactionId.Should().NotBe(null);
            result.IsPaid.Should().BeTrue();
            result.PaymentDate.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
        }
    }
}
