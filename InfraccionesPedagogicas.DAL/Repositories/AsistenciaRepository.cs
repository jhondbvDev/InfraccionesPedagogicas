using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class AsistenciaRepository : BaseRepository<Asistencia, int>, IAsistenciaRepository
    {
        public AsistenciaRepository(InfraccionesDbContext context) : base(context)
        {
        }
    }
}
