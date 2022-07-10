using FireController.Infrastructure.FsFiled;
using FireController.Infrastructure.Interface;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireController.Infrastructure
{
    public class FsCollection :IFsCollection
    {
        private readonly IContext _context;

        public string Name { get; set; }
        public FsDocument ParentDocument { get; set; }
        public IList<FsDocument> Documents { get; set; }
        public CollectionReference NativeCollection { get; set; }

        public FsCollection(IContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<FsCollection> GetRootStart()
        {
            var rootFsCollections = _context.DbConnection.ListRootCollectionsAsync()
                .Select(x =>
                {
                     var fsCollection = new FsCollection(_context)
                     {
                         Name = x.Id,
                         ParentDocument = null,
                         Documents = null,
                         NativeCollection = x
                     };

                     return fsCollection;
                 });

            await foreach (var rootCollection in rootFsCollections)
            {
                rootCollection.Documents = await rootCollection.GetDocuments().ToListAsync();

                yield return rootCollection;
            }
        }
    }

    public class FsDocument:IFsDocument
    {
        private readonly IContext _context;

        public string DocumentId { get; set; }
        public FsCollection ParentCollection { get; set; }
        public IEnumerable<FsCollection> Collections { get; set; }
        public IEnumerable<FsField> Fields { get; set; }
        public DocumentReference NativeDocument { get; set; }

        // Root NativeDocument
        public FsDocument(IContext context)
        {
            _context = context;
            DocumentId = "Root";
            ParentCollection = null;
            Collections = context.DbConnection
                .ListRootCollectionsAsync()
                .ToEnumerable()
                .Select(x => new FsCollection(_context)
                {
                    Name = x.Id,
                    ParentDocument = this,
                });

            var _list = context.DbConnection.ListRootCollectionsAsync().ToListAsync();
        }

        private IAsyncEnumerable<CollectionReference> _list;

        public async Task SetCollections()
        {
            await foreach (var collection in _list)
            {
                var rootCollection = await collection.GetSnapshotAsync();
                var docsField = rootCollection.Documents.Select(x => x.ToDictionary());
            }
        }
    }

}