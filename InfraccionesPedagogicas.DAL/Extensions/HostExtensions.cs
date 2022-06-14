using InfraccionesPedagogicas.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Infrastructure.Extensions
{
    public static  class HostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<InfraccionesDbContext>();

                context.Database.EnsureCreated();
                new DataSeeder(context).SeedData();
            }

            return host;
        }
    }
}
