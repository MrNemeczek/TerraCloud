using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using TerraCloud.Application.Interfaces.Application.Auth;
using TerraCloud.Infrastructure.Auth;
using TerraCloud.Infrastructure.Auth.Registry;
using TerraCloud.Persistence;

namespace TerraCloud.Infrastructure
{
    public static class AddDependencies
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //Auth
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegistryService, RegistryService>();
        }
    }
}
