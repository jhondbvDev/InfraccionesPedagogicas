using InfraccionesPedagogicas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface IBaseService<T, K> where T : BaseEntity<K>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(K id);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(K Id);
    }
}
