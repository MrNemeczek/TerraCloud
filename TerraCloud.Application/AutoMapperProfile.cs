using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.DTOs.Auth.Requests;
using TerraCloud.Application.DTOs.Device.Requests;
using TerraCloud.Application.DTOs.Device.Responses;
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

            //Animal
            CreateMap<Domain.Models.Animal.Animal, GetAnimalResponse>();
            CreateMap<AddAnimalRequest,  Domain.Models.Animal.Animal>();
        }
    }
}
