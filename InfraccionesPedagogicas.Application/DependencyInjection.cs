using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace InfraccionesPedagogicas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ISalaService, SalaService>()
                    .AddScoped<IDatosInfractorService, DatosInfractorService>()
                    .AddScoped<IInfraccionService, InfraccionService>()
                    .AddScoped<IAsistenciaService, AsistenciaService>();

            return services;
        }
    }
}
