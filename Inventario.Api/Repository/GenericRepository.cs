using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Inventario.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PersistenceContext _context;

        public GenericRepository(PersistenceContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includeObjectProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeObjectProperties != null)
                query = includeObjectProperties.Aggregate(query, (current, include) => current.Include(include));

            return await query.ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            if (entity == null)
            {
                return entity;
            }

            DbSet<T> item = _context.Set<T>();
            await item.AddAsync(entity);
            await _context.CommitAsync().ConfigureAwait(false);

            return entity;
        }
    }
}