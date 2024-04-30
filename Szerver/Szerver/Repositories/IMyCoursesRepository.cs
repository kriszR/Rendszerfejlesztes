using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IMyCoursesRepository
    {
        Task<IEnumerable<Mycourses>> GetMycourses();
    }
}
