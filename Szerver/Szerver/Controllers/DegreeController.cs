using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeRepository _degreeRepository;

        public DegreeController(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Degrees>> GetDegrees()
        {
            return await _degreeRepository.GetDegrees();
        }
    }
}
