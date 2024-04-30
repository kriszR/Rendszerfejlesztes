using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public class DegreesRepository : IDegreesRepository
    {
        private readonly MoodleContext _context;

        public DegreesRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Degrees>> GetDegrees()
        {
            return await _context.Degrees.ToListAsync();
        }
    }
}
