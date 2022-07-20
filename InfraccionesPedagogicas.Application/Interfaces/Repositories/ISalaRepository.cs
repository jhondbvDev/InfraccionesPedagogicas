using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface ISalaRepository : IBaseRepository<Sala, int>
    {
        Task<IEnumerable<Sala>> GetAllDeep(); 
        Task<IEnumerable<Sala>> GetAllDeep(int pageNumber, int pageSize);
        Task<int> GetCountAllDeep();
        Task<IEnumerable<Sala>> GetDeepForUser(int pageNumber,int pageSize,string userId);
         Task<int> GetDeepCountForUser(string userId);
        Task<Sala> GetDeep(int salaId);
        
        Task<bool> UpdateCupo(Sala sala);

        Task<Sala> GetByDate(DateTime date);
    }
}
