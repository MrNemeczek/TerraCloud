namespace TerraCloud.Application.Exceptions.Device
{
    internal class DeviceNotFoundException : Exception
    {
        public DeviceNotFoundException(string DeviceUniqueCode) : base($"Device: {DeviceUniqueCode} not found!")
        { 
        }
        public DeviceNotFoundException(Guid DeviceId) : base($"Device with ID: {DeviceId} not found!")
        {
        }
    }
}
