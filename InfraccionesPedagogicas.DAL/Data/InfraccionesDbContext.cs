using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Data
{
    public  class InfraccionesDbContext:DbContext,IInfraccionesDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        public DbSet<DatosInfractor> DatosInfractor { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Infractor> Infractores { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public InfraccionesDbContext(DbContextOptions<InfraccionesDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfraccionesDbContext).Assembly);
        }
    }
}
