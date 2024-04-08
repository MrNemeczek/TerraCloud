namespace TerraCloud.Application.Interfaces.Device
{
    public interface IDeleteDevice
    {
        Task Execute(string deviceId);
    }
}
