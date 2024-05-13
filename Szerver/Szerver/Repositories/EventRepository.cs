using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szerver.Models;
using Szerver.Models.DtoFolder;

namespace Szerver.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        public Task<ServiceResponse<GetEventDto>> CreateEvent(CreateEventDto request);
    }
    public class EventRepository : IEventRepository
    {
        private readonly MoodleContext _context;
        private readonly IMapper _mapper;

        public EventRepository(MoodleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<ServiceResponse<GetEventDto>> CreateEvent(CreateEventDto eventInfo)
        {
            var response = new ServiceResponse<GetEventDto>();
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == eventInfo.CourseId);
                var newEvent = new Event
                {
                    CourseId = eventInfo.CourseId,
                    Course = course,
                    Name = eventInfo.Name,
                    Description = eventInfo.Description
                };
                await _context.Events.AddAsync(newEvent);
                await _context.SaveChangesAsync();
                //var dbEvents = await _context.Event
                //    .Include(c => c.Course)
                //    .ToListAsync();
                response.Data = _mapper.Map<GetEventDto>(newEvent);
                //response.Message = ResponseMessages.EventSuccessfullyCreated;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /*public async Task<Event> Create( Event events)
        {
            _context.Events.Add(events);
            await _context.SaveChangesAsync();

            return events;
        }*/


    }

}
