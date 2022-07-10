using System.Collections.Generic;
using System.Threading.Tasks;
using FireController.Infrastructure.Interface;

namespace FireController.Infrastructure.DataAccessor
{
    public class RootDataAccessor : IRootDataAccessor
    {
        private IContext _context;

        public RootDataAccessor(IContext context)
        {
            _context = context;
        }

        public Task<ObjectId> Create(ObjectEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public Task Get()
        {
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerable<ObjectEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ObjectId> Update(ObjectEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}