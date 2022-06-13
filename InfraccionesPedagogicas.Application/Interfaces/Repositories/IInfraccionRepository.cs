using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface IInfraccionRepository : IBaseRepository<Infraccion, int>
    {
        public Task BulkAdd(IEnumerable<Infraccion> infracciones);
        public Task<IEnumerable<Infraccion>> GetByInfractorId(string id);
    }
}
