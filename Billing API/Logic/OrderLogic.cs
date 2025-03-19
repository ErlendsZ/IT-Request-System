using BillingAPI.Interfaces;
using BillingAPI.Models;

namespace BillingAPI.Logic
{
    /// <summary>
    /// Logic for order handling.
    /// </summary>
    public class OrderLogic : IOrderLogic
    {
        //DB NOT IMPLEMENTED. FOLLOWING CODE USED FOR API TESTING.
        private static List<Order> _orders = new List<Order>();

        /// <summary>
        /// Creates an order.
        /// </summary>
        /// <param name="order">New order</param>
        /// <returns>Created order.</returns>
        public Order? CreateOrder(Order order)
        {
            _orders.Add(order);

            return order;
        }

        /// <summary>
        /// Gets order by its id.
        /// </summary>
        /// <param name="orderId">Order identifier</param>
        /// <returns>Requested order or null if not found.</returns>
        public Order? GetOrder(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        /// <summary>
        /// Validates if order is created sucessfully.
        /// </summary>
        /// <param name="order">Order to validate.</param>
        public bool IsOrderValid(Order? order)
        {
            if (order == null || order.PaymentGateway == "FailingGateway") // "FailingGateway", used for testing purposes, to get failing order.
            {
                return false;
            }

            return true;
        }
    }
}
