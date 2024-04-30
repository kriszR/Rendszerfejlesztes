using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> Get();
        Task<Users> Get(int id);
        Task<IEnumerable<Courses>> GetCoursesForUser(int userId);
        Task<Users> Create(Users student);
        Task Update(Users student);
        Task Delete(int id);
    }
}
