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
    public interface IAddDeviceMeasurement
    {
        Task Execute(AddDeviceMeasurementRequest request);
    }
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

        public async Task Execute(AddDeviceMeasurementRequest request)
        {
            var device = await _deviceRepository.GetDeviceByUniqueCode(request.UniqueCode);
            if (device is null)
            {
                throw new DeviceNotFoundException(request.UniqueCode);
            }

            var deviceMonitor = _mapper.Map<DeviceMonitor>(request);
            deviceMonitor.DeviceId = device.Id;

            await _deviceRepository.AddDeviceMeasurment(deviceMonitor);
            
            device.LastMeasurement = DateTime.UtcNow;
            _deviceRepository.UpdateDevice(device);

            await _databaseRepository.SaveChangesAsync();
        }
    }
}
