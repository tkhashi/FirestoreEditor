using FireController.Infrastructure.Interface;
using Google.Cloud.Firestore;
using System;

namespace FireController.Infrastructure
{
    public class EmulatorContext : IContext
    {
        public FirestoreDb DbConnection { get; }

        public EmulatorContext()
        {
            Environment.SetEnvironmentVariable("FIRESTORE_EMULATOR_HOST", "localhost:8080");
            DbConnection = new FirestoreDbBuilder
            {
                ProjectId = "smakan-demo-develop",
                EmulatorDetection = Google.Api.Gax.EmulatorDetection.EmulatorOnly
            }.Build();

        }
    }
}