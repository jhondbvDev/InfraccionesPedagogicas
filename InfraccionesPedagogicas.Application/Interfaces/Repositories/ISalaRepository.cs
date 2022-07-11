using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface ISalaRepository : IBaseRepository<Sala,int>
    {
        Task<IEnumerable<Sala>> GetAllDeep();
        Task<Sala> GetDeep(int salaId);
    }
}
