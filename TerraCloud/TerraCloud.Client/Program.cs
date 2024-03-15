using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TerraCloud.Client.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api")
    });

builder.Services.AddScoped<ApiRequest>();

await builder.Build().RunAsync();
