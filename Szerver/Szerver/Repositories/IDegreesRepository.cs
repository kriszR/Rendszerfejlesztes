using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IDegreesRepository
    {
        Task<IEnumerable<Degrees>> GetDegrees();
    }
}
