using TerraCloud.Application.DTOs.Device.Responses;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IGetUserDevices
    {
        Task<IEnumerable<UserDeviceResponse>> Execute(Guid userGuid);
    }
}
