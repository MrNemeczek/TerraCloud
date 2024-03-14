using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api")
    });

await builder.Build().RunAsync();
