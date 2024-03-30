using AutoMapper;

using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.Device;

namespace TerraCloud.Application.Device.Commands
{
    internal class AddDevice : IAddDevice
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMapper _mapper;

        public AddDevice(IDeviceRepository deviceRepository, IMapper mapper, IDatabaseRepository databaseRepository)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _databaseRepository = databaseRepository;
        }

        public async Task Execute(AddDeviceRequest request)
        {
            var device = _mapper.Map<Domain.Models.Device.Device>(request);
            await _deviceRepository.AddDevice(device);
            await _databaseRepository.SaveChangesAsync();
        }
    }
}
