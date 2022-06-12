using InfraccionesPedagogicas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Application.Interfaces
{
    public  interface IInfraccionesDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        public DbSet<DatosInfractor> DatosInfractor { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Infractor> Infractores { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

    }
}
