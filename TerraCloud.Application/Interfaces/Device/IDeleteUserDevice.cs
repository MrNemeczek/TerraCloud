namespace TerraCloud.Application.Interfaces.Device
{
    public interface IDeleteUserDevice
    {
        Task Execute(string userDeviceId, Guid userId);
    }
}
