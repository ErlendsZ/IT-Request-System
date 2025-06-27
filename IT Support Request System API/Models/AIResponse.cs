namespace ITSupportSystem.Models
{
    /// <summary>
    /// Represents AI response data.
    /// </summary>
    public class AIResponse
    {
        /// <summary>
        /// IT support identifier.
        /// </summary>
        public long ItSupportId { get; set; }

        /// <summary>
        /// UserId identifier.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Ai generated request title.
        /// </summary>
        public string GeneratedRequestTitle { get; set; }

        /// <summary>
        /// Ai generated request title.
        /// </summary>
        public string GeneratedRequestType { get; set; }
    }
}
