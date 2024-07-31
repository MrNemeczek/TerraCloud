using AutoMapper;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.Exceptions.Device;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class UpdateUserDevice : IUpdateUserDevice
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDatabaseRepository _databaseRepository;
        public UpdateUserDevice(IMapper mapper, IDeviceRepository deviceRepository, IDatabaseRepository databaseRepository)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            _databaseRepository = databaseRepository;
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
        }
    }
}
