using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

using TerraCloud.Infrastructure.Auth;
using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure
{
    public static class AddDependencies
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPasswordOperations, PasswordOperations>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
        }
    }
}
