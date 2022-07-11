using InfraccionesPedagogicas.Application.Interfaces.Repositories;
using InfraccionesPedagogicas.Core.Entities;
using InfraccionesPedagogicas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfraccionesPedagogicas.Infrastructure.Repositories
{
    public abstract class BaseRepository<T, K> : IBaseRepository<T, K> where T :BaseEntity<K>
    {
        protected readonly InfraccionesDbContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(InfraccionesDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _entities.Remove(entity);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _entities.ToListAsync();
            return result;
        }

        public async Task<T> GetById(K id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            int rows=  await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }
    }
}
