using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public class SalaRepository : BaseRepository<Sala, int>,ISalaRepository
    {
        public SalaRepository(InfraccionesDbContext context) : base(context)
        {
        }
    }
}
