using Microsoft.EntityFrameworkCore;

using TerraCloud.Persistence.Contexts;
using TerraCloud.Server.Components;
using TerraCloud.Infrastructure;
using TerraCloud.Persistence;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TerraCloudContext>(options => options.UseNpgsql(config.GetConnectionString("AzureDatabase")));

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api")
    });

builder.Services.AddApplication();
builder.Services.AddPersistance();
builder.Services.AddInfrastructure();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TerraCloud.Client._Imports).Assembly);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
