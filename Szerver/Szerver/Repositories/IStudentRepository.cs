using Szerver.Models;

namespace Szerver.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Users>> Get();
        Task<Users> Get(int id);
        Task<Users> Create(Users student);
        Task Update(Users student);
        Task Delete(int id);
    }
}
