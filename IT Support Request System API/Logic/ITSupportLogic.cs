using ITSupportSystem.Interfaces;
using ITSupportSystem.Models;

namespace ITSupportSystem.Logic
{
    /// <summary>
    /// Logic for IT Support Request handling.
    /// </summary>
    public class ITSupportLogic : IITsupportLogic
    {
        //DB NOT IMPLEMENTED. FOLLOWING CODE USED FOR API TESTING.
        private static List<ITSupport> _iTSupportRequests = new List<ITSupport>();

        /// <summary>
        /// Creates a support request.
        /// </summary>
        /// <param name="supportRequest">New support request</param>
        /// <returns>Created support request.</returns>
        public ITSupport? CreateITSupportRequest(ITSupport supportRequest)
        {
            _iTSupportRequests.Add(supportRequest);

            return supportRequest;
        }

        /// <summary>
        /// Gets support request by its id.
        /// </summary>
        /// <param name="supportRequestId">ITSupportRequest identifier</param>
        /// <returns>Requested support request or null if not found.</returns>
        public ITSupport? GetITSupportRequest(long supportRequestId)
        {
            return _iTSupportRequests.FirstOrDefault(o => o.ItSupportRequestId == supportRequestId);
        }

        /// <summary>
        /// Validates if support request is created corectly.
        /// </summary>
        /// <param name="supportRequest">supportRequest to validate.</param>
        public bool IsUserSupportRequestValid(ITSupport? supportRequest)
        {
            if (supportRequest == null || supportRequest.Description == null || supportRequest.ExpectedResult == null || supportRequest.Priority == null)
            {
                return false;
            }

            return true;
        }
    }
}
