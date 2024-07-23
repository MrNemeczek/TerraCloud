using AutoMapper;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Domain.Models.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Queries
{
    internal class GetUserDevices : IGetUserDevices
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetUserDevices(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDeviceResponse>> Execute(Guid userGuid)
        {
            IEnumerable<UserDevice> userDevices = await _deviceRepository.GetUserDevices(userGuid);
            IEnumerable<UserDeviceResponse> response = userDevices.Select(ud => _mapper.Map<UserDeviceResponse>(ud));

            return response;
        }
    }
}
