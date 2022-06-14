using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using InfraccionesPedagogicas.Infrastructure.Identity;
using InfraccionesPedagogicas.Infrastructure.Repositories;
using InfraccionesPedagogicas.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraccionesPedagogicas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<InfraccionesDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgresSQLConnection"),
                    b => b.MigrationsAssembly(typeof(InfraccionesDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<InfraccionesDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });
            services.AddScoped<IInfraccionesDbContext>(provider => provider.GetService<InfraccionesDbContext>())
                    .AddScoped<ISalaRepository, SalaRepository>()
                    .AddScoped<IDatosInfractorRepository, DatosInfractorRepository>()
                    .AddScoped<IInfraccionRepository, InfraccionRepository>()
                    .AddScoped<IAsistenciaRepository, AsistenciaRepository>()
                    .AddScoped<IIdentityService, IdentityService>()
                    .AddScoped<ITokenService,TokenService>(tokenService => new TokenService(configuration["Authentication:Secretkey"],
                                                                            configuration["Authentication:Issuer"], 
                                                                            configuration["Authentication:Audience"],
                                                                            configuration["Authentication:ExpireMinutes"]));//Adding service interface Infrastructure


            return services;
        }
    }
}
