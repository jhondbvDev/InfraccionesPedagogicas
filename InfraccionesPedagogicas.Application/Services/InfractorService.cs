using AutoMapper;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using System.Transactions;

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

        public async Task Bulk(IEnumerable<Infractor> infractores)
        {
            await _infractorRepository.Bulk(infractores);
     
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

        public async Task<Infractor> GetById(string id)
        {
            return await _infractorRepository.GetById(id);
        }

        public Task<bool> Update(Infractor entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
