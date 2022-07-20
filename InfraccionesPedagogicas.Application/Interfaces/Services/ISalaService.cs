using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface ISalaService:IBaseService<Sala,int>
    {
        Task<IEnumerable<Sala>> GetAllDeep();
        Task<IEnumerable<Sala>> GetAllDeep(IPaginationFilter pagination);
        Task<int> GetCountAllDeep();
        Task<Sala> GetDeep(int salaId);
        Task<IEnumerable<Sala>> GetDeepForUser(IPaginationFilter pagination, string userId);
        Task<int> GetDeepCountForUser(string userId);
    }
}
