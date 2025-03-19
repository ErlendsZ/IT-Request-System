namespace BillingAPI.Models
{
    /// <summary>
    /// Represents reiceipt data.
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Reciept identifier.
        /// </summary>
        public int ReceiptId { get; set; }

        /// <summary>
        /// Order identifier.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Transaction string issued by billing logic.
        /// </summary>
        public string? TransactionId { get; set; }

        /// <summary>
        /// Indicates if reciept is paid or not.
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// Date when payment was initiated.
        /// </summary>
        public DateTimeOffset PaymentDate { get; set; }
    }
}
