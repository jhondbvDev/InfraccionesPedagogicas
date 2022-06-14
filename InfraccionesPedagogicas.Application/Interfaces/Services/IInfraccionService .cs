using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface IInfraccionService : IBaseService<Infraccion, int>
    {
        public Task BulkAdd(IEnumerable<Infraccion> infracciones);
        public Task<IEnumerable<Infraccion>> GetByInfractorId(string id);
    }
}
