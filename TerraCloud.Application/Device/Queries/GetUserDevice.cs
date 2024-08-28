using AutoMapper;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Exceptions.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Queries
{
    public interface IGetUserDevice
    {
        Task<UserDeviceResponse> Execute(Guid userDeviceId, Guid userId);
    }
    internal class GetUserDevice : IGetUserDevice
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetUserDevice(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<UserDeviceResponse> Execute(Guid userDeviceId, Guid userId)
        {
            var userDevice = await _deviceRepository.GetUserDeviceById(userId, userDeviceId);
            if(userDevice is null)
            {
                throw new DeviceNotFoundException(userDeviceId);
            }

            var device = await _deviceRepository.GetDeviceById(userDevice.DeviceId);

            UserDeviceResponse response = _mapper.Map<UserDeviceResponse>(userDevice);
            response = _mapper.Map(device, response);

            return response;
        }
    }
}
