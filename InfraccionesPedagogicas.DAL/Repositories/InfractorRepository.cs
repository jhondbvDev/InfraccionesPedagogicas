using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class InfractorRepository : BaseRepository<Infractor, string>, IInfractorRepository
    {
        public InfractorRepository(InfraccionesDbContext context) : base(context)
        {
        }

        public async Task BulkAdd(IEnumerable<Infractor> infractores)
        {
            var infractoresParaInsertar = infractores.Where(infractor => !_entities.Any(e => e.Id.Equals(infractor.Id)));

            await _entities.AddRangeAsync(infractoresParaInsertar);
            await _context.SaveChangesAsync();
        }

        public async Task BulkDeleteOldRecords(IEnumerable<Infractor> infractores)
        {
            var infractoresQueNoEstanEnElArchivoYNoTienenReunionesPendientesEnBaseDeDatos = _entities
                .Where(e => !infractores.Any(infractor => e.Id.Equals(infractor.Id)) && !e.Asistencias.Any(asistencia => asistencia.Sala.Fecha >= DateTime.Now));

            _context.RemoveRange(infractoresQueNoEstanEnElArchivoYNoTienenReunionesPendientesEnBaseDeDatos);
            await _context.SaveChangesAsync();
        }
    }
}
