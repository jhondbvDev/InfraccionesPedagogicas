using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Data
{
    public sealed class InfraccionesDbContext : IdentityDbContext<Usuario>, IInfraccionesDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        public DbSet<DatosInfractor> DatosInfractor { get; set; }
        public DbSet<Infractor> Infractores { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public InfraccionesDbContext(DbContextOptions<InfraccionesDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfraccionesDbContext).Assembly);


            //Seed Data
            modelBuilder.Entity<IdentityRole>().HasData(
                new Microsoft.AspNetCore.Identity.IdentityRole("TMB"),
                new Microsoft.AspNetCore.Identity.IdentityRole("SM")
                );
        }
    }
}
