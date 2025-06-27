using DocumentFormat.OpenXml.Wordprocessing;
using Swashbuckle.AspNetCore.Annotations;

namespace ITSupportSystem.Models
{
    /// <summary>
    /// Represents It support data.
    /// </summary>
    public class ITSupport
    {
        /// <summary>
        /// ITSupportRequest identifier.
        /// </summary>
        public required long ItSupportRequestId { get; set; }

        /// <summary>
        /// IT support system user identifier.
        /// </summary>
        public required long UserId { get; set; }

        /// <summary>
        /// Indicates if request is system.
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Indicates if request is module.
        /// </summary>
        public bool IsModule { get; set; }

        /// <summary>
        /// Mandatory description of an request.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Optimal reproduction steps.
        /// </summary>
        public string? ReproductionSteps { get; set; }

        /// <summary>
        /// Expected behaviour result.
        /// </summary>
        public string? ExpectedResult { get; set; }

        /// <summary>
        /// Support request priority. Either - low, medium, high.
        /// </summary>
        public string? Priority { get; set; }
    }
}
