using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface IInfractorRepository : IBaseRepository<Infractor, string>
    {
        public Task BulkAdd(IEnumerable<Infractor> infractores);
        public Task BulkDeleteOldRecords(IEnumerable<Infractor> infractores);

    }
}
