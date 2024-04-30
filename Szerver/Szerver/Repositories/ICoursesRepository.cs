using Szerver.Models;

namespace Szerver.Repositories
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Courses>> GetCourses();
    }
}
