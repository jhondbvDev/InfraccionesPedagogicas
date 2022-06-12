using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InfraccionesPedagogicas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ISalaService, SalaService>();
            services.AddScoped<IDatosInfractorService, DatosInfractorService>();
            return services;
        }
    }
}
