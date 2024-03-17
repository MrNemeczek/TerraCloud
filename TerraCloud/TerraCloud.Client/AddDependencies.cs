using TerraCloud.Client.Common;

namespace TerraCloud.Client
{
    public static class AddDependencies
    {
        public static void AddClient(this IServiceCollection services)
        {
            services.AddScoped<IApiRequest, ApiRequest>();
        }
    }
}
