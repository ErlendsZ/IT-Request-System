using Microsoft.AspNetCore.Mvc;
using ITSupportSystem.Models;
using ITSupportSystem.Interfaces;

namespace ITSupportSystem.Controllers
{
    /// <summary>
    /// Controller for Ai logic handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AiAnalysisController : ControllerBase
    {
        private readonly IAiAnalysisLogic _aiAnalysisLogic;
        private readonly IITsupportLogic _iTSupportRequestLogic;

        public AiAnalysisController(IAiAnalysisLogic aiAnalysisLogic, IITsupportLogic iTSupportRequestLogic)
        {
            _aiAnalysisLogic = aiAnalysisLogic;
            _iTSupportRequestLogic = iTSupportRequestLogic;
        }

        /// <summary>
        /// Retrieves response using AI logic based un user support request.
        /// </summary>
        /// <param name="supportRequest">ITSupportRequest information, used for payment processing.</param>
        [HttpGet("AiSupportReport")]
        public async Task<IActionResult> ProcessITSupportRequest([FromQuery] ITSupport supportRequest)
        {
            var userSupportRequest = _iTSupportRequestLogic.GetITSupportRequest(supportRequest.ItSupportRequestId);

            if (userSupportRequest == null)
            {
                return BadRequest(new { message = "Can't retrieve support request, request ID does not exists" });
            }

            var result = await _aiAnalysisLogic.GetAIResponseAsync(userSupportRequest);
            return Ok(result);
        }

    }
}
