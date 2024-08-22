using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

using TerraCloud.Client;
using TerraCloud.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
IConfiguration config = builder.Configuration;

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api/")
    });
// Auth
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddClient();
builder.Services.AddInfrastructure(config);

// Radzen
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();// Czy potrzebne?

// Local Storage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
