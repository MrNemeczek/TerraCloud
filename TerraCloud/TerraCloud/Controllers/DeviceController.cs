using Microsoft.AspNetCore.Mvc;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Interfaces.Device;

namespace TerraCloud.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IGetDevice _getDevice;
        private readonly IGetDevices _getDevices;

        public DeviceController(IGetDevice getDevice, IGetDevices getDevices)
        {
            _getDevice = getDevice;
            _getDevices = getDevices;
        }
        #region GET
        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var response = await _getDevices.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice([FromRoute] Guid id)
        {
            DeviceResponse response = await _getDevice.Execute(id); 

            return Ok(response);
        }
        #endregion
        #region POST
        [HttpPost]
        public async Task<IActionResult> AddDevice()
        {


            return Created();
        }
        #endregion
    }
}
