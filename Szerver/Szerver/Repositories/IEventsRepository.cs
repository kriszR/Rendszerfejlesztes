using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetEvents();
    }
}
