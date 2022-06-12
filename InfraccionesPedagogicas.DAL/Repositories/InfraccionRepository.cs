using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class InfraccionRepository : BaseRepository<Infraccion, int>, IInfraccionRepository
    {
        public InfraccionRepository(InfraccionesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Infraccion>> GetByInfractorId(string id)
        {
            return await _entities.Where(e => e.InfractorId.Equals(id)).ToListAsync();
        }
    }
}
