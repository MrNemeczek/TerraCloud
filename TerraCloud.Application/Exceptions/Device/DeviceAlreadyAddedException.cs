namespace TerraCloud.Application.Exceptions.Device
{
    public sealed class DeviceAlreadyAddedException : Exception
    {
        public DeviceAlreadyAddedException(Guid deviceId, Guid userId) : base($"Device with ID: {deviceId} is already added to user with ID: {userId}")
        {
            
        }
    }
}
