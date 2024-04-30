using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Events>> GetEvents();
    }
}
