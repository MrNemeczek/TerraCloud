using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TerraCloud.Client;
using TerraCloud.Client.Common;
using TerraCloud.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api/")
    });

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddClient();
builder.Services.AddInfrastructure();

builder.Services.AddRadzenComponents();
builder.Services.AddScoped<NotificationService>();

await builder.Build().RunAsync();
