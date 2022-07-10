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

            SeedRoles(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            IdentityRole tmb = new IdentityRole();
            tmb.Name = "TMB";
            tmb.NormalizedName = "TMB";

            IdentityRole sm = new IdentityRole();
            sm.Name = "SM";
            sm.NormalizedName = "SM";
            //Seed Data
            modelBuilder.Entity<IdentityRole>().HasData(tmb, sm);
        }
    }
}
