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
    public class ApprovedDegreesController : ControllerBase
    {
        private readonly IApprovedDegreesRepository _approveddegreesRepository;

        public ApprovedDegreesController(IApprovedDegreesRepository approveddegreesRepository)
        {
            _approveddegreesRepository = approveddegreesRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<ApprovedDegree>> GetApprovedDegrees()
        {
            return await _approveddegreesRepository.GetApprovedDegrees();
        }
    }
}