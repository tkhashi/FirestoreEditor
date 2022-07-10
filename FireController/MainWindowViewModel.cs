using FireController.Infrastructure;
using Reactive.Bindings;

namespace FireController
{
    public  class MainWindowViewModel
    {
        public ReactiveCommand GetFsCommand { get; } = new ReactiveCommand();

        public FsCollection RootFsCollection { get; } = new FsCollection();

        public MainWindowViewModel()
        {
            GetFsCommand.WithSubscribe(async () =>
            {
                var a = RootFsCollection.GetDocuments();
            });
        }

    }
}
