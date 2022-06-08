using InfraccionesPedagogicas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Interfaces.Repositories
{
    public  interface IBaseRepository<T,K> where T:BaseEntity<K>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(K id);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}
