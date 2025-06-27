using Microsoft.AspNetCore.Mvc;
using ITSupportSystem.Models;
using ITSupportSystem.Interfaces;

namespace ITSupportSystem.Controllers
{
    /// <summary>
    /// Controller for supportRequest handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ITSupportController : ControllerBase
    {
        private readonly IITsupportLogic _iTsupporRequestLogic;

        public ITSupportController(IITsupportLogic iTsupporRequestLogic)
        {
            _iTsupporRequestLogic = iTsupporRequestLogic;
        }

        /// <summary>
        /// Creates new support request, if support request data is valid.
        /// </summary>
        /// <param name="supportRequest">Data used for supportRequest creation.</param>
        [HttpPost]
        public IActionResult CreateSupportRequest([FromBody] ITSupport supportRequest)
        {
            if (!_iTsupporRequestLogic.IsUserSupportRequestValid(supportRequest))
            {
                return BadRequest(new { message = $"Failed to create user request {supportRequest.ItSupportRequestId}, request is invalid, please check input data" });
            }

            _iTsupporRequestLogic.CreateITSupportRequest(supportRequest);

            return Ok(new { message = $"IT Support Request with ID {supportRequest.ItSupportRequestId} is created." });
        }

        /// <summary>
        /// Gets support request based on supportRequestId.
        /// </summary>
        /// <param name="supportRequestId">It Support Request Id to get</param>
        [HttpGet]
        public IActionResult GetITSupportRequestById([FromQuery] long supportRequestId)
        {
            var supportRequest = _iTsupporRequestLogic.GetITSupportRequest(supportRequestId);

            if (supportRequest == null)
            {
                return NotFound(new { message = $"IT Support Request with ID {supportRequestId} not found." });
            }

            return Ok(supportRequest);
        }
    }
}
