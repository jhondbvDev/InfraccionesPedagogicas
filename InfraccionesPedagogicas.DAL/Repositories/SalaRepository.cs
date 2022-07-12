using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class SalaRepository : BaseRepository<Sala, int>,ISalaRepository
    {
        public SalaRepository(InfraccionesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sala>> GetAllDeep()
        {
            var salas = await _context.Salas.Where(x=>x.Cupo>0 && x.Fecha>DateTime.Now.ToUniversalTime())
                .Include(b => b.Usuario).ToListAsync();
            return salas;
        }

        public async Task<IEnumerable<Sala>> GetDeepForUser(string userId)
        {
            var salas = await _context.Salas.Where(sala => sala.UsuarioId == userId).Include(b => b.Usuario).ToListAsync();
            return salas;
        }

        public async Task<Sala> GetDeep(int salaId)
        {
            var sala = await _context.Salas.Include(b => b.Usuario).FirstOrDefaultAsync(x=>x.Id==salaId);
            return sala;
        }
    }
}
