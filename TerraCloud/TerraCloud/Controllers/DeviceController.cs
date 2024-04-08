using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.DTOs.Error;
using TerraCloud.Application.Interfaces.Device;

namespace TerraCloud.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IGetDevice _getDevice;
        private readonly IGetDevices _getDevices;
        private readonly IAddDevice _addDevice;
        private readonly IDeleteDevice _deleteDevice;

        public DeviceController(IGetDevice getDevice, IGetDevices getDevices, IAddDevice addDevice)
        {
            _getDevice = getDevice;
            _getDevices = getDevices;
            _addDevice = addDevice;
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
        public async Task<IActionResult> AddDevice([FromBody] AddDeviceRequest request)
        {
            await _addDevice.Execute(request);

            return Created();
        }
        #endregion
        #region DELETE
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDevice([FromRoute] string Id)
        {
            try
            {
                await _deleteDevice.Execute(Id);
            }
            catch (ApplicationException)
            {
                var errorResponse = new ErrorResponse()
                {
                    Describe = "Aplication error",
                    ErrorCode = ErrorCode.ApplicationError
                };
                return BadRequest(errorResponse);
            }

            return NoContent();
        }
        #endregion
    }
}
