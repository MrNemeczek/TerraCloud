using Microsoft.Extensions.DependencyInjection;

using TerraCloud.Application.Animal.Commands;
using TerraCloud.Application.Animal.Queries;
using TerraCloud.Application.Device.Commands;
using TerraCloud.Application.Device.Queries;
using TerraCloud.Application.Interfaces.Animal;
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
            services.AddScoped<IAddDevice, AddDevice>();
            services.AddScoped<IDeleteDevice, DeleteDevice>();
            services.AddScoped<IAddUserDevice, AddUserDevice>();
            services.AddScoped<IGetUserDevices, GetUserDevices>();
            services.AddScoped<IUpdateUserDevice, UpdateUserDevice>();
            services.AddScoped<IDeleteUserDevice, DeleteUserDevice>();

            //Animal
            services.AddScoped<IGetAnimal, GetAnimal>();
            services.AddScoped<IGetAnimals, GetAnimals>();
            services.AddScoped<IAddAnimal, AddAnimal>();
            services.AddScoped<IDeleteAnimal, DeleteAnimal>();
        }
    }
}
