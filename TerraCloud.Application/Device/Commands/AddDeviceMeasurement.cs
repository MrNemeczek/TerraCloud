using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.Exceptions.Device;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Domain.Models.Device;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class AddDeviceMeasurement : IAddDeviceMeasurement
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMapper _mapper;

        public AddDeviceMeasurement(IDeviceRepository deviceRepository, IDatabaseRepository databaseRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _databaseRepository = databaseRepository;
            _mapper = mapper;
        }

        public async Task Execute(AddDeviceMeasurementRequest request, Guid userId)
        {
            var device = await _deviceRepository.GetDeviceById(request.DeviceId, userId);
            if (device is null)
            {
                throw new DeviceNotFoundException(request.DeviceId);
            }

            var deviceMonitor = _mapper.Map<DeviceMonitor>(request);

            await _deviceRepository.AddDeviceMeasurment(deviceMonitor);
            
            device.LastMeasurement = DateTime.UtcNow;
            _deviceRepository.UpdateDevice(device);

            await _databaseRepository.SaveChangesAsync();
        }
    }
}
