using System.Threading.Tasks;

namespace FireController.Infrastructure.Interface
{
    public interface IRootDataAccessor
    {
        public Task Get();
    }
}