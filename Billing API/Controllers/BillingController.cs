using Microsoft.AspNetCore.Mvc;
using BillingAPI.Models;
using BillingAPI.Interfaces;

namespace BillingAPI.Controllers
{
    /// <summary>
    /// Controller for billing handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingLogic _billingLogic;
        private readonly IOrderLogic _orderLogic;

        public BillingController(IBillingLogic billingLogic, IOrderLogic orderLogic)
        {
            _billingLogic = billingLogic;
            _orderLogic = orderLogic;
        }

        /// <summary>
        /// Proceses payment of the order.
        /// </summary>
        /// <param name="order">Order information, used for payment processing.</param>
        [HttpPost("processPayment")]
        public IActionResult ProcessPayment([FromBody] Order order)
        {
            var createdOrder = _orderLogic.GetOrder(order.OrderId);

            if (createdOrder == null)
            {
                return BadRequest(new { message = "Can't process payment, order does not exists" });
            }

            if (_billingLogic.ProcessPayment(order))
            {
                var receipt = _billingLogic.CreateReceipt(createdOrder);
                return Ok(receipt);
            }
            else
            {
                return BadRequest(new { message = "Failed payment" });
            }
        }

    }
}
