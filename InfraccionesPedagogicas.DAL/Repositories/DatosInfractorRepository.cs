using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    internal class DatosInfractorRepository : BaseRepository<DatosInfractor, int>, IDatosInfractorRepository
    {
        public DatosInfractorRepository(InfraccionesDbContext context) : base(context)
        {
        }

        public async Task<DatosInfractor> GetByInfractorId(string id)
        {
            return await _entities.Where(e => e.InfractorId.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
