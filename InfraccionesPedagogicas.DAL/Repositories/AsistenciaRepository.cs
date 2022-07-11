using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class AsistenciaRepository : BaseRepository<Asistencia, int>, IAsistenciaRepository
    {
        public AsistenciaRepository(InfraccionesDbContext context) : base(context)
        {
        }

        public async Task<Asistencia> GetAsistenciaByInfractor(string infractorId)
        {
            var asistencia = await _entities.FirstOrDefaultAsync(x=>x.InfractorId==infractorId);
            return asistencia;
        }


    }
}
