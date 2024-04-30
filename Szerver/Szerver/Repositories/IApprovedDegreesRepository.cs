using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IApprovedDegreesRepository
    {
        Task<IEnumerable<ApprovedDegrees>> GetApprovedDegrees();
    }
}
