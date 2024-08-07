using AutoMapper;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.Exceptions.Device;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class AddUserDevice : IAddUserDevice
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public AddUserDevice(IMapper mapper, IDeviceRepository deviceRepository, IDatabaseRepository databaseRepository)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            _databaseRepository = databaseRepository;
        }

        public async Task Execute(AddUserDeviceRequest request, Guid userId)
        {
            var device = await _deviceRepository.GetDeviceByUniqueCode(request.UniqueCode);
            if(device is null)
            {
                throw new DeviceNotFoundException(request.UniqueCode);
            }

            if(device.UserDevices.Any(ud => ud.UserId == userId))
            {
                throw new DeviceAlreadyAddedException(device.Id, userId);
            }
            
            var deviceToAdd = _mapper.Map<Domain.Models.Device.UserDevice>(request);
            deviceToAdd.DeviceId = device.Id;
            deviceToAdd.UserId = userId;

            await _deviceRepository.AddUserDevice(deviceToAdd);
            await _databaseRepository.SaveChangesAsync();
        }
    }
}
