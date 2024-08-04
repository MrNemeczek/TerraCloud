using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.DTOs.Auth.Requests;
using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Domain.Models.Animal;
using TerraCloud.Domain.Models.Device;
using TerraCloud.Domain.Models.User;
using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Auth
            CreateMap<User, JwtUser>();
            CreateMap<RegisterRequest, User>();

            //Device
            CreateMap<Domain.Models.Device.Device, DeviceResponse>();
            CreateMap<UserDevice, UserDeviceResponse>();
            CreateMap<AddDeviceRequest, Domain.Models.Device.Device>();
            CreateMap<AddUserDeviceRequest, UserDevice>();
            CreateMap<UpdateUserDeviceRequest, UserDevice>();
            CreateMap<AddDeviceMeasurementRequest, DeviceMonitor>();
            CreateMap<DeviceMonitor, DeviceSingleMeasurementResponse>();
            CreateMap<UserDeviceResponse, UpdateUserDeviceRequest>();
            CreateMap<UpdateUserDeviceRequest, Domain.Models.Device.Device>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<DeviceResponse, UpdateUserDeviceRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Domain.Models.Device.Device, UserDeviceResponse>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //Animal
            CreateMap<Domain.Models.Animal.Animal, GetAnimalResponse>();
            CreateMap<AnimalUser, GetUserAnimalResponse>()
                .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Animal.Species))
                .ForMember(dest => dest.DayHumidity, opt => opt.MapFrom(src => src.Animal.DayHumidity))
                .ForMember(dest => dest.DayTemperature, opt => opt.MapFrom(src => src.Animal.DayTemperature))
                .ForMember(dest => dest.NightHumidity, opt => opt.MapFrom(src => src.Animal.NightHumidity))
                .ForMember(dest => dest.NightTemperature, opt => opt.MapFrom(src => src.Animal.NightTemperature));
            CreateMap<AddAnimalUserRequest,  Domain.Models.Animal.Animal>();
            CreateMap<UpdateAnimalRequest,  Domain.Models.Animal.Animal>();
            CreateMap<GetAnimalResponse, UpdateAnimalRequest>();
        }
    }
}
