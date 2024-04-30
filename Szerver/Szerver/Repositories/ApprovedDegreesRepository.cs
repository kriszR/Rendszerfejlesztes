using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class ApprovedDegreesRepository : IApprovedDegreesRepository
    {
        private readonly MoodleContext _context;

        public ApprovedDegreesRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ApprovedDegrees>> GetApprovedDegrees()
        {
            return await _context.ApprovedDegrees.ToListAsync();
        }
    }
}
