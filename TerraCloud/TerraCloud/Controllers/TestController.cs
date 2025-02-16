using Microsoft.AspNetCore.Mvc;

using TerraCloud.Application.Test;

namespace TerraCloud.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        [HttpGet("Test")]
        public async Task<IActionResult> Login([FromServices] ITestMapping testMapping)
        {
            var response = await testMapping.ExecuteAsync();

            return Ok(response);
        }

    }
}
