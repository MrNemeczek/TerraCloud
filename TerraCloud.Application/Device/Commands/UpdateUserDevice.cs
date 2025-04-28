using AutoMapper;
using System.Text;
using System.Text.Json;
using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.Exceptions.Device;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Infrastructure.IoTHub;
using TerraCloud.Infrastructure.Models.IoTHub;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class UpdateUserDevice : IUpdateUserDevice
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IIoTHubService _IoTHubService;
        public UpdateUserDevice(IMapper mapper, IDeviceRepository deviceRepository, IDatabaseRepository databaseRepository, IIoTHubService ioTHubService)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            _databaseRepository = databaseRepository;
            _IoTHubService = ioTHubService;
        }

        public async Task Execute(UpdateUserDeviceRequest request, Guid userId)
        {
            var userDevice = await _deviceRepository.GetUserDeviceById(userId, request.Id);
            if (userDevice is null)
            {
                throw new DeviceNotFoundException(request.Id);
            }

            var device = await _deviceRepository.GetDeviceById(userDevice.DeviceId);

            userDevice = _mapper.Map(request, userDevice);
            device = _mapper.Map(request, device);

            _deviceRepository.UpdateUserDevice(userDevice);
            _deviceRepository.UpdateDevice(device);

            await _databaseRepository.SaveChangesAsync();

            await SendMsgToDevice(device, request.TimeStampTest);
        }

        private async Task SendMsgToDevice(Domain.Models.Device.Device device, string? timeStampTest)
        {
            var updateClientDeviceRequest = _mapper.Map<UpdateClientDeviceRequest>(device);
            updateClientDeviceRequest.TimeStampTest = timeStampTest;

            string serializedRequest = JsonSerializer.Serialize(updateClientDeviceRequest);
            byte[] bytes = Encoding.UTF8.GetBytes(serializedRequest);

            await _IoTHubService.SendCloudToDeviceMessageAsync(bytes, device.UniqueCode);
        }
    }
}
