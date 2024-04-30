using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IDegreeRepository
    {
        Task<IEnumerable<Degrees>> GetDegrees();
    }
}
