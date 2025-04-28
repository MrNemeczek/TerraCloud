using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerraCloud.Application.DTOs.Test.Responses;

namespace TerraCloud.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("TimeStamp")]
        public async Task<IActionResult> GetTimeStamp()
        {
            var timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            var response = new TimeStampResponse
            {
                TimeStamp = timeStamp
            };

            return Ok(response);
        }
    }
}
