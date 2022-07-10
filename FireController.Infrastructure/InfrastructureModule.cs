using FireController.Infrastructure.DataAccessor;
using FireController.Infrastructure.Interface;
using Prism.Ioc;
using Prism.Modularity;

namespace FireController.Infrastructure
{
    public class InfrastructureModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IContext, EmulatorContext>();
            containerRegistry.Register<IRootDataAccessor, RootDataAccessor>();
            containerRegistry.Register<IFsCollection, FsCollection>();
            containerRegistry.Register<IFsDocument, FsDocument>();
        }
    }
}