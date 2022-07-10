using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireController.Infrastructure.Interface
{
    public interface IDataAccessible<TEntity, TId>
    {
        public Task<TEntity> Get(TId id);

        public IAsyncEnumerable<TEntity> GetAll();

        public Task<TId> Update(TEntity entity);

        public Task<TId> Create(TEntity entity);

        public Task Delete(TId id);
    }
}