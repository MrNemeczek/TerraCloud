using AutoMapper;

using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Queries
{
    internal class GetDevices : IGetDevices
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetDevices(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeviceResponse>> Execute()
        {
            IEnumerable<Domain.Models.Device.Device> devices = await _deviceRepository.GetDevices();
            IEnumerable<DeviceResponse> response = devices.Select(d => _mapper.Map<DeviceResponse>(d));

            return response;
        }
    }
}
