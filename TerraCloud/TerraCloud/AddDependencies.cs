using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Radzen;
using System.Text;

using TerraCloud.Persistence.Contexts;

namespace TerraCloud.Server
{
    public static class AddDependencies
    {
        public static void AddServer(this IServiceCollection services, IConfiguration config)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Radzen
            services.AddRadzenComponents();
            services.AddScoped<NotificationService>();
            services.AddScoped<DialogService>();// Czy potrzebne?

            // Add services to the container.
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            services.AddControllersWithViews();

            // DB context
            #if DEBUG
            services.AddDbContext<TerraCloudContext>(options => options.UseNpgsql(config.GetConnectionString("LocalDatabase")).UseLazyLoadingProxies());            
            #endif
            #if !DEBUG
            services.AddDbContext<TerraCloudContext>(options => options.UseNpgsql(config.GetConnectionString("AzureDatabase")).UseLazyLoadingProxies());
            #endif

            services.AddHttpClient("terracloud", client =>
            {
                client.BaseAddress = new Uri(config["AppConfigurations:ApiUrl"] ?? "https://localhost:7291/api/");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
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

            // Local Storage
            services.AddBlazoredLocalStorage();

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
