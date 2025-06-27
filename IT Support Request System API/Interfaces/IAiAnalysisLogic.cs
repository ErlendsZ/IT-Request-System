using ITSupportSystem.Models;
namespace ITSupportSystem.Interfaces
{
    /// <summary>
    /// Interface for AI handling
    /// </summary>
    public interface IAiAnalysisLogic
    {
        /// <summary>
        /// Gets AI response.
        /// </summary>
        /// <param name="supportRequest">IT support request data used for receipt creation.</param>
        public Task<AIResponse> GetAIResponseAsync(ITSupport supportRequest);
    }
}
