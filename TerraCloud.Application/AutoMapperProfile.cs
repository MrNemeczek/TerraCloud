using AutoMapper;

using TerraCloud.Application.DTOs.Auth.Request;
using TerraCloud.Application.DTOs.Device.Responses;
using TerraCloud.Domain.Models.User;
using TerraCloud.Infrastructure.Auth;

namespace TerraCloud.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, JwtUser>();
            CreateMap<RegisterRequest, User>();
            CreateMap<Domain.Models.Device.Device, DeviceResponse>();
        }
    }
}
