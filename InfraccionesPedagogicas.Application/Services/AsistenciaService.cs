using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaRepository _asistenciaRepository;

        public AsistenciaService(IAsistenciaRepository asistenciaRepository)
        {
            _asistenciaRepository = asistenciaRepository;
        }

        public async Task Add(Asistencia entity)
        {
            await _asistenciaRepository.Add(entity);
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
