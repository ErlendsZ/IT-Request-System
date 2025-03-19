using DocumentFormat.OpenXml.Wordprocessing;
using Swashbuckle.AspNetCore.Annotations;

namespace BillingAPI.Models
{
    /// <summary>
    /// Represents order data.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order identifier.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Total ammout of money that user needs to pay.
        /// </summary>
        public decimal PayableAmount { get; set; }

        /// <summary>
        /// Identifier of a particular payment provider.
        /// </summary>
        public required string PaymentGateway {  get; set; }

        /// <summary>
        /// Optional description of an order.
        /// </summary>
        public string? Description { get; set; }

    }
}
