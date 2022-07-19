using InfraccionesPedagogicas.Application.Exceptions;
using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IAsistenciaRepository _asistenciaRepository;
        public SalaService(ISalaRepository salaRepository, IAsistenciaRepository asistenciaRepository)
        {
            _salaRepository = salaRepository;
            _asistenciaRepository = asistenciaRepository;   
        }
        public async Task Add(Sala entity)
        {
            try
            {
                entity.Cupo = entity.TotalCupo;
                var sala = await _salaRepository.GetByDate(entity.Fecha);
                if (sala != null)
                {
                    throw new BusinessException("Ya existe una sala programada en esta fecha");
                }
                await _salaRepository.Add(entity);
            }
            catch(BusinessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw new BusinessException("Ocurrio un error creando la sala , comuniquese con el administrador");
            }
        
        }

        public async Task<bool> Delete(int Id)
        {
            bool result = await _asistenciaRepository.HasRegisteredInfractores(Id);
            var sala = await _salaRepository.GetById(Id);
            if (result && sala.Fecha.AddHours(2) > DateTime.Now)
            {
                throw new BusinessException("La sala no puede ser eliminada por que ya tiene infractores inscritos , intente nuevamente 2 horas despues del inicio de la reunion");
            }
            return await _salaRepository.Delete(sala);
        }

        public async Task<IEnumerable<Sala>> GetAll()
        {
            return await _salaRepository.GetAll();
        }

        public async Task<IEnumerable<Sala>> GetAllDeep()
        {
            return await _salaRepository.GetAllDeep();
        }

        public async Task<Sala> GetById(int id)
        {
            return await _salaRepository.GetById(id);
        }

        public async Task<Sala> GetDeep(int salaId)
        {
            return await _salaRepository.GetDeep(salaId);
        }

        public async Task<IEnumerable<Sala>> GetDeepForUser(IPaginationFilter pagination, string userId)
        {
            return await _salaRepository.GetDeepForUser(pagination.PageNumber,pagination.PageSize, userId);
        }

        public async Task<bool> UpdateCupo(Sala entity)
        {
            return await _salaRepository.UpdateCupo(entity);
        }

        public async Task<bool> Update(Sala entity)
        {
            var salaOld = await _salaRepository.GetById(entity.Id);

            if (salaOld != null)
            {
                salaOld.Fecha = entity.Fecha;
                salaOld.Link = entity.Link;
                if (salaOld.TotalCupo == salaOld.Cupo)
                    salaOld.Cupo = entity.TotalCupo;
                else
                    throw new BusinessException("no se puede editar una sala con al menos un infractor inscrito");
                salaOld.TotalCupo = entity.TotalCupo;
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
