using Microsoft.Extensions.DependencyInjection;

using TerraCloud.Application.Device.Queries;
using TerraCloud.Application.Interfaces.Auth;
using TerraCloud.Application.Interfaces.Device;
using TerraCloud.Infrastructure.Auth;
using TerraCloud.Infrastructure.Auth.Registry;

namespace TerraCloud.Infrastructure
{
    public static class AddDependencies
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //Auth
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegistryService, RegistryService>();

            //Device
            services.AddScoped<IGetDevice, GetDevice>();
            services.AddScoped<IGetDevices, GetDevices>();
        }
    }
}
