using Microsoft.AspNetCore.Mvc;
using BillingAPI.Models;
using BillingAPI.Interfaces;

namespace BillingAPI.Controllers
{
    /// <summary>
    /// Controller for order handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderLogic _orderLogic;

        public OrdersController(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        /// <summary>
        /// Creates new order, if order data is valid.
        /// </summary>
        /// <param name="order">Data used for order creation.</param>
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (!_orderLogic.IsOrderValid(order))
            {
                return BadRequest(new { message = $"Failed to create the order {order.OrderId}, order is invalid" });
            }

            return Ok(new { message = $"Order with ID {order.OrderId} is created." });
        }

        /// <summary>
        /// Gets order based on orderId.
        /// </summary>
        /// <param name="orderId">OrderId to get</param>
        [HttpGet]
        public IActionResult GetOrder(int orderId)
        {
            var order = _orderLogic.GetOrder(orderId);

            if (order == null)
            {
                return NotFound(new { message = $"Order with ID {orderId} not found." });
            }

            return Ok(order);
        }
    }
}
