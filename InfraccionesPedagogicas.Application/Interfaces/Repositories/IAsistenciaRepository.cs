using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface IAsistenciaRepository : IBaseRepository<Asistencia, int>
    {
        Task<Asistencia> GetAsistenciaByInfractor(string infractorId);
        Task<IEnumerable<Asistencia>> GetAsistenciaBySala(int idsala);
        Task<bool> HasRegisteredInfractores(int idsala);
        Task<IEnumerable<Asistencia>> GetAsistenciaBySalaDeep(int idSala);

    }
}
