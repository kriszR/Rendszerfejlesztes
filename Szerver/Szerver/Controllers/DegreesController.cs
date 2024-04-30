using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreesRepository _degreeRepository;

        public DegreesController(IDegreesRepository degreeRepository)
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
