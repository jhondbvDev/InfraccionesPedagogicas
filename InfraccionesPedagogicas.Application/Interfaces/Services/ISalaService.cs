using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface ISalaService:IBaseService<Sala,int>
    {
        Task<IEnumerable<Sala>> GetAllDeep();
        Task<Sala> GetDeep(int salaId);
        Task<IEnumerable<Sala>> GetDeepForUser(string userId);
    }
}
