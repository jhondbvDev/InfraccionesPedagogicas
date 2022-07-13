using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface IInfractorService : IBaseService<Infractor, string>
    {
        public Task BulkAdd(IEnumerable<Infractor> infractores);
        public Task BulkDeleteOldRecords(IEnumerable<Infractor> infractores);

        public Task Bulk(IEnumerable<Infractor> infractores);

    }
}
