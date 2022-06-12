using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface IDatosInfractorService : IBaseService<DatosInfractor, int>
    {
        public Task<DatosInfractor> GetByInfractorId(string documento);
    }
}
