using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface IInfraccionRepository : IBaseRepository<Infraccion, int>
    {
        public Task<IEnumerable<Infraccion>> GetByDocumentoInfractor(string documento);
    }
}
