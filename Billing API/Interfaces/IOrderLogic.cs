using BillingAPI.Models;
namespace BillingAPI.Interfaces
{
    /// <summary>
    /// Interface for order handling.
    /// </summary>
    public interface IOrderLogic
    {
        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="order">Order data used for order creation.</param>
        /// <returns>Receipt if order is processed, error on failure</returns>
        public Order? CreateOrder(Order order);

        /// <summary>
        /// Gets order by it's id.
        /// </summary>
        /// <param name="orderId">Order id.</param>
        public Order? GetOrder(int orderId);

        /// <summary>
        /// Boolean indicating if order is valid or not
        /// </summary>
        public bool IsOrderValid(Order order);
    }
}
