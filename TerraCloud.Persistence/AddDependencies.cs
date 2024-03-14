using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Persistence.Interfaces.Repository.Database;
using TerraCloud.Persistence.Interfaces.Repository.User;
using TerraCloud.Persistence.Repositories.Database;
using TerraCloud.Persistence.Repositories.User;

namespace TerraCloud.Persistence
{
    public static class AddDependencies
    {
        public static void AddPersistance(this IServiceCollection services)
        {
            //User
            services.AddScoped<IUserRepository, UserRepository>();

            //Database
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();
        }
    }
}
