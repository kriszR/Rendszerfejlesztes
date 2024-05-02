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
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeRepository _degreeRepository;

        public DegreesController(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Degree>> GetDegrees()
        {
            return await _degreeRepository.GetDegrees();
        }
    }
}
