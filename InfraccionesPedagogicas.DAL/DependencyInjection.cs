using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Infrastructure.Data;
using InfraccionesPedagogicas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<InfraccionesDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresSQLConnection"),
            b => b.MigrationsAssembly(typeof(InfraccionesDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IInfraccionesDbContext>(provider => provider.GetService<InfraccionesDbContext>());
            services.AddScoped<ISalaRepository, SalaRepository>();

            return services;
        }
    }
}
