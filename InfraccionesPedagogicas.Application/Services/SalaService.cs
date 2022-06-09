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
        public async Task Add(Sala entity)
        {
             await _salaRepository.Add(entity);
        }

        public async Task<bool> Delete(int Id)
        {
            var sala = await _salaRepository.GetById(Id);
            return await _salaRepository.Delete(sala);
        }

        public async Task<IEnumerable<Sala>> GetAll()
        {
           return await _salaRepository.GetAll();
        }

        public async Task<Sala> GetById(int id)
        {
            return await _salaRepository.GetById(id);
        }

        public async Task<bool> Update(Sala entity)
        {
            var salaOld = await _salaRepository.GetById(entity.Id);

            if (salaOld != null)
            {

                salaOld.Fecha = entity.Fecha;
                salaOld.Link = entity.Link;
                salaOld.Cupo = entity.Cupo;

                return await _salaRepository.Update(salaOld);
            }
            else
            {
                throw new Exception("La sala que estas intentando editar no existe, intenta con otra sala.");
                //throw new BusinessException("La sala que estas intentando editar no existe, intenta con otra sala.");
            }
        }
    }
}
