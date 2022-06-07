using InfraccionesPedagogicas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Infrastructure.Data
{
    public  class InfraccionesDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Sala> Salas=> Set<Sala>();
        public DbSet<Infraccion> Infracciones => Set<Infraccion>();
        public DbSet<DatosInfractor> DatosInfractor=> Set<DatosInfractor>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Infractor> Infractores=> Set<Infractor>();
        public DbSet<Asistencia> Asistencias=> Set<Asistencia>();

        public InfraccionesDbContext(DbContextOptions<InfraccionesDbContext> options):base(options)
        {

        }
    }
}
