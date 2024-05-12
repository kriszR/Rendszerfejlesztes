using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MycoursesController : ControllerBase
    {
        private readonly IMyCoursesRepository _mycoursesRepository;

        public MycoursesController(IMyCoursesRepository mycoursesRepository)
        {
            _mycoursesRepository = mycoursesRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<MyCourse>> GetMycourses()
        {
            return await _mycoursesRepository.GetMycourses();
        }
    }
}
