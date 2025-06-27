using ITSupportSystem.Models;
namespace ITSupportSystem.Interfaces
{
    /// <summary>
    /// Interface for IT Support Request.
    /// </summary>
    public interface IITsupportLogic
    {
        /// <summary>
        /// Creates a new It support request.
        /// </summary>
        /// <param name="iTSupportRequest">iTSupportRequest data used for IT Support Request creation.</param>
        /// <returns>AIResponse if iTSupportRequest is processed, error on failure</returns>
        public ITSupport? CreateITSupportRequest(ITSupport iTSupportRequest);

        /// <summary>
        /// Gets It support request by it's id.
        /// </summary>
        /// <param name="iTSupportRequestId">IT support request id.</param>
        public ITSupport? GetITSupportRequest(long iTSupportRequestId);

        /// <summary>
        /// Boolean indicating if supportRequest is valid or not.
        /// <param name="supportRequest">support request.</param>
        /// </summary>
        public bool IsUserSupportRequestValid(ITSupport supportRequest);
    }
}
