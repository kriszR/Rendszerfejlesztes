using AutoMapper;
using Szerver.Models;
using Szerver.Models.DtoFolder;

namespace Szerver.Mapper
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<CreateEventDto, Event>();
            CreateMap<Event, GetEventDto>();
        }
    }
}
