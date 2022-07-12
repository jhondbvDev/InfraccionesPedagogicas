using InfraccionesPedagogicas.Application.Exceptions;
using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using System.Transactions;

namespace InfraccionesPedagogicas.Application.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        private readonly ISalaRepository _salaRepository;
        public AsistenciaService(IAsistenciaRepository asistenciaRepository,
            ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
            _asistenciaRepository = asistenciaRepository;
        }

        public async Task Add(Asistencia entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _asistenciaRepository.Add(entity);
                //decrease Sala cupo
                var sala = await _salaRepository.GetById(entity.SalaId);
                if (sala.Cupo > 1)
                    sala.Cupo--;
                else
                {
                    scope.Dispose();
                    throw new BusinessException("La sala con la fecha seleccionada no tiene cupos disponibles, intente con otra .");

                }
                await _salaRepository.Update(sala);

                scope.Complete();
            }
            //try
            //{
            //    using (TransactionScope scope = new TransactionScope())
            //    {
            //        await _asistenciaRepository.Add(entity);
            //        //decrease Sala cupo
            //        var sala = await _salaRepository.GetById(entity.SalaId);
            //        if (sala.Cupo > 1)
            //            sala.Cupo--;
            //        else
            //        {
            //            scope.Dispose();
            //            throw new BusinessException("La sala con la fecha seleccionada no tiene cupos disponibles, intente con otra .");

            //        }
            //        await _salaRepository.Update(sala);

            //        scope.Complete();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            
        }

        public async Task<IEnumerable<Asistencia>> GetAll()
        {
            return await _asistenciaRepository.GetAll();    
        }

        public async Task<Asistencia> GetById(int id)
        {
            return await _asistenciaRepository.GetById(id);
        }

        public async Task<bool> Update(Asistencia entity)
        {
            var asistenciaOld = await _asistenciaRepository.GetById(entity.Id);

            if(asistenciaOld != null)
            {
                asistenciaOld.Asistio = entity.Asistio;

                return await _asistenciaRepository.Update(asistenciaOld);
            }
            else
            {
                throw new Exception("El regisro de asistencia que estas intentando actualizar no existe, intenta con otro registro.");
            }
        }

        #region No implementados

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Asistencia> GetAsistenciaByInfractor(string infractorId)
        {
            return await _asistenciaRepository.GetAsistenciaByInfractor(infractorId);
        }

        public async Task<IEnumerable<Asistencia>> GetAsistenciaBySala(int idsala)
        {
            return await _asistenciaRepository.GetAsistenciaBySala(idsala);
        }

        #endregion
    }
}
