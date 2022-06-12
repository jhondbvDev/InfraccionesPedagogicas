using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Services
{
    public class InfraccionService : IInfraccionService
    {
        private readonly IInfraccionRepository _infraccionRepository;

        public InfraccionService(IInfraccionRepository infraccionRepository)
        {
            _infraccionRepository = infraccionRepository;
        }

        public async Task<IEnumerable<Infraccion>> GetByDocumentoInfractor(string documento)
        {
            return await _infraccionRepository.GetByDocumentoInfractor(documento);
        }

        #region No implementados

        public Task Add(Infraccion entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Infraccion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Infraccion> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Infraccion entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
