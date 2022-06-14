using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Services
{
    public class InfractorService : IInfractorService
    {
        private readonly IInfractorRepository _infractorRepository;

        public InfractorService(IInfractorRepository infractorRepository)
        {
            _infractorRepository = infractorRepository;
        }

        public async Task BulkAdd(IEnumerable<Infractor> infractores)
        {
            await _infractorRepository.BulkAdd(infractores);
        }

        public async Task BulkDeleteOldRecords(IEnumerable<Infractor> infractores)
        {
            await _infractorRepository.BulkDeleteOldRecords(infractores);
        }

        #region No implementados

        public Task Add(Infractor entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Infractor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Infractor> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Infractor entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
