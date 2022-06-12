using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Services
{
    public class DatosInfractorService : IDatosInfractorService
    {
        private readonly IDatosInfractorRepository _datosInfractorRepository;

        public DatosInfractorService(IDatosInfractorRepository datosInfractorRepository)
        {
            _datosInfractorRepository = datosInfractorRepository;
        }

        public async Task Add(DatosInfractor entity)
        {
            await _datosInfractorRepository.Add(entity);
        }

        public async Task<DatosInfractor> GetByInfractorId(string id)
        {
            return await _datosInfractorRepository.GetByInfractorId(id);
        }

        public async Task<bool> Update(DatosInfractor entity)
        {
            var datosInfractorOld = await _datosInfractorRepository.GetByInfractorId(entity.InfractorId);

            if (datosInfractorOld != null)
            {
                datosInfractorOld.Telefono = entity.Telefono;
                datosInfractorOld.Celular = entity.Celular;
                datosInfractorOld.Direccion = entity.Direccion;
                datosInfractorOld.Email = entity.Email;

                return await _datosInfractorRepository.Update(datosInfractorOld);
            }
            else
            {
                throw new Exception("Los datos del infractor que estas intentando actualizar no existen, intenta con otro numero de documento.");
            }
        }

        #region No implementados

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DatosInfractor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DatosInfractor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
