using BillingAPI.Interfaces;
using BillingAPI.Models;

namespace BillingAPI.Logic
{
    /// <summary>
    /// Logic for billing handling.
    /// </summary>
    public class BillingLogic : IBillingLogic
    {
        /// <summary>
        /// Logic for payment processing.
        /// </summary>
        /// <param name="order">Order data used for payment processing.</param>
        /// <returns>If payment processing successful true else false.</returns>
        public bool ProcessPayment(Order order)
        {
            // Lets just assume that payment is always 1000% succesfull and imagine this is integrated card processing
            return true;
        }

        /// <summary>
        /// Adds receipt for an order.
        /// </summary>
        /// <param name="order">Order data used for receipt creation.</param>
        public Receipt CreateReceipt(Order order)
        {
            return new Receipt
            {
                ReceiptId = new Random().Next(1, 101),
                OrderId = order.OrderId,
                TransactionId = new Random().Next(1, 101).ToString() + "XYC-INTERNATIONAL",
                IsPaid = true,
                PaymentDate = DateTimeOffset.Now
            };
        }
    }
}
