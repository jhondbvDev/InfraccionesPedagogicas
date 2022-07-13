using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using System.Transactions;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class InfractorRepository : BaseRepository<Infractor, string>, IInfractorRepository
    {
        public InfractorRepository(InfraccionesDbContext context) : base(context)
        {
        }

        public async Task BulkAdd(IEnumerable<Infractor> infractores)
        {
            try
            {
                //var infractoresParaInsertar = infractores.Where(infractor => !_entities.Any(e => e.Id.Equals(infractor.Id))); codigo Andres

                var infractoresParaInsertar = infractores.Where(infractor => !(_entities.Any(e => e.Id == infractor.Id)));
                infractoresParaInsertar = infractoresParaInsertar.GroupBy(x => x.Id).Select(y => y.First());//Elimina duplicados

                await _entities.AddRangeAsync(infractoresParaInsertar);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task BulkDeleteOldRecords(IEnumerable<Infractor> infractores)
        {
            try
            {
                var excludedIDs = new HashSet<string>(infractores.Select(p => p.Id));
                //DateTime now = DateTime.Now.ToUniversalTime();
                var items = _entities.Where(infractor => !excludedIDs.Contains(infractor.Id)
                && !infractor.Asistencias.Any(asistencia => asistencia.Sala.Fecha >= DateTime.Now));

                //codigo Andres
                //var infractoresQueNoEstanEnElArchivoYNoTienenReunionesPendientesEnBaseDeDatos = _entities
                //        .Where(e => !infractores.Any(infractor => e.Id.Equals(infractor.Id)) && !e.Asistencias.Any(asistencia => asistencia.Sala.Fecha >= DateTime.Now));

                _context.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task Bulk(IEnumerable<Infractor> infractores)
        {
            try
            {
                await this.BulkDeleteOldRecords(infractores);
                await this.BulkAdd(infractores);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
