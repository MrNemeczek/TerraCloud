namespace TerraCloud.Infrastructure.IoTHub
{
    public interface IIoTHubService
    {
        Task SendCloudToDeviceMessageAsync(byte[] msg, string deviceUniqueCode);
    }
}
