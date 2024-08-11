using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions.Device
{
    public sealed class DeviceAlreadyAddedException : MyApplicationException
    {
        public DeviceAlreadyAddedException(Guid deviceId, Guid userId) : base($"Device with ID: {deviceId} is already added to user with ID: {userId}", ErrorCode.DeviceAlreadyAdded, HttpStatusCode.Conflict)
        {
            
        }
    }
}
