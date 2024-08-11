using TerraCloud.Server.Middlewares;

namespace TerraCloud.Server
{
    public static class UseMiddlewares
    {
        public static IApplicationBuilder UseServer(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            return app;
        }
    }
}
