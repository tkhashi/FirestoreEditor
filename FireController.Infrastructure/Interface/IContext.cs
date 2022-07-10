using Google.Cloud.Firestore;

namespace FireController.Infrastructure.Interface
{
    public interface IContext
    {
        public FirestoreDb DbConnection { get; }
    }
}