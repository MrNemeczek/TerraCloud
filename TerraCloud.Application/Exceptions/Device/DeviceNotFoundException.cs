using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions.Device
{
    internal class DeviceNotFoundException : MyApplicationException
    {
        public DeviceNotFoundException(string DeviceUniqueCode) : base($"Device: {DeviceUniqueCode} not found!", ErrorCode.DeviceNotFound, HttpStatusCode.NotFound)
        { 
        }
        public DeviceNotFoundException(Guid DeviceId) : base($"Device with ID: {DeviceId} not found!", ErrorCode.DeviceNotFound, HttpStatusCode.NotFound)
        {
        }
    }
}
