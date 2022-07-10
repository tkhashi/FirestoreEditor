using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireController.Infrastructure.FsFiled;

namespace FireController.Infrastructure
{
    public static class FirestoreCollectionExtensions
    {
        public static async IAsyncEnumerable<FsCollection> GetCollections(this FsDocument document)
        {
            var collections = document.NativeDocument.ListCollectionsAsync();

            await foreach (var collection in collections)
            {
                var fsCollection = new FsCollection
                {
                    Name = collection.Id,
                    ParentDocument = document,
                    Documents = null,
                    NativeCollection = collection,
                };

                yield return fsCollection;
            }
        }

        public static async IAsyncEnumerable<FsDocument> GetDocuments(this FsCollection collection)
        {
            var docs = collection.NativeCollection.ListDocumentsAsync();
            await foreach (var doc in docs)
            {
                var fsDoc = new FsDocument
                {
                    DocumentId = doc.Id,
                    ParentCollection = collection,
                    Collections = null,
                    Fields = null,
                    NativeDocument = doc,
                };

                yield return fsDoc;
            }
        }

        public static async Task<IEnumerable<FsField>> GetField(this FsDocument document)
        {
            var docSnapshot = await document.NativeDocument.GetSnapshotAsync();
            var fields = docSnapshot
                .ToDictionary()
                .Select(f =>
                {
                    var key = new FieldKey(f.Key);
                    var value = new FieldValue(f.Key.ToFieldType(), f.Value.ToString());
                    var field = new FsField(key, value);

                    return field;
                });

            return fields;
        }
    }
}