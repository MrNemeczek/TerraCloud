using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.DTOs.Error;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Server.Common;

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
        private readonly IAddUserDevice _addUserDevice;
        private readonly IDeleteDevice _deleteDevice;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IGetUserDevices _getUserDevices;
        private readonly IUpdateUserDevice _updateUserDevice;

        public DeviceController(IGetDevice getDevice, IGetDevices getDevices, IAddDevice addDevice, IDeleteDevice deleteDevice, IHttpContextAccessor contextAccessor, IGetUserDevices getUserDevices, IAddUserDevice addUserDevice, IUpdateUserDevice updateUserDevice)
        {
            _getDevice = getDevice;
            _getDevices = getDevices;
            _addDevice = addDevice;
            _deleteDevice = deleteDevice;
            _contextAccessor = contextAccessor;
            _getUserDevices = getUserDevices;
            _addUserDevice = addUserDevice;
            _updateUserDevice = updateUserDevice;
        }

        [HttpGet("Device")]
        public async Task<IActionResult> GetDevices()
        {
            var response = await _getDevices.Execute();

            return Ok(response);
        }

        [HttpGet("UserDevice")]
        public async Task<IActionResult> GetUserDevices()
        {
            Guid userGuid = _contextAccessor.GetUserGuid();
            var response = await _getUserDevices.Execute(userGuid);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice([FromRoute] Guid id)
        {
            DeviceResponse response = await _getDevice.Execute(id); 

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] AddDeviceRequest request)
        {
            await _addDevice.Execute(request);

            return Created();
        }
        [HttpPost("UserDevice")]
        public async Task<IActionResult> AddUserDevice([FromBody] AddUserDeviceRequest request)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _addUserDevice.Execute(request, userId);

            return Created();
        }
        [HttpPatch("UserDevice")]
        public async Task<IActionResult> UpdateUserDevice([FromBody] UpdateUserDeviceRequest request)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _updateUserDevice.Execute(request, userId);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice([FromRoute] string id)
        {
            try
            {
                await _deleteDevice.Execute(id);
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
    }
}
