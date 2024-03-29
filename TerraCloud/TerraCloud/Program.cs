using Microsoft.EntityFrameworkCore;
using Radzen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using TerraCloud.Persistence.Contexts;
using TerraCloud.Server.Components;
using TerraCloud.Infrastructure;
using TerraCloud.Persistence;
using TerraCloud.Client;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllersWithViews();

// DB context
builder.Services.AddDbContext<TerraCloudContext>(options => options.UseNpgsql(config.GetConnectionString("AzureDatabase")));

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(config["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api/")
    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // TODO: wziac z jwtservice
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Issuer"], // TODO: zmienic na Audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
    };
});

//Auth
//builder.Services.AddScoped<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddApplication();
builder.Services.AddPersistance();
builder.Services.AddInfrastructure();
builder.Services.AddClient();

// Radzen
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();// Czy potrzebne?

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Swagger
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
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TerraCloud.Client._Imports).Assembly);

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
