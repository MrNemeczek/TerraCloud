using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TerraCloud.Infrastructure.IoTHub;
using TerraCloud.Infrastructure.Auth;
using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure
{
    public static class AddDependencies
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPasswordOperations, PasswordOperations>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

            services.AddScoped<IIoTHubService, IoTHubService>();
            services.Configure<IoTHubOptions>(options => config.GetSection("IoTHub").Bind(options));
        }
    }
}
