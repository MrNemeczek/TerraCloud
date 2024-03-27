using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Domain.Models.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Queries
{
    internal class GetDevice : IGetDevice
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetDevice(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<DeviceResponse> Execute(Guid deviceId)
        {
            Domain.Models.Device.Device device = await _deviceRepository.GetDevice(deviceId);
            DeviceResponse response = _mapper.Map<DeviceResponse>(device);

            return response;
        }
    }
}
