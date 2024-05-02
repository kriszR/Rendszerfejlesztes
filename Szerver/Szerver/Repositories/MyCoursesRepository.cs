using Microsoft.EntityFrameworkCore;
using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IMyCoursesRepository
    {
        Task<IEnumerable<MyCourse>> GetMycourses();
    }
    public class MyCoursesRepository : IMyCoursesRepository
    {
        private readonly MoodleContext _context;

        public MyCoursesRepository(MoodleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MyCourse>> GetMycourses()
        {
            return await _context.Mycourses.ToListAsync();
        }
    }
}
