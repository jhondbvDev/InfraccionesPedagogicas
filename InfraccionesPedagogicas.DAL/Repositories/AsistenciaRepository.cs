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

        public async Task<IEnumerable<Asistencia>> GetAsistenciaBySala(int idsala)
        {
            return await _entities.Where(x => x.SalaId == idsala).Include(x => x.Infractor).ToListAsync();
        }

        public async Task<bool> HasRegisteredInfractores(int idsala) 
        {
            return await _entities.Where(x => x.SalaId == idsala).AnyAsync();
        }
    }
}
