using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;
        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        public Task Add(Sala entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Sala entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sala>> GetAll()
        {
           return _salaRepository.GetAll();
        }

        public Task<Sala> GetById(int id)
        {
            return _salaRepository.GetById(id);
        }

        public Task<bool> Update(Sala entity)
        {
            throw new NotImplementedException();
        }
    }
}
