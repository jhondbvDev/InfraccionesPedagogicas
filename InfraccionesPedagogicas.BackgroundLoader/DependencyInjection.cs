using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Services;
using InfraccionesPedagogicas.BackgroundLoader.Models;
using InfraccionesPedagogicas.Infrastructure.Data;
using InfraccionesPedagogicas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.BackgroundLoader
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            var loadPath = configuration.GetSection("LoadDirectory").Get<LoadPath>();

            return services.AddDbContext<InfraccionesDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgresSQLConnection"),
                    b => b.MigrationsAssembly(typeof(InfraccionesDbContext).Assembly.FullName)), ServiceLifetime.Transient)
                    .AddScoped<IInfraccionesDbContext, InfraccionesDbContext>()
                    .AddScoped<IInfraccionRepository, InfraccionRepository>()
                    .AddScoped<IInfractorRepository, InfractorRepository>()
                    .AddScoped<IInfraccionService, InfraccionService>()
                    .AddScoped<IInfractorService, InfractorService>()
                    .AddSingleton(loadPath);
        }
    }
}
