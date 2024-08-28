using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TerraCloud.Application.Device.Commands;
using TerraCloud.Application.Device.Queries;
using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Infrastructure.IoTHub;
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
        private readonly IDeleteUserDevice _deleteUserDevice;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IGetUserDevices _getUserDevices;
        private readonly IGetUserDevice _getUserDevice;
        private readonly IUpdateUserDevice _updateUserDevice;
        private readonly IAddDeviceMeasurement _addDeviceMeasurement;
        private readonly IGetDeviceMeasurement _getDeviceMeasurement;
        private readonly IIoTHubService _iotHubService;

        public DeviceController(IGetDevice getDevice, IGetDevices getDevices, IAddDevice addDevice, IDeleteDevice deleteDevice, IHttpContextAccessor contextAccessor, IGetUserDevices getUserDevices, IAddUserDevice addUserDevice, IUpdateUserDevice updateUserDevice, IDeleteUserDevice deleteUserDevice, IAddDeviceMeasurement addMeasurement, IGetDeviceMeasurement getDeviceMeasurement, IGetUserDevice getUserDevice, IIoTHubService iotHubService)
        {
            _getDevice = getDevice;
            _getDevices = getDevices;
            _addDevice = addDevice;
            _deleteDevice = deleteDevice;
            _contextAccessor = contextAccessor;
            _getUserDevices = getUserDevices;
            _addUserDevice = addUserDevice;
            _updateUserDevice = updateUserDevice;
            _deleteUserDevice = deleteUserDevice;
            _addDeviceMeasurement = addMeasurement;
            _getDeviceMeasurement = getDeviceMeasurement;
            _getUserDevice = getUserDevice;
            _iotHubService = iotHubService;
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
        [HttpGet("UserDevice/{id}")]
        public async Task<IActionResult> GetUserDevice([FromRoute] Guid id)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            UserDeviceResponse response = await _getUserDevice.Execute(id, userId);

            return Ok(response);
        }
        [HttpGet("Measurement/{id}")]
        public async Task<IActionResult> GetDeviceMeasurement([FromRoute] Guid id)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            DeviceMeasurementResponse response = await _getDeviceMeasurement.Execute(id, userId);

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
        [HttpPost("Measurement")]
        public async Task<IActionResult> AddMeasurement([FromBody] AddDeviceMeasurementRequest request)
        {
            await _addDeviceMeasurement.Execute(request);

            return Created();
        }
        [HttpPatch("UserDevice")]
        public async Task<IActionResult> UpdateUserDevice([FromBody] UpdateUserDeviceRequest request)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _updateUserDevice.Execute(request, userId);

            return Ok();
        }
        [HttpDelete("Device/{id}")]
        public async Task<IActionResult> DeleteDevice([FromRoute] string id)
        {
            await _deleteDevice.Execute(id);

            return NoContent();
        }
        [HttpDelete("UserDevice/{id}")]
        public async Task<IActionResult> DeleteUserDevice([FromRoute] string id)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _deleteUserDevice.Execute(id, userId);

            return NoContent();
        }
    }
}
