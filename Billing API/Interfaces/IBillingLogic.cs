using BillingAPI.Models;
namespace BillingAPI.Interfaces
{
    /// <summary>
    /// Interface for billing handling
    /// </summary>
    public interface IBillingLogic
    {
        /// <summary>
        /// Logic for payment processing.
        /// </summary>
        /// <param name="order">Order data used for receipt creation.</param>
        /// <returns>If payment processing successful true else false.</returns>
        public bool ProcessPayment(Order order);

        /// <summary>
        /// Adds receipt for an order.
        /// </summary>
        /// <param name="order">Order data used for receipt creation.</param>
        public Receipt CreateReceipt(Order order);
    }
}
