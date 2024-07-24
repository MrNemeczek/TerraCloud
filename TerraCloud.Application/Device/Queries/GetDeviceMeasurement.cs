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
    internal class GetDeviceMeasurement : IGetDeviceMeasurement
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;

        public GetDeviceMeasurement(IMapper mapper, IDeviceRepository deviceRepository)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
        }

        public async Task<DeviceMeasurementResponse> Execute(Guid deviceId, Guid userId)
        {
            var device = await _deviceRepository.GetDeviceById(deviceId, userId);
            if(device is null)
            {
                throw new DeviceNotFoundException(deviceId);
            }

            var deviceMeasurements = await _deviceRepository.GetDeviceMonitors(deviceId);
            
            DeviceMeasurementResponse response = new();
            response.deviceMeasurements = deviceMeasurements.Select(dm => _mapper.Map<DeviceSingleMeasurementResponse>(dm));
            var userDevice = device.UserDevices.SingleOrDefault(ud => ud.UserId == userId);
            response.DeviceName = userDevice.Name;
            response.DeviceId = userDevice.DeviceId;

            return response;
        }
    }
}
