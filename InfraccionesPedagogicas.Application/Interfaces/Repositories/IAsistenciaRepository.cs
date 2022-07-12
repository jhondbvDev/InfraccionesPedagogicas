using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface IAsistenciaRepository : IBaseRepository<Asistencia,int>
    {
        Task<Asistencia> GetAsistenciaByInfractor(string infractorId);
        Task<IEnumerable<Asistencia>> GetAsistenciaBySala(int idsala);

    }
}
