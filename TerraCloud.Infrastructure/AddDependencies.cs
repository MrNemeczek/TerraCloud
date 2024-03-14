using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Infrastructure.Auth;
using TerraCloud.Infrastructure.Interfaces.Auth;

namespace TerraCloud.Infrastructure
{
    public static class AddDependencies
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //User
            services.AddScoped<IPasswordOperations, PasswordOperations>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
