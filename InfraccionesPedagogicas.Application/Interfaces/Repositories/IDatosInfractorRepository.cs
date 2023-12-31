﻿using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public interface IDatosInfractorRepository : IBaseRepository<DatosInfractor, int>
    {
        public Task<DatosInfractor> GetByInfractorId(string id);
    }
}
