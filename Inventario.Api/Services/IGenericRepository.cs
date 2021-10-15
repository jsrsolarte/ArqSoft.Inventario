using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventario.Api.Services
{
    public interface IGenericRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includeObjectProperties);
        public Task<T> Add(T entity);
    }
}