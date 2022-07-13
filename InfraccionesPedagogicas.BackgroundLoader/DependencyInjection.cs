using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Models;
using InfraccionesPedagogicas.Application.Services;
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
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            return services.AddDbContext<InfraccionesDbContext>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
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
