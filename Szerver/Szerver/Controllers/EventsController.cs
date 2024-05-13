using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szerver.Models;
using Szerver.Models.DtoFolder;
using Szerver.Repositories;

namespace Szerver.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventRepository.GetEvents();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateEventDto events)
        {
            var newEvent = await _eventRepository.CreateEvent(events);
            return Ok(newEvent);
        }
    }
}
