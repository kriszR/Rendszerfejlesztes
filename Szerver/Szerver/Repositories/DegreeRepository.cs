using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly MoodleContext _context;

        public DegreeRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Degrees>> GetDegrees()
        {
            return await _context.Degrees.ToListAsync();
        }
    }
}
