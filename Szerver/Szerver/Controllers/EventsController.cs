using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventRepository;

        public EventsController(IEventsRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Events>> GetEvents()
        {
            return await _eventRepository.GetEvents();
        }
    }
}
