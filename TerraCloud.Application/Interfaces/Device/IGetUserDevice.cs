using TerraCloud.Application.DTOs.Device.Responses;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IGetUserDevice
    {
        Task<UserDeviceResponse> Execute(Guid userDeviceId, Guid userId);
    }
}
