using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface IAsistenciaService : IBaseService<Asistencia,int>
    {
        Task<Asistencia> GetAsistenciaByInfractor(string infractorId); 
         Task<IEnumerable<Asistencia>> GetAsistenciaBySala(int idsala);
         Task<bool> HasRegisteredInfractores(int idsala);
    }
}
