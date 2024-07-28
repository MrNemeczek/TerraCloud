using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Application.Exceptions.Device;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Queries
{
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

            UserDeviceResponse response = _mapper.Map<UserDeviceResponse>(userDevice);
            return response;
        }
    }
}
