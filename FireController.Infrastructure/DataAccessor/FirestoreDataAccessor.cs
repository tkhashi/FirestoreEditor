using FireController.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireController.Infrastructure.DataAccessor
{
    public class FirestoreDataAccessor : IDataAccessible<ObjectEntity, ObjectId>
    {
        private readonly IContext _context;

        public FirestoreDataAccessor(IContext context)
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

        public IAsyncEnumerable<ObjectEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ObjectEntity> Get(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ObjectId> Update(ObjectEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}